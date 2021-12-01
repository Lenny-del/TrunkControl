using Rage;
using System;

namespace TrunkControl
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
                        if (Game.IsKeyDown(Settings.TrunkKey) || Game.IsControllerButtonDown(Settings.TrunkButton))
                        {
                            if (Game.LocalPlayer.Character.IsInAnyVehicle(false) && Game.LocalPlayer.Character.CurrentVehicle && Game.LocalPlayer.Character.CurrentVehicle.Speed < 2f)
                            {
                                VehicleDoor[] door = Game.LocalPlayer.Character.CurrentVehicle.GetDoors();
                                if (!door[door.Length - 1].IsOpen) door[door.Length - 1].Open(false);
                                else if (door[door.Length - 1].IsOpen) door[door.Length - 1].Close(false);
                            }
                            else Game.DisplayHelp("~y~Your current speed is too high or you aren't in your vehicle!", 3500);
                        }
                        else if (Game.IsKeyDown(Settings.TrunkKey) || Game.IsControllerButtonDown(Settings.TrunkButton))
                        {
                            if (Game.LocalPlayer.Character.IsInAnyVehicle(true))
                            {
                                VehicleDoor[] door = Game.LocalPlayer.Character.CurrentVehicle.GetDoors();
                                if (!door[door.Length - 1].IsOpen) door[door.Length - 1].Open(true);
                                else if (door[door.Length - 1].IsOpen) door[door.Length - 1].Close(true);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Game.Console.Print();
                        Game.Console.Print("------------------------------------- TrunkControl [WARNING] -------------------------------------");
                        Game.Console.Print();
                        Game.Console.Print("My eyes spotted an error here...");
                        Game.Console.Print("TrunkControl Error. Please report any issues here: https://discord.gg/rR6Hq8WKcm");
                        Game.Console.Print();
                        Game.Console.Print(e.ToString());
                        Game.Console.Print();
                        Game.Console.Print("------------------------------------- TrunkControl [WARNING] -------------------------------------");
                        Game.Console.Print();
                    }
                }
            });
            process.Start();
        }
    }
}