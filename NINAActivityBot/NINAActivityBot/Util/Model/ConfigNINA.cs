using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util.Model
{
    public class ConfigNINA
    {
        public string NINABaseURL { get; set; } = "http://pc.e-eye:81/";
        public string NINAURL { get { return NINABaseURL + "sessions/sessions.json"; } }
        public string ImageCreateURL { get; set; } = "api/1020/image/create";
        public string NINAName { get; set; } = "NINA";

    }
}
