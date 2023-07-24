using NINAActivityBot.Social;
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
    public abstract class Bot
    {
        public static List<Bot> Bots = new List<Bot>();
        protected string BotName = "Bot";

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

        protected void Post(SocialNetPost post)
        {
            Logger.Log(BotName + ": Posting to " + Parameters.SocialNetServer);
            SocialNet social = SocialNetFactory.Create(Parameters.SocialNetName);
            social.Connect(Parameters.SocialNetServer);
            social.Login(Parameters.SocialUsername, Parameters.SocialPassword);
            social.Post(post);
        }

        public abstract void Start(BotCondition condition);
        
        public abstract void Stop();
    }
}
