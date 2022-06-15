using Rage;
using System;
using System.Net;

namespace TrunkControl
{
    public class VersionCheck
    {
        public static bool IsUpdateAvailable()
        {
            string curVersion = Settings.PluginVersion;
            Uri latestVersionUri = new Uri("https://www.lcpdfr.com/applications/downloadsng/interface/api.php?do=checkForUpdates&fileId=36974&textOnly=1");
            WebClient webClient = new WebClient();
            string receivedData = string.Empty;
            try
            {
                receivedData = webClient.DownloadString(latestVersionUri).Trim();
            }
            catch (WebException)
            {
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkControl [WARNING] -------------------------------------");
                Game.Console.Print();
                Game.Console.Print("[WARNING] Failed to check for an update.");
                Game.Console.Print("[WARNING] Please make sure you are online or try to reload the plugin.");
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkControl [WARNING] -------------------------------------");
                Game.Console.Print();
                Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkControl", "~y~v" + Settings.PluginVersion + " ~o~by Lenny", "~r~Couldn't check for latest version! <br>~w~Please make sure you are ~y~connected ~w~to the internet or ~y~reload ~w~the plugin.");
                return false;
            }
            if (receivedData != Settings.PluginVersion)
            {
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkControl [WARNING] -------------------------------------");
                Game.Console.Print();
                Game.Console.Print("[WARNING] A new version of TrunkControl is available. Please update to the latest build.");
                Game.Console.Print("[WARNING] Current version:  " + curVersion);
                Game.Console.Print("[WARNING] New version:  " + receivedData);
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkControl [WARNING] -------------------------------------");
                Game.Console.Print();
                Game.DisplayNotification("commonmenu", "mp_alerttriangle", "~w~TrunkControl Warning", "~y~A new Update is available!", "Current Version: ~r~" + curVersion + "~w~<br>New Version: ~g~" + receivedData + "<br>~r~Please update to the latest version!");
                return true;
            }
            else
            {
                Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkControl", "~y~v" + Settings.PluginVersion + " ~o~by Lenny", "~w~Detected ~g~latest ~w~version of ~y~TrunkControl!");
                return false;
            }
        }
    }
}