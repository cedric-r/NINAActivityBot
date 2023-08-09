using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util.Model
{
    public class ConfigObservatory
    {
        public List<ConfigSocialNet> SocialNetConfig = new List<ConfigSocialNet>();
        public ConfigNINA NINAConfig;
        public List<ConfigMonitorCamera> CameraConfig = new List<ConfigMonitorCamera>();
    }
}
