using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Social
{
    public static class SocialNetFactory
    {
        public static SocialNet Create(string net)
        {
            switch (net)
            {
                case "mastodon":
                    return new SocialNetMastodon();
                default:
                    return new SocialNetMastodon();
            }
        }
    }
}
