using NINAActivityBot.Social;
using NINAActivityBot.Social.Model;
using NINAActivityBot.Util;
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
        private const string _BotName = "MonitorImageBot";
        private string URL = Parameters.MonitorImageURL;
        private const int Interval = 5 * 60 * 1000;
        public bool Stop = false;

        public MonitorImageBot() : base(_BotName)
        {
        }

        public MonitorImageBot(string uRL) : base(_BotName)
        {
            URL = uRL;
        }

        private void PostImage()
        {
            String image = DownloadImage(URL);

            SocialNetPost post = new SocialNetPost();
            post.Body = "Monitoring Camera 1";
            post.Visibility = SocialNetVisibility.Unlisted;
            post.Attachments.Add(new SocialNetAttachment() { FileName = image, Name = "webcam.jpg" });
            Post(post);
            File.Delete(image);
        }

        public void Start(BotCondition condition)
        {
            while (!Stop)
            {
                try
                {
                    if (condition.Valid())
                    {
                        PostImage();
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
    }
}
