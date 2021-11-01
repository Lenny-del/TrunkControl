using Rage;
using System;
using System.Net;

namespace TrunkPlugin
{
    public class VersionCheck
    {
        public static bool isUpdateAvailable()
        {
            string curVersion = Settings.CalloutVersion;
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
            }
            if (receivedData != Settings.CalloutVersion)
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
                return true;
            }
            else
            {
                Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~TrunkPlugin", "", "Detected latest version of TrunkPlugin.<br>Installed Version: ~g~" + curVersion + "");
                return false;
            }
        }
    }
}