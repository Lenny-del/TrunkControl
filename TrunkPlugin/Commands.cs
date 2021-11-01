using Rage;

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
            Game.DisplayNotification("char_default", "web_lossantospolicedept", "TrunkPlugin", "~y~v" + Settings.PluginVersion + " ~o~by Vielfalt", "~w~TrunkPlugin.ini has been reloaded ~g~succesfully!");
        }
    }
}