using NINAActivityBot;
using NINAActivityBot.Bots;
using NINAActivityBot.Util;

namespace NINAActivityBotUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Config.LoadConfig();
            textBox1SocialNetName.Text = Parameters.Instance.SocialNetName;
            textBox1SocialNetServer.Text = Parameters.Instance.SocialNetServer;
            textBoxMonitorIageURL.Text = Parameters.Instance.MonitorImageURL;
            textBoxNINABaseURL.Text = Parameters.Instance.NINABaseURL;
            textBoxSocialUsername.Text = Parameters.Instance.SocialUsername;
            textBoxPassword.Text = Parameters.Instance.SocialPassword;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            BotManager.Stop();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            BotManager.Start();
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BotManager.Start();
            buttonStart.Enabled = false;
        }

        private void SaveConfig()
        {
            Config.SaveConfig();
        }

        private void textBox1SocialNetName_TextChanged(object sender, EventArgs e)
        {
            Parameters.Instance.SocialNetName = textBox1SocialNetName.Text;
            SaveConfig();
        }

        private void textBox1SocialNetServer_TextChanged(object sender, EventArgs e)
        {
            Parameters.Instance.SocialNetServer = textBox1SocialNetServer.Text;
            SaveConfig();
        }

        private void textBoxSocialUsername_TextChanged(object sender, EventArgs e)
        {
            Parameters.Instance.SocialUsername = textBoxSocialUsername.Text;
            SaveConfig();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Parameters.Instance.SocialPassword = textBoxPassword.Text;
            SaveConfig();
        }

        private void textBoxNINABaseURL_TextChanged(object sender, EventArgs e)
        {
            Parameters.Instance.NINABaseURL = textBoxNINABaseURL.Text;
            SaveConfig();
        }

        private void textBoxMonitorIageURL_TextChanged(object sender, EventArgs e)
        {
            Parameters.Instance.MonitorImageURL = textBoxMonitorIageURL.Text;
            SaveConfig();
        }
    }
}