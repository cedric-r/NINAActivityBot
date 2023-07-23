// See https://aka.ms/new-console-template for more information
using NINAActivityBot;
using NINAActivityBot.Bots;
using NINAActivityBot.Social;
using NINAActivityBot.Social.Model;
using NINAActivityBot.Util;

Thread? MonitorImageThread = null;
Thread? NINAStatusThread = null;

Logger.Log("NINAActivityBot v" + Constants.Version);

Logger.Log("Starting threads");
MonitorImageBot bot1 = new MonitorImageBot();
MonitorImageThread = new Thread(() => bot1.Start(new BotConditionNinaIsRunning(Parameters.NINAURL))) { IsBackground = true };
MonitorImageThread.Start();

NINAStatusBot bot2 = new NINAStatusBot(Parameters.NINABaseURL);
NINAStatusThread = new Thread(() => bot2.Start(new BotConditionNinaIsRunning(Parameters.NINABaseURL))) { IsBackground = true };
NINAStatusThread.Start();

Logger.Log("Threads started");

Logger.Log("Press a key to exit");
System.Console.ReadKey();

Logger.Log("\nStopping threads...");
bot1.Stop = true;
bot2.Stop = true;