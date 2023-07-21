using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Social.Model
{
    public class SocialNetPost
    {
        public string Body { get; set; } = "";
        public List<SocialNetAttachment> Attachments { get; set; } = new List<SocialNetAttachment>();
        public SocialNetVisibility Visibility { get; set; } = SocialNetVisibility.Private;
    }
}
