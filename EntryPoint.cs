using Rage;
using Rage.Attributes;
using System.Reflection;

[assembly: Plugin("TrunkPlugin", Description = "Let's you open your trunk with 1 button click", Author = "Vielfalt")]
namespace TrunkPlugin
{
    public class EntryPoint
    {
        public static void Main()
        {
            Game.AddConsoleCommands();
            Settings.LoadSettings();
            TrunkPlugin.Main.MainFiber();
            Game.LogTrivial("TrunkPlugin " + Assembly.GetExecutingAssembly().GetName().Version + " by Vielfalt has been initialised.");
        }
    }
}