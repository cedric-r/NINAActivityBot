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
    }
}