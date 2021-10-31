using Rage;
using System;
using System.Net;
using System.Reflection;

namespace TrunkPlugin
{
    public static class Commands
    {
        [Rage.Attributes.ConsoleCommand("Reloads the TrunkPlugin ini file")]
        private static void ReloadTrunkPluginConfig()
        {
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
            Game.Console.Print();
            Game.Console.Print("Attempting to reload TrunkPlugin.ini");
            Settings.LoadSettings();
            Game.Console.Print("TrunkPlugin.ini has been reloaded succesfully");
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
            Game.Console.Print();
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ~o~by Vielfalt", "~w~TrunkPlugin.ini has been reloaded ~g~succesfully!");
        }

        [Rage.Attributes.ConsoleCommand("Displays latest and current version of TrunkPlugin")]
        private static void TrunkPluginCheckVersions()
        {
            string curVersion = Settings.CalloutVersion;
            Uri latestVersionuri = new Uri("https://github.com/Lenny-del/TrunkPlugin/");
            WebClient client = new WebClient();
            string receivedData = string.Empty;
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
            Game.Console.Print();
            Game.Console.Print("Current version:  " + curVersion);
            Game.Console.Print("New version:  " + receivedData);
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
            Game.Console.Print();
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ~o~by Vielfalt", "~w~Installed Version: ~g~" + curVersion + "<br>~w~Latest Version: ~r~" + receivedData + "");
        }
    }
}