using Newtonsoft.Json.Linq;
using NINAActivityBot.Social.Model;
using NINAActivityBot.Util;
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
        private const string ImageCreatePayload = "{\"sessionName\":\"#SESSION#\",\"id\":\"#IMAGEID#\",\"fullPath\":\"#FULLPATH#\",\"stretchOptions\":{\"autoStretchFactor\":0.2,\"blackClipping\":-2.8,\"unlinkedStretch\":true},\"imageScale\":0.75,\"qualityLevel\":100}";
        private const string _BotName = "NINAStatusBot";
        private string URL = Parameters.Instance.NINAURL;
        private const int Interval = 5 * 60 * 1000;
        public bool StopFlag = false;

        public NINAStatusBot() : base(_BotName)
        {

        }

        public NINAStatusBot(string url) : base(_BotName)
        {
            URL = url;
        }

        private string DownloadSession()
        {
            if (String.IsNullOrEmpty(URL)) throw new ArgumentNullException("URL not defined");

            string sessionKey = "";
            Logger.Log(BotName + ": Downloading session from " + URL + "sessions/sessions.json");
            using (WebClient client = new WebClient())
            {
                string sessions = client.DownloadString(URL + "sessions/sessions.json");

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

        private void LoadSession(string key)
        {
            Logger.Log(BotName + ": Downloading session from " + URL + "sessions/" + key + "/sessionHistory.json");
            using (WebClient client = new WebClient())
            {
                string sessions = client.DownloadString(URL + "sessions/" + key + "/sessionHistory.json");

                dynamic stuff = JObject.Parse(sessions);

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
                            String imageFile = DownloadLargeImage(URL, URL + Parameters.Instance.ImageCreateURL, payload);

                            SocialNetPost post = new SocialNetPost();
                            post.Body = DateTime.Now + " Currently observing " + name;
                            post.Visibility = SocialNetVisibility.Unlisted;
                            post.Attachments.Add(new SocialNetAttachment() { FileName = imageFile, Name = imageId + ".jpg" });
                            Post(post);

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
                        LoadSession(DownloadSession());
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
