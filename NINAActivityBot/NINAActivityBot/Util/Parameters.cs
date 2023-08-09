using NINAActivityBot.Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util
{
    public class Parameters
    {
        public List<ConfigObservatory> ObservatoryConfig = new List<ConfigObservatory>();

        public static Parameters Instance = new Parameters();
    }
}
