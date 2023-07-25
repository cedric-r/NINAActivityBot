using NINAActivityBot.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util
{
    public static class BotManager
    {
        public static void Start()
        {
            Thread? MonitorImageThread = null;
            Thread? NINAStatusThread = null;

            Logger.Log("NINAActivityBot v" + Constants.Version);

            Logger.Log("Starting threads");
            MonitorImageBot bot1 = new MonitorImageBot();
            MonitorImageThread = new Thread(() => bot1.Start(new BotConditionNinaIsRunning(Parameters.Instance.NINAURL))) { IsBackground = true };
            MonitorImageThread.Start();

            NINAStatusBot bot2 = new NINAStatusBot(Parameters.Instance.NINABaseURL);
            NINAStatusThread = new Thread(() => bot2.Start(new BotConditionNinaIsRunning(Parameters.Instance.NINABaseURL))) { IsBackground = true };
            NINAStatusThread.Start();

            Logger.Log("Threads started");
        }

        public static void Stop()
        {
            foreach (Bot bot in Bot.Bots)
            {
                bot.Stop();
            }
        }
    }
}
