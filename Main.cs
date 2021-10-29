using System;
using Rage;
using Rage.Native;

namespace OpenMyTrunk
{
    internal class Main
    {
        internal static void MainFiber()
        {
            var process = new GameFiber(delegate
            {
                while (true)
                {
                    GameFiber.Yield();
                    try
                    {
                        if ((Game.IsKeyDown(Settings.OpenMyTrunkKey) || Game.IsControllerButtonDown(Settings.OpenMyTrunkButton)))
                        {
                            if (Game.LocalPlayer.Character.IsInAnyVehicle(false))
                            {
                                VehicleDoor[] door = Game.LocalPlayer.Character.CurrentVehicle.GetDoors();
                                if (!door[door.Length - 1].IsOpen) door[door.Length - 1].Open(false);
                                else if (door[door.Length - 1].IsOpen) door[door.Length - 1].Close(false);
                            }
                            else Game.DisplayHelp("You are not in your vehicle!", 3000);

                        }
                        else if (Game.IsControlPressed(0, GameControl.VehicleAccelerate))
                        {
                            VehicleDoor[] door = Game.LocalPlayer.Character.CurrentVehicle.GetDoors();
                            if (!door[door.Length - 1].IsOpen) door[door.Length - 1].Open(true);
                            else if (door[door.Length - 1].IsOpen) door[door.Length - 1].Close(true);
                        }
                    }
                    catch (Exception e)
                    {
                        Game.LogTrivial("My eyes spotted an error here...");
                        Game.LogTrivial("OpenMyTrunk Error Start. Please report any issues here: https://discord.gg/rR6Hq8WKcm");
                        Game.LogTrivial("======================================================");
                        Game.LogTrivial(e.ToString());
                        Game.LogTrivial("======================================================");
                        Game.LogTrivial("OpenMyTrunk Error End");
                    }
                }
            });
            process.Start();
        }
    }
}
