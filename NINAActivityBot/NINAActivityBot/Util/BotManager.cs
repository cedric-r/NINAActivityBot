using NINAActivityBot.Bots;
using NINAActivityBot.Util.Model;
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
            List<Thread> MonitorImageThreads = new List<Thread>();
            Thread? NINAStatusThread = null;

            Logger.Log("NINAActivityBot v" + Constants.Version);

            Logger.Log("Starting bots");
            foreach (ConfigObservatory observatory in Parameters.Instance.ObservatoryConfig)
            {
                foreach (ConfigMonitorCamera camera in observatory.CameraConfig)
                {
                    MonitorImageBot bot1 = new MonitorImageBot(camera.MonitorCameraName, observatory.SocialNetConfig, camera);
                    bot1.BotName = camera.MonitorCameraName;
                    Thread t = new Thread(() => bot1.Start(new BotConditionNinaIsRunning(observatory.NINAConfig.NINABaseURL))) { IsBackground = true };
                    MonitorImageThreads.Add(t);
                    t.Start();
                }

                NINAStatusBot bot2 = new NINAStatusBot(observatory.NINAConfig.NINAName, observatory.SocialNetConfig, observatory.NINAConfig);
                bot2.BotName = observatory.NINAConfig.NINAName;
                NINAStatusThread = new Thread(() => bot2.Start(new BotConditionNinaIsRunning(observatory.NINAConfig.NINABaseURL))) { IsBackground = true };
                NINAStatusThread.Start();
            }

            Logger.Log("Bots started");
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
