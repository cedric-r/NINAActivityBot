using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Bots
{
    public class BotConditionNinaIsRunning : BotCondition
    {
        private string URL = "";

        public BotConditionNinaIsRunning(string uRL)
        {
            if (String.IsNullOrEmpty(uRL)) throw new ArgumentNullException("NINA's URL needs to be specified");
            URL = uRL;
        }

        public override bool Valid()
        {
            return RemoteFileExists(URL);
        }

        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    //Returns TRUE if the Status code == 200
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
    }
}
