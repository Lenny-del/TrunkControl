using System.Reflection;
using Rage;
using Rage.Attributes;

[assembly: Rage.Attributes.Plugin("OpenMyTrunk", Description = "Let's you open your trunk with 1 button click", Author = "Vielfalt")]
namespace OpenMyTrunk
{
    public class EntryPoint
    {
        public static void Main()
        {
            Settings.LoadSettings();
            OpenMyTrunk.Main.MainFiber();
            Game.LogTrivial("OpenMyTrunk" + Assembly.GetExecutingAssembly().GetName().Version + " by Vielfalt has been initialised.");
        }
    }
}