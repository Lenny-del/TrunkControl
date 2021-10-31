using Rage;

namespace TrunkPlugin
{
    public static class Commands
    {
        [Rage.Attributes.ConsoleCommand("Reloads the TrunkPlugin ini file")]
        private static void ReloadTrunkPluginConfig()
        {
            Game.Console.Print("Attempting to reload TrunkPlugin.ini");
            Settings.LoadSettings();
            Game.Console.Print("Reloading TrunkPlugin.ini");
            Game.Console.Print("TrunkPlugin.ini has been reloaded succesfully");
        }
    }
}