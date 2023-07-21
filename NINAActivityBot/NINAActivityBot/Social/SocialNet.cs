using NINAActivityBot.Social.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Social
{
    public abstract class SocialNet
    {
        public string Server = "";
        public string AppName = "NINAActivityBot";

        public SocialNet(string server, string appname)
        {
            Server = server;
            AppName = appname;
        }

        public SocialNet(string appName)
        {
            AppName = appName;
        }

        public SocialNet()
        {
        }

        public abstract void Connect(string server);

        public abstract void Connect();

        public abstract void Login(string username, string password);

        public abstract void Post(SocialNetPost post);
    }
}
