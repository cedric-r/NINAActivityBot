// See https://aka.ms/new-console-template for more information
using NINAActivityBot;
using NINAActivityBot.Bots;
using NINAActivityBot.Social;
using NINAActivityBot.Social.Model;
using NINAActivityBot.Util;

Logger.Log("Starting bots");
BotManager.Start();

Logger.Log("Press a key to exit");
System.Console.ReadKey();

Logger.Log("\nStopping bots...");

BotManager.Stop();