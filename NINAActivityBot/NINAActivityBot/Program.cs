// See https://aka.ms/new-console-template for more information
using NINAActivityBot;
using NINAActivityBot.Bots;
using NINAActivityBot.Social;
using NINAActivityBot.Social.Model;

Thread? MonitorImageThread = null;
Thread? NINAStatusThread = null;

Console.WriteLine("Starting threads");
MonitorImageBot bot1 = new MonitorImageBot();
MonitorImageThread = new Thread(() => bot1.Start(new BotConditionNinaIsRunning(Constants.NINAURL))) { IsBackground = true };
MonitorImageThread.Start();

NINAStatusBot bot2 = new NINAStatusBot(Constants.NINABaseURL);
NINAStatusThread = new Thread(() => bot2.Start(new BotConditionNinaIsRunning(Constants.NINABaseURL))) { IsBackground = true };
NINAStatusThread.Start();

Console.WriteLine("Threads started");

Console.WriteLine("Press a key to exit");
System.Console.ReadKey();

Console.WriteLine("\nStopping threads...");
bot1.Stop = true;
bot2.Stop = true;