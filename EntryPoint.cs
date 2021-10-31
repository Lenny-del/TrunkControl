using System.Reflection;
using Rage;
using Rage.Attributes;

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


        public static class Commands
        {
            [Rage.Attributes.ConsoleCommand("This is a test.")]
            public static void Test()
            {
                Game.LogTrivial("This is a test.");
                Game.Console.Print("This is another test.");
            }
        }
    }
}