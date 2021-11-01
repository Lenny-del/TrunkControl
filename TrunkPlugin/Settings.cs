using Rage;
using System.Windows.Forms;

namespace TrunkPlugin
{
    internal static class Settings
    {
        internal static Keys TrunkKey = Keys.T;
        internal static ControllerButtons TrunkButton = ControllerButtons.None;
        internal static readonly string PluginVersion = "0.3";

        internal static void LoadSettings()
        {
            Game.Console.Print("Loading TrunkPlugin config file");
            var path = "Plugins/TrunkPlugin/TrunkPlugin.ini";
            var ini = new InitializationFile(path);
            ini.Create();
            TrunkKey = ini.ReadEnum("Keys", "TrunkKey", Keys.T);
            TrunkButton = ini.ReadEnum<ControllerButtons>("Controller", "TrunkButton", ControllerButtons.None);
            Game.Console.Print("TrunkPlugin: Config loaded.");
        }
    }
}