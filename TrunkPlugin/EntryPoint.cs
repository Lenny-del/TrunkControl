﻿using Rage;
using Rage.Attributes;
using System;
using System.Net;
using System.Reflection;

[assembly: Plugin("TrunkPlugin", Description = "Let's you open your trunk with 1 button click", Author = "Vielfalt")]
namespace TrunkPlugin
{
    public class EntryPoint
    {
        public static void Main()
        {
            string curVersion = Settings.CalloutVersion;
            Uri latestVersionuri = new Uri("https://github.com/Lenny-del/TrunkPlugin/");
            WebClient client = new WebClient();
            string receivedData = string.Empty;
            Game.AddConsoleCommands();
            Settings.LoadSettings();
            TrunkPlugin.Main.MainFiber();
            Game.Console.Print("TrunkPlugin " + Assembly.GetExecutingAssembly().GetName().Version + " by Vielfalt has been initialised.");
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ~o~by Vielfalt", "~w~Latest version: ~r~" + receivedData + "<br>~w~Loaded ~g~succesfully!");
            VersionCheck.isUpdateAvailable();
        }
    }
}