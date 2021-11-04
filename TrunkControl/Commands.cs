using Rage;

namespace TrunkControl
{
    public static class Commands
    {
        [Rage.Attributes.ConsoleCommand("Reloads the TrunkControl ini file")]
        private static void ReloadTrunkControlConfig()
        {
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkControl -------------------------------------");
            Game.Console.Print();
            Game.Console.Print("Attempting to reload TrunkControl.ini");
            Settings.LoadSettings();
            Game.Console.Print("TrunkControl.ini has been reloaded succesfully");
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkControl -------------------------------------");
            Game.Console.Print();
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "TrunkControl", "~y~v" + Settings.PluginVersion + " ~o~by Vielfalt", "~w~TrunkControl.ini has been reloaded ~g~succesfully!");
        }
    }
}