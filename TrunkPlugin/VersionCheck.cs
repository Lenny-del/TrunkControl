using Rage;
using System;
using System.Net;

namespace TrunkPlugin
{
    public class VersionCheck
    {
        public static bool isUpdateAvailable()
        {
            string curVersion = Settings.PluginVersion;
            Uri latestVersionuri = new Uri("https://www.lcpdfr.com/applications/downloadsng/interface/api.php?do=checkForUpdates&fileId=29933&textOnly=1");
            WebClient client = new WebClient();
            string receivedData = string.Empty;
            try
            {
                receivedData = client.DownloadString("https://www.lcpdfr.com/applications/downloadsng/interface/api.php?do=checkForUpdates&fileId=29933&textOnly=1").Trim();
            }
            catch (WebException)
            {
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                Game.Console.Print("[WARNING] Failed to check for an update.");
                Game.Console.Print("[WARNING] Please make sure you are online or try to reload the plugin.");
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                Game.DisplayNotification("char_default", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Settings.PluginVersion + " ~o~by Vielfalt", "~r~Couldn't check for latest version! <br>~w~Please make sure you are ~y~connected ~w~to the internet or ~y~reload ~w~the plugin.");
                return false;
            }
            if (receivedData != Settings.PluginVersion)
            {
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                Game.Console.Print("[WARNING] A new version of TrunkPlugin is available. Please update to the latest build.");
                Game.Console.Print("[WARNING] Current version:  " + curVersion);
                Game.Console.Print("[WARNING] New version:  " + receivedData);
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                Game.DisplayNotification("commonmenu", "mp_alerttriangle", "~w~TrunkPlugin Warning", "~y~A new Update is available!", "Current Version: ~r~" + curVersion + "~w~<br>New Version: ~g~" + receivedData + "<br>~r~Please update to the latest version!");
                return true;
            }
            else
            {
                Game.DisplayNotification("char_default", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Settings.PluginVersion + " ~o~by Vielfalt", "~w~Detected ~g~latest ~w~version of ~y~TrunkPlugin!");
                return false;
            }
        }
    }
}