using System.Reflection;
using System.Windows.Forms;
using Rage;

namespace TrunkPlugin
{
    internal static class Settings
    {
        internal static Keys TrunkPluginKey = Keys.T;
        internal static ControllerButtons TrunkPluginButton = ControllerButtons.None;
        internal static readonly string CalloutVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        internal static void LoadSettings()
        {
            Game.LogTrivial("Loading TrunkPlugin config file");
            var path = "Plugins/TrunkPlugin/TrunkPlugin.ini";
            var ini = new InitializationFile(path);
            ini.Create();
            TrunkPluginKey = ini.ReadEnum("Keys", "TurnOffEngine", Keys.T);
            TrunkPluginButton = ini.ReadEnum<ControllerButtons>("Controller", "TrunkPlugin", ControllerButtons.None);
            Game.LogTrivial("TrunkPlugin: config loaded succesfully");
        }
    }
}