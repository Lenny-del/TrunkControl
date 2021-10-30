using System.Reflection;
using System.Windows.Forms;
using Rage;

namespace TrunkPlugin
{
    internal static class Settings
    {
        internal static Keys TrunkKey = Keys.T;
        internal static ControllerButtons TrunkButton = ControllerButtons.None;
        internal static readonly string CalloutVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        internal static void LoadSettings()
        {
            Game.LogTrivial("Loading TrunkPlugin config file");
            var path = "Plugins/TrunkPlugin/TrunkPlugin.ini";
            var ini = new InitializationFile(path);
            ini.Create();
            TrunkKey = ini.ReadEnum("Keys", "TurnOffEngine", Keys.T);
            TrunkButton = ini.ReadEnum<ControllerButtons>("Controller", "TurnOffEngine", ControllerButtons.None);
            Game.LogTrivial("TrunkPlugin: Config loaded.");
        }
    }
}