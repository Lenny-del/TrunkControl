using Rage;
using System;

namespace TrunkPlugin
{
    internal class Main
    {
        /*public static Ped MainPlayer => Game.LocalPlayer.Character;
        static Rage.Object KeyProp;
        static bool DoesKeyExist => KeyProp && KeyProp.IsValid();
        */
        internal static void MainFiber()
        {
            var process = new GameFiber(delegate
            {
                while (true)
                {
                    GameFiber.Yield();
                    /* if (Game.IsKeyDown(Settings.TrunkKey) || Game.IsControllerButtonDown(Settings.TrunkButton))
                    {
                        if (!DoesKeyExist)
                        {
                            KeyProp = new Rage.Object("p_car_keys_01", MainPlayer.Position) { IsPersistent = true };
                        }
                        AnimationTask CarKeyClick = MainPlayer.Tasks.PlayAnimation("anim@mp_player_intmenu@key_fob@", "fob_click", 1f, AnimationFlags.SecondaryTask | AnimationFlags.UpperBodyOnly);
                        //For the offset and rotation, use Menyoo object spawner, find the object you need and use the attachment + manual placement feature
                        KeyProp.AttachTo(MainPlayer, MainPlayer.GetBoneIndex(PedBoneId.RightHand), new Vector3(0.1400f, 0.0400f, 0.0100f), new Rotator(4.2500f, 1.4400f, 2.4600f));
                        while (CarKeyClick.IsActive)
                        {
                            GameFiber.Yield();
                        }
                        if (DoesKeyExist)
                        {
                            KeyProp.Delete();
                        }
                    }
                    */
                    try
                    {
                        if (Game.IsKeyDown(Settings.TrunkKey) || Game.IsControllerButtonDown(Settings.TrunkButton))
                        {
                            if (Game.LocalPlayer.Character.IsInAnyVehicle(false))
                            {
                                VehicleDoor[] door = Game.LocalPlayer.Character.CurrentVehicle.GetDoors();
                                if (!door[door.Length - 1].IsOpen) door[door.Length - 1].Open(false);
                                else if (door[door.Length - 1].IsOpen) door[door.Length - 1].Close(false);

                            }
                            else Game.DisplayHelp("~r~You are not in your vehicle!", 3000);

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
                        Game.LogTrivial("My eyes spotted an error here...");
                        Game.LogTrivial("TrunkPlugin Error. Please report any issues here: https://discord.gg/rR6Hq8WKcm");
                        Game.LogTrivial("------------------------------------------------------");
                        Game.LogTrivial(e.ToString());
                        Game.LogTrivial("------------------------------------------------------");
                        Game.LogTrivial("TrunkPlugin Error End");
                    }
                }
            });
            process.Start();
        }
    }
}
