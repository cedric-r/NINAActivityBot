using Newtonsoft.Json.Linq;
using NINAActivityBot.Social.Model;
using NINAActivityBot.Util;
using NINAActivityBot.Util.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Bots
{
    public class NINAStatusBot : Bot
    {
        protected static List<string> ImagesSeen = new List<string>();
        protected static List<string> EventsSeen = new List<string>();
        private static Dictionary<string, string> EventMapping = new Dictionary<string, string>() { 
            { "NINA-START", "NINA starting" }, 
            { "NINA-ADV-SEQ-START", "Sequence start" },
            { "NINA-ADV-SEQ-STOP", "Sequence stop" },
            { "NINA-UNPARK", "Unparking telescope" }, 
            { "NINA-PARK", "Parking telescope" },
            { "NINA-DOME-SHUTTER-CLOSED", "Closing shutter" },
            { "NINA-DOME-SHUTTER-OPENED", "Opening shutter" }
        };
        private const string ImageCreatePayload = "{\"sessionName\":\"#SESSION#\",\"id\":\"#IMAGEID#\",\"fullPath\":\"#FULLPATH#\",\"stretchOptions\":{\"autoStretchFactor\":0.2,\"blackClipping\":-2.8,\"unlinkedStretch\":true},\"imageScale\":0.75,\"qualityLevel\":100}";
        private const string _BotName = "NINAStatusBot";
        private const int Interval = 5 * 60 * 1000;
        public bool StopFlag = false;
        private ConfigNINA Nina;
        List<ConfigSocialNet> SocialNets = new List<ConfigSocialNet>();

        public NINAStatusBot(string botName, List<ConfigSocialNet> socialNets, ConfigNINA nina) : base(botName)
        {
            if (socialNets == null) throw new ArgumentNullException("Social nets can't be empty");
            if (nina == null) throw new ArgumentNullException("NINA configuration can't be empty");
            Nina = nina;
            SocialNets = socialNets;
        }

        private string DownloadSession(ConfigNINA nina)
        {
            if (String.IsNullOrEmpty(nina.NINABaseURL)) throw new ArgumentNullException("URL not defined");

            string sessionKey = "";
            Logger.Log(BotName + ": Downloading session from " + nina.NINABaseURL + "sessions/sessions.json");
            using (WebClient client = new WebClient())
            {
                string sessions = client.DownloadString(nina.NINABaseURL + "sessions/sessions.json");

                dynamic stuff = JObject.Parse(sessions);

                var session = stuff.sessions.Last;
                sessionKey = session.key;
            }
            //sessionKey = "20230720-214555"; // For testing only
            return sessionKey;
        }

        private string DownloadLargeImage(string URL, string createURL, string payload)
        {
            if (String.IsNullOrEmpty(URL)) throw new ArgumentNullException("URL not defined");

            Logger.Log(BotName + ": Downloading image from " + createURL);
            string tempFileName = Path.GetTempFileName();
            using (WebClient client = new WebClient())
            {
                string response = client.UploadString(createURL, WebRequestMethods.Http.Put, payload);
                dynamic stuff = JObject.Parse(response);

                string id = stuff.id;
                string urlPath = stuff.urlPath;

                string imageFile = DownloadImage(URL + urlPath);

                Stream stream = client.OpenRead(imageFile);
                Bitmap bitmap; bitmap = new Bitmap(stream);

                if (bitmap != null)
                {
                    bitmap.Save(tempFileName, ImageFormat.Jpeg);
                }

                stream.Flush();
                stream.Close();
            }

            return tempFileName;
        }

        private void LoadSession(ConfigNINA nina, string key)
        {
            Logger.Log(BotName + ": Downloading session from " + nina.NINABaseURL + "sessions/" + key + "/sessionHistory.json");
            using (WebClient client = new WebClient())
            {
                string sessions = client.DownloadString(nina.NINABaseURL + "sessions/" + key + "/sessionHistory.json");

                dynamic stuff = JObject.Parse(sessions);

                if (stuff.events.Count > 0)
                {
                    foreach (var lastEvent in stuff.events)
                    {
                        string eventId = lastEvent.id;
                        string eventType = lastEvent.type;
                        if (!EventsSeen.Contains(eventId))
                        {
                            if (EventMapping.ContainsKey(eventType))
                            {
                                SocialNetPost post = new SocialNetPost();
                                post.Body = DateTime.Now + BotName + " " + EventMapping[eventType];
                                post.Visibility = SocialNetVisibility.Unlisted;
                                Post(SocialNets, post); // Should we post a message for each status change or group them?
                            }
                            EventsSeen.Add(eventId);
                        }
                    }
                }

                var target = stuff.targets.Last;
                if (target != null)
                {
                    string name = target.name;
                    var image = target.imageRecords.Last;
                    if (image != null)
                    {
                        string imageId = image.id;
                        string fullPath = image.fullPath;

                        if (!ImagesSeen.Contains(imageId))
                        {
                            ImagesSeen.Add(imageId);

                            string payload = ImageCreatePayload;
                            payload = payload.Replace("#SESSION#", key);
                            payload = payload.Replace("#IMAGEID#", imageId);
                            payload = payload.Replace("#FULLPATH#", fullPath.Replace("\\", "\\\\")); // NINA expects the backslashes escaped
                            String imageFile = DownloadLargeImage(nina.NINABaseURL, nina.NINABaseURL + nina.ImageCreateURL, payload);

                            SocialNetPost post = new SocialNetPost();
                            post.Body = DateTime.Now + BotName + " currently observing " + name + " with filter " + image.filterName + " for " + image.duration + "s\n\nHFR=" + image.HFR.ToString("#.####") + ", stars=" + image.detectedStars + ", guiding RMS=" + image.GuidingRMSArcSec + "\" (RA=" + image.GuidingRMSRAArcSec + "\", DEC=" + image.GuidingRMSDECArcSec + "\")";
                            post.Visibility = SocialNetVisibility.Unlisted;
                            post.Attachments.Add(new SocialNetAttachment() { FileName = imageFile, Name = imageId + ".jpg" });
                            Post(SocialNets, post);

                            File.Delete(imageFile);
                        }
                    }
                }
            }
        }

        private void GetNINAStatus()
        {

        }

        public override void Start(BotCondition condition)
        {
            while (!StopFlag)
            {
                try
                {
                    if (condition.Valid())
                    {
                        LoadSession(Nina, DownloadSession(Nina));
                    }
                    Logger.Log(BotName + ": Sleeping...");
                    Thread.Sleep(Interval);
                }
                catch(Exception e)
                {
                    Logger.Log(BotName + ": Error: "+e.Message);
                }
            }
        }

        public override void Stop()
        {
            StopFlag = true;
        }
    }
}
