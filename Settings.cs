using System.Reflection;
using System.Windows.Forms;
using Rage;

namespace OpenMyTrunk
{
    internal static class Settings
    {
        internal static Keys OpenMyTrunkKey = Keys.T;
        internal static ControllerButtons OpenMyTrunkButton = ControllerButtons.None;
        internal static readonly string CalloutVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        internal static void LoadSettings()
        {
            Game.LogTrivial("Loading OpenMyTrunk config file");
            var path = "Plugins/OpenMyTrunk/OpenMyTrunk.ini";
            var ini = new InitializationFile(path);
            ini.Create();
            OpenMyTrunkKey = ini.ReadEnum("Keys", "TurnOffEngine", Keys.T);
            OpenMyTrunkButton = ini.ReadEnum<ControllerButtons>("Controller", "OpenMyTrunk", ControllerButtons.None);
            Game.LogTrivial("OpenMyTrunk: config loaded succesfully");
        }
    }
}