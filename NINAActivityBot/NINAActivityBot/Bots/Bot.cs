using NINAActivityBot.Social;
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
    public abstract class Bot
    {
        public static List<Bot> Bots = new List<Bot>();
        public string BotName = "Bot";

        public Bot(string botname)
        {
            BotName = botname;
            Bots.Add(this);
        }

        protected string DownloadImage(string URL)
        {
            if (String.IsNullOrEmpty(URL)) throw new ArgumentNullException("URL not defined");

            Logger.Log(BotName + ": Downloading image from " + URL);
            string tempFileName = Path.GetTempFileName();
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(URL);
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

        protected void Post(List<ConfigSocialNet> socialNets, SocialNetPost post)
        {
            foreach (ConfigSocialNet socialNet in socialNets)
            {

                Logger.Log(BotName + ": Posting to " + socialNet.SocialNetServer);
                SocialNet social = SocialNetFactory.Create(socialNet.SocialNetName);
                social.Connect(socialNet.SocialNetServer);
                social.Login(socialNet.SocialUsername, socialNet.SocialPassword);
                social.Post(post);
            }
        }

        public abstract void Start(BotCondition condition);
        
        public abstract void Stop();
    }
}
