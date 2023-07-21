using Mastonet;
using Mastonet.Entities;
using NINAActivityBot.Social.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Social
{
    public class SocialNetMastodon : SocialNet
    {
        private AuthenticationClient MastodonAuthenticationClient = null;
        private AppRegistration MastodonAppRegistration = null;
        private Auth MastodonAuth = null;
        private string accessToken = "";
        private MastodonClient mastodonClient = null;
        List<Attachment> attachments = new List<Attachment>();

        public SocialNetMastodon(string server, string appname) : base(server, appname)
        {

        }

        public SocialNetMastodon(string appname) : base(appname)
        {

        }

        public SocialNetMastodon() : base()
        {

        }


        public override void Connect(string server)
        {
            if (String.IsNullOrEmpty(server)) throw new ArgumentNullException("Server not defined");
            Server = server;

            MastodonAuthenticationClient = new AuthenticationClient(server);
            if (MastodonAuthenticationClient == null) throw new InvalidOperationException("Connection to server failed");

            MastodonAppRegistration = MastodonAuthenticationClient.CreateApp("Your app name", Scope.Read | Scope.Write | Scope.Follow).Result;
            if (MastodonAppRegistration == null) throw new InvalidOperationException("App creation failed");
        }

        public override void Connect()
        {
            Connect(Server);
        }

        public override void Login(string username, string password)
        {
            if (MastodonAuthenticationClient == null) throw new InvalidOperationException("Connection to server failed");
            MastodonAuth = MastodonAuthenticationClient.ConnectWithPassword(username, password).Result;
            if (MastodonAuth == null) throw new InvalidOperationException("Authentication failed");
            accessToken = MastodonAuth.AccessToken;
            mastodonClient = new MastodonClient(Server, accessToken);
        }

        public override void Post(SocialNetPost post)
        {
            MastodonPost(post).GetAwaiter().GetResult();
        }

        private async Task MastodonPost(SocialNetPost post)
        {
            List<Attachment> attachments = new List<Attachment>();
            if (post.Attachments.Count > 0)
            {
                foreach (SocialNetAttachment attachment in post.Attachments)
                {
                    if (String.IsNullOrEmpty(attachment.Name)) throw new ArgumentNullException("Attachements require a name");
                    if (String.IsNullOrEmpty(attachment.FileName)) throw new ArgumentNullException("Attachements require file reference");
                    using (FileStream fs = File.OpenRead(attachment.FileName))
                    {
                        attachments.Add(MastodonUpload(fs, attachment.Name).Result);
                    }
                }
            }
            var mediaIds = attachments.Select(a => a.Id);

            Visibility visibility = Visibility.Private; // Default visibility is private, just in case
            switch(post.Visibility)
            {
                case SocialNetVisibility.Private: visibility = Visibility.Private; break;
                case SocialNetVisibility.Unlisted: visibility = Visibility.Unlisted; break;
                case SocialNetVisibility.Public: visibility = Visibility.Public; break;
            }
            await mastodonClient.PublishStatus(post.Body, visibility, mediaIds: mediaIds);
        }

        private async Task<Attachment> MastodonUpload(Stream stream, string fileName)
        {
            var media = new MediaDefinition(stream, fileName ?? "img");
            var attachment = await mastodonClient.UploadMedia(media);
            return attachment;
        }
    }
}
