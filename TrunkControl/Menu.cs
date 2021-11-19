using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using RAGENativeUI.PauseMenu;

namespace TrunkControl
{
    public class RNUIMenu
    {
        internal static UIMenu UIone;
        internal static MenuPool Menuone;
        internal static UIMenuItem _Item1;
        internal static UIMenuItem _Item2;

        public static void LoadMenu()
        {
            UIone = new UIMenu($"~y~TrunkControl", $"~y~TrunkControl ~w~Menu ~o~by Vielfalt ~y~v {Settings.PluginVersion}");
            Menuone = new MenuPool();
            _Item1 = new UIMenuItem("Grab Fire Extinguisher");
            _Item2 = new UIMenuItem("Store Fire Extinguisher");

            Menuone.Add(UIone);
            UIone.AddItem(_Item1);


            GameFiber.StartNew(delegate
            {
                while (true)
                {
                    Menuone.ProcessMenus();

                    if (Game.IsKeyDown(Settings.MenuKey))
                    {
                        if (UIone.Visible)
                        {
                            UIone.Visible = false;
                        }
                        else if (!UIMenu.IsAnyMenuVisible && !TabView.IsAnyPauseMenuVisible)
                        {
                            UIone.Visible = true;
                        }
                        UIone.OnItemSelect += Test;
                    }
                    GameFiber.Yield();
                }
            });
        }
        public static void Test(UIMenu Sender, UIMenuItem SelectedItem, int index)
        {
            if (SelectedItem == _Item1)
            {
                {
                    Game.LocalPlayer.Character.Inventory.GiveNewWeapon("weapon_fireextinguisher", 100, true);
                    Game.DisplayNotification("You grabbed your Fire Extinguisher");
                }
                UIone.AddItem(_Item2);
                UIone.RemoveItemAt(0);
                UIone.RefreshIndex();
                UIone.Visible = false;                                                      //Make Menu disappear after button press, add code (ex. Grab extinguisher) in if (SelectedItem == ItemXY

            }

            if (SelectedItem == _Item2)
            {
                if (Game.LocalPlayer.Character.Inventory.Weapons.Contains("weapon_fireextinguisher"))
                {
                    Game.LocalPlayer.Character.Inventory.Weapons.Remove("weapon_fireextinguisher");
                    Game.DisplayNotification("You stored your Fire Extinguisher");
                }
                UIone.AddItem(_Item1);
                UIone.RemoveItemAt(0);
                UIone.RefreshIndex();
                UIone.Visible = false;

            }
        }
    }
}