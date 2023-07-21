using NINAActivityBot.Social;
using NINAActivityBot.Social.Model;
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
        protected string BotName = "Bot";

        public Bot(string botname)
        {
            BotName = botname;
        }

        protected string DownloadImage(string URL)
        {
            if (String.IsNullOrEmpty(URL)) throw new ArgumentNullException("URL not defined");

            Console.WriteLine(BotName + ": Downloading image from " + URL);
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
            Console.WriteLine(BotName + ": Posting to " + Constants.SocialNetServer);
            SocialNet social = SocialNetFactory.Create(Constants.SocialNetName);
            social.Connect(Constants.SocialNetServer);
            social.Login(Constants.SocialUsername, Constants.SocialPassword);
            social.Post(post);
        }
    }
}
