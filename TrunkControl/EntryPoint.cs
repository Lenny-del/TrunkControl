using Rage;
using Rage.Attributes;
using System;
using System.Net;

[assembly: Plugin("TrunkControl", Description = "Let's you open your trunk with 1 button click", Author = "Vielfalt")]
namespace TrunkControl
{
    public class EntryPoint
    {
        public static void Main()
        {
            string curVersion = Settings.PluginVersion;
            Uri latestVersionuri = new Uri("https://www.lcpdfr.com/applications/downloadsng/interface/api.php?do=checkForUpdates&fileId=36974&textOnly=1");
            WebClient client = new WebClient();
            string receivedData = string.Empty;
            Game.AddConsoleCommands();
            Settings.LoadSettings();
            TrunkControl.Main.MainFiber();
            Game.Console.Print("TrunkControl " + Settings.PluginVersion + " by Vielfalt has been initialised.");
            VersionCheck.isUpdateAvailable();
        }
    }
}