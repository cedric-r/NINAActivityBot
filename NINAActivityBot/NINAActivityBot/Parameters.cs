using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot
{
    public static class Parameters
    {
        public static string SocialNetName = "mastodon";
        public static string SocialNetServer = "mastodonti.st";
        public static string SocialUsername = "ninaactivitybot@mastodonti.st";
        public static string SocialPassword = "***REMOVED***";
        public static string NINABaseURL = "http://pc.e-eye:81/";
        public static string NINAURL = NINABaseURL + "sessions/sessions.json";
        public static string MonitorImageURL = "http://dashboard.e-eye/webcam1.php";
        public static string ImageCreateURL = "api/1020/image/create";
    }
}
