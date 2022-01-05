using Rage;
using System.Windows.Forms;

namespace TrunkControl
{
    internal static class Settings
    {
        internal static Keys TrunkKey = Keys.T;
        internal static Keys MenuKey = Keys.F5;
        internal static ControllerButtons TrunkButton = ControllerButtons.None;
        internal static ControllerButtons MenuButton = ControllerButtons.None;
        internal static readonly string PluginVersion = "1.3";

        internal static void LoadSettings()
        {
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkControl -------------------------------------");
            Game.Console.Print();
            Game.Console.Print("Loading TrunkControl config file");
            var path = "Plugins/TrunkControl/TrunkControl.ini";
            var ini = new InitializationFile(path);
            ini.Create();
            TrunkKey = ini.ReadEnum("Keys", "TrunkKey", Keys.T);
            TrunkButton = ini.ReadEnum<ControllerButtons>("Controller", "TrunkButton", ControllerButtons.None);
            MenuKey = ini.ReadEnum("Keys", "MenuKey", Keys.F5);
            MenuButton = ini.ReadEnum<ControllerButtons>("Controller", "MenuButton", ControllerButtons.None);
            Game.Console.Print("TrunkControl Config loaded.");
        }
    }
}