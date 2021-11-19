using Rage;
using System.Windows.Forms;

namespace TrunkControl
{
    internal static class Settings
    {
        internal static Keys TrunkKey = Keys.T;
        internal static Keys MenuKey = Keys.F5;
        internal static ControllerButtons TrunkButton = ControllerButtons.None;
        internal static readonly string PluginVersion = "1.0";

        internal static void LoadSettings()
        {
            Game.Console.Print("Loading TrunkControl config file");
            var path = "Plugins/TrunkControl/TrunkControl.ini";
            var ini = new InitializationFile(path);
            ini.Create();
            TrunkKey = ini.ReadEnum("Keys", "TrunkKey", Keys.T);
            TrunkButton = ini.ReadEnum<ControllerButtons>("Controller", "TrunkButton", ControllerButtons.None);
            MenuKey = ini.ReadEnum("Keys", "MenuKey", Keys.F5);
            Game.Console.Print("TrunkControl Config loaded.");
        }
    }
}