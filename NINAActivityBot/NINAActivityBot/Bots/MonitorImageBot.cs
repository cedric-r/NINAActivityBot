using NINAActivityBot.Social;
using NINAActivityBot.Social.Model;
using NINAActivityBot.Util;
using NINAActivityBot.Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Bots
{
    public class MonitorImageBot : Bot
    {
        private const int Interval = 5 * 60 * 1000;
        private bool StopFlag = false;
        private ConfigMonitorCamera Camera;
        private List<ConfigSocialNet> SocialNets = new List<ConfigSocialNet>();

        public MonitorImageBot(string botName, List<ConfigSocialNet> socialNets, ConfigMonitorCamera camera) : base(botName)
        {
            if (socialNets == null) throw new ArgumentNullException("Social nets can't be empty");
            if (camera == null) throw new ArgumentNullException("Camera can't be empty");
            Camera = camera;
            SocialNets = socialNets;
        }

        private void PostImage(ConfigMonitorCamera camera)
        {
            String image = DownloadImage(camera.MonitorImageURL);

            SocialNetPost post = new SocialNetPost();
            post.Body = DateTime.Now + " Monitoring " + BotName;
            post.Visibility = SocialNetVisibility.Unlisted;
            post.Attachments.Add(new SocialNetAttachment() { FileName = image, Name = "webcam.jpg" });
            Post(SocialNets, post);
            File.Delete(image);
        }

        public override void Start(BotCondition condition)
        {
            while (!StopFlag)
            {
                try
                {
                    if (condition.Valid())
                    {
                        PostImage(Camera);
                    }
                    Logger.Log(BotName + ": Sleeping...");
                    Thread.Sleep(Interval);
                }
                catch(Exception e)
                {
                    Logger.Log(BotName + ": Error: " + e.Message);
                }
            }
        }

        public override void Stop()
        {
            StopFlag = true;
        }
    }
}
