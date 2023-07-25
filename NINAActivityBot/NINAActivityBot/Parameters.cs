using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot
{
    public class Parameters
    {
        public string SocialNetName { get; set; } = "mastodon";
        public string SocialNetServer { get; set; } = "mastodonti.st";
        public string SocialUsername { get; set; } = "ninaactivitybot@mastodonti.st";
        public string SocialPassword { get; set; } = "***REMOVED***";
        public string NINABaseURL { get; set; } = "http://pc.e-eye:81/";
        public string NINAURL { get { return NINABaseURL + "sessions/sessions.json"; }  }
        public string MonitorImageURL { get; set; } = "http://dashboard.e-eye/webcam1.php";
        public string ImageCreateURL { get; set; } = "api/1020/image/create";

        public static Parameters Instance = new Parameters();
    }
}
