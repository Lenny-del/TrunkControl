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
            InitializationFile initializationFile = new InitializationFile("Plugins/TrunkPlugin/TrunkPlugin.ini");
            initializationFile.Create();
            TrunkPluginKey = initializationFile.ReadEnum("Keys", "TrunkPlugin", Keys.T);
            TrunkPluginButton = initializationFile.ReadEnum<ControllerButtons>("Controller", "TrunkPlugin", ControllerButtons.None);
            Game.LogTrivial("TrunkPlugin: Config loaded.");
        }
    }
}