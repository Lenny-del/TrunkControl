using Rage;

namespace TrunkPlugin
{
    public static class Commands
    {
        [Rage.Attributes.ConsoleCommand("Reloads the TrunkPlugin ini file")]
        private static void ReloadTrunkPluginConfig()
        {
            Game.LogTrivial("Attempting to reload TrunkPlugin.ini");
            Settings.LoadSettings();
            Game.LogTrivial("Reloading TrunkPlugin.ini");
            Game.LogTrivial("TrunkPlugin.ini has been reloaded succesfully");
        }
    }
}