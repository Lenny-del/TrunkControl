using Rage;
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
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ~o~by Vielfalt", "~b~TrunkPlugin.ini has been reloaded succesfully!");
        }
    }
}