using Rage;
using Rage.Attributes;
using System;
using System.Net;

[assembly: Plugin("TrunkControl", Description = "Let's you open your trunk with 1 button click", Author = "Vielfalt")]
namespace TrunkControl
{
    public class EntryPoint
    {
        public static void Main()
        {
            Game.AddConsoleCommands();
            Settings.LoadSettings();
            TrunkControl.Main.MainFiber();
            TrunkControl.RNUIMenu.LoadMenu();
            Game.Console.Print("TrunkControl " + Settings.PluginVersion + " by Vielfalt has been initialised.");
            Game.Console.Print("TrunkControl TrunkKey: " + Settings.TrunkKey);
            Game.Console.Print("TrunkControl TrunkButton: " + Settings.TrunkButton);
            Game.Console.Print("TrunkControl MenuKey: " + Settings.MenuKey);
            Game.Console.Print("TrunkControl MenuButton: " + Settings.MenuButton);
            Game.Console.Print();
            Game.Console.Print("------------------------------------- TrunkControl -------------------------------------");
            Game.Console.Print();
            VersionCheck.isUpdateAvailable();
        }
    }
}