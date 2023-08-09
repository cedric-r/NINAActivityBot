using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util.Model
{
    public class ConfigMonitorCamera
    {
        public string MonitorImageURL { get; set; } = "http://dashboard.e-eye/webcam1.php";
        public string MonitorCameraName { get; set; } = "Camera";
    }
}
