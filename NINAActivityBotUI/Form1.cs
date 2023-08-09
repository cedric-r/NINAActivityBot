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

        int textLength = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<string> list = new List<string>(Logger.LogHistory);
            list.RemoveRange(0, textLength); // Here remove the lines that have already been seen. Not very nice.
            if (list.Count > 0)
            {
                logBox.AppendText("\r\n" + String.Join("\r\n", list)); ;
                textLength = Logger.LogHistory.Count;
            }
        }
    }
}