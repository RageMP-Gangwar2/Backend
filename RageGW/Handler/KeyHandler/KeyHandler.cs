using GTANetworkAPI;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageGW.Handler.KeyHandler
{
    class KeyHandler : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: KeyHandler geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: KeyHandler entladen", LoggerEnums.LogType.Info);
        }

        [RemoteEvent("Server:Key:E")]
        public void Key_E(Player player)
        {
            if (player.IsInVehicle) return;
            if (player.HasData("isDead")) return;

            if (player.Position.DistanceTo(new Vector3(-1539.158f, 858.36365f, 181.50923f)) < 3.0f) // YakuZa Mafia
            {
                player.TriggerEvent("Client:garageBrowser:createBrowser");
            }

            if (player.Position.DistanceTo(new Vector3(1367.2704f, -580.9736f, 74.380455f)) < 3.0f) // Grove Street Families
            {
                player.TriggerEvent("Client:garageBrowser:createBrowser");
            }

            if (player.Position.DistanceTo(new Vector3(1419.9716f, 3618.0981f, 34.910378f)) < 3.0f) // Varrios Los Aztecas
            {
                player.TriggerEvent("Client:garageBrowser:createBrowser");
            }

            if (player.Position.DistanceTo(new Vector3(1273.7133f, -1587.2535f, 52.446854f)) < 3.0f) // 52 Hxxver Crips
            {
                player.TriggerEvent("Client:garageBrowser:createBrowser");
            }

            if (player.Position.DistanceTo(new Vector3(-1523.2712f, 85.83939f, 56.474106f)) < 3.0f) // La Cosa Nostra
            {
                player.TriggerEvent("Client:garageBrowser:createBrowser");
            }

            if (player.Position.DistanceTo(new Vector3(102.868164f, -1942.1025f, 20.803722f)) < 3.0f) // Davis Braxton Ballas
            {
                player.TriggerEvent("Client:garageBrowser:createBrowser");
            }

            if (player.Position.DistanceTo(new Vector3(21.019781f, -1106.6901f, 29.7854f)) < 3.0f) // AufsatzShop
            {
                player.TriggerEvent("Client:aufsatzBrowser:createBrowser");
            }

            // Abbrechen Weste
            if (player.HasData("ZiehtWeste"))
            {
                player.SetData("ZiehtWesteAbgebrochen", true);

                player.StopAnimation();
                Utils.HideProgressBar(player);
                Utils.SendPlayerNotify(player, "", "Schutzweste ziehen Abgebrochen!", "green", 8000);
                player.ResetData("ZiehtWeste");
            }

            // Abbrechen Medikit
            if (player.HasData("ZiehtMedikit"))
            {
                player.SetData("ZiehtMedikitAbgebrochen", true);

                player.StopAnimation();
                Utils.HideProgressBar(player);
                Utils.SendPlayerNotify(player, "", "Medikit ziehen Abgebrochen!", "green", 8000);
                player.ResetData("ZiehtMedikit");
            }
        }

        [RemoteEvent("Server:HotkeyPunkt:Armor")]
        public void HotkeyPunktArmor(Player player)
        {
            if (player.IsInVehicle) return;
            if (player.HasData("isDead")) return;

            if (!Utils.CanInteractAntiFlood(player, 3)) return;

            Utils.ShowProgressBar(player);
            player.PlayAnimation("anim@heists@narcotics@funding@gang_idle", "gang_chatting_idle01", 3);
            player.SetData("ZiehtWeste", true);

            NAPI.Task.Run(() =>
            {
                if (player.HasData("ZiehtWesteAbgebrochen"))
                {
                    player.ResetData("ZiehtWesteAbgebrochen");
                    return;
                }
                else
                {
                    player.Armor = 99;
                    player.StopAnimation();
                    Utils.SendPlayerNotify(player, "", "Du hast dir erfolgreich eine Schutzweste gezogen!", "green", 8000);
                    player.ResetData("ZiehtWeste");
                    player.ResetData("ZiehtWesteAbgebrochen");
                }
            }, delayTime: 4500);
        }

        [RemoteEvent("Server:HotkeyKomma:Health")]
        public void HotkeyKommaHealth(Player player)
        {
            if (player.IsInVehicle) return;
            if (player.HasData("isDead")) return;

            if (!Utils.CanInteractAntiFlood(player, 3)) return;

            Utils.ShowProgressBar(player);
            player.PlayAnimation("amb@medic@standing@tendtodead@idle_a", "idle_a", 3);
            player.SetData("ZiehtMedikit", true);

            NAPI.Task.Run(() =>
            {
                if (player.HasData("ZiehtMedikitAbgebrochen"))
                {
                    player.ResetData("ZiehtMedikitAbgebrochen");
                    return;
                }
                else
                {
                    player.Health = 99;
                    player.StopAnimation();
                    Utils.SendPlayerNotify(player, "", "Du hast dir erfolgreich ein Medikit gezogen!", "green", 8000);
                    player.ResetData("ZiehtMedikit");
                    player.ResetData("ZiehtMedikitAbgebrochen");
                }
            }, delayTime: 4500);
        }

        [RemoteEvent("Server:Key:F4")]
        public void Key_F4(Player player)
        {
            if (player.HasData("isDead")) return;

            if (!Utils.CanInteractAntiFlood(player, 8)) return;

            if (player.IsInVehicle || player.VehicleSeat == 1)
            {
                Utils.ShowProgressBar(player);

                NAPI.Task.Run(() =>
                {
                    if (player.Vehicle == null)
                    {
                        Utils.SendPlayerNotify(player, "", "Reparieren abgebrochen Fahrzeug wurde Verlassen oder nicht Gefunden!", "red", 8000);
                        return;
                    }
                    else
                    {
                        player.Vehicle.Repair();
                        Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich Repariert!", "green", 8000);
                    }
                }, delayTime: 4500);
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du sitzt in keinem Fahrzeug das du Reparieren kannst oder sitzt nicht auf dem Fahrersitz!", "red", 8000);
                return;
            }
        }

        [RemoteEvent("Server:Key:F5")]
        public void HotkeyPunktF5(Player player)
        {
            if (player.IsInVehicle) return;
            if (player.HasData("isDead")) return;

            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)Accounts.AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            if (player.HasData("isAduty"))
            {
                player.ResetData("isAduty");
                player.TriggerEvent("Client:Admin:setAdutyOff");

                Utils.SendPlayerNotify(player, "", "Aduty - Deaktiviert", "red", 8000);

                if (player.HasData("team1"))
                {
                    player.SetSkin(PedHash.FreemodeMale01);

                    //Weapons and some other stuff
                    Utils.GiveWeaponsArmorHealthToPlayer(player);

                    player.Armor = 99;
                    player.Health = 99;

                    player.SetClothes(1, 111, 5); // Maske
                    player.SetClothes(4, 24, 4); //Hose
                    player.SetClothes(11, 134, 1); // Oberteil
                    player.SetClothes(8, 15, 0); // Undershirt
                    player.SetClothes(6, 34, 0); // Schuhe
                    player.SetClothes(3, 4, 0); //Torso
                    player.SetClothes(9, 16, 2); // Weste
                    player.SetAccessories(0, 30, 0); // Hut
                    player.SetAccessories(1, 3, 0); // Brille
                }

                if (player.HasData("team2"))
                {
                    player.SetSkin(PedHash.FreemodeMale01);

                    //Weapons and some other stuff
                    Utils.GiveWeaponsArmorHealthToPlayer(player);

                    player.Armor = 99;
                    player.Health = 99;


                    player.SetClothes(1, 118, 0); // Maske
                    player.SetClothes(4, 5, 6); //Hose
                    player.SetClothes(11, 305, 7); // Oberteil
                    player.SetClothes(8, 15, 0); // Undershirt
                    player.SetClothes(6, 6, 0); // Schuhe
                    player.SetClothes(3, 4, 0); //Torso
                    player.SetClothes(9, 16, 2); // weste
                    player.SetAccessories(1, 3, 0); // Brille
                    player.SetAccessories(0, -1, 0); // Hut
                }

                if (player.HasData("team3"))
                {
                    player.SetSkin(PedHash.FreemodeMale01);

                    //Weapons and some other stuff
                    Utils.GiveWeaponsArmorHealthToPlayer(player);

                    player.Armor = 99;
                    player.Health = 99;

                    player.SetClothes(1, 54, 0);
                    player.SetClothes(4, 5, 3);
                    player.SetClothes(11, 134, 2);
                    player.SetClothes(8, 15, 0);
                    player.SetClothes(6, 34, 0);
                    player.SetClothes(3, 1, 0);
                    player.SetClothes(9, 16, 2);
                    player.SetAccessories(1, 3, 0); // Brille
                    player.SetAccessories(0, -1, 0); // Hut
                }

                if (player.HasData("team4"))
                {
                    player.SetSkin(PedHash.FreemodeMale01);

                    //Weapons and some other stuff
                    Utils.GiveWeaponsArmorHealthToPlayer(player);

                    player.Armor = 99;
                    player.Health = 99;

                    player.SetClothes(1, 118, 1); // Maske
                    player.SetClothes(4, 5, 7); //Hose
                    player.SetClothes(11, 96, 0); // Oberteil
                    player.SetClothes(8, 15, 0); // Undershirt
                    player.SetClothes(6, 34, 0); // Schuhe
                    player.SetClothes(3, 4, 0); //Torso
                    player.SetClothes(9, 16, 2); // weste
                    player.SetAccessories(1, 3, 0); // Brille
                    player.SetAccessories(0, -1, 0); // Hut
                }

                if (player.HasData("team5"))
                {
                    player.SetSkin(PedHash.FreemodeMale01);

                    //Weapons and some other stuff
                    Utils.GiveWeaponsArmorHealthToPlayer(player);

                    player.Armor = 99;
                    player.Health = 99;

                    player.SetClothes(1, 111, 17); // Maske
                    player.SetClothes(4, 24, 0); //Hose
                    player.SetClothes(11, 111, 3); // Oberteil
                    player.SetClothes(8, 15, 0); // Undershirt
                    player.SetClothes(6, 34, 0); // Schuhe
                    player.SetClothes(3, 12, 0); //Torso
                    player.SetClothes(9, 16, 2); // weste
                    player.SetAccessories(0, 12, 0); // Hut
                    player.SetAccessories(1, 3, 0); // Brille
                }

                if (player.HasData("team6"))
                {
                    player.SetSkin(PedHash.FreemodeMale01);

                    //Weapons and some other stuff
                    Utils.GiveWeaponsArmorHealthToPlayer(player);

                    player.Armor = 99;
                    player.Health = 99;

                    player.SetClothes(1, 118, 2);
                    player.SetClothes(4, 5, 9);
                    player.SetClothes(11, 111, 3);
                    player.SetClothes(8, 15, 0);
                    player.SetClothes(6, 34, 0);
                    player.SetClothes(3, 4, 0);
                    player.SetClothes(9, 16, 2);
                    player.SetAccessories(1, 3, 0); // Brille
                    player.SetAccessories(0, -1, 0); // Hut
                }
            }
            else
            {
                player.SetData("isAduty", true);
                player.TriggerEvent("Client:Admin:setAdutyOn");

                Utils.SendPlayerNotify(player, "", "Aduty - Aktiviert", "green", 8000);

                player.RemoveAllWeapons();
                player.SetSkin(PedHash.MovAlien01);
            }
        }

        [RemoteEvent("Server:Key:F6")]
        public void HotkeyPunktF6(Player player)
        {
            if (player.IsInVehicle) return;
            if (player.HasData("isDead")) return;

            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)Accounts.AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            if (player.HasData("isAduty"))
            {
                if (!player.HasData("noclipon"))
                {
                    player.SetData("noclipon", true);
                    player.SetData("noclipon", true);
                    player.TriggerEvent("toggleNoClip", true);
                    player.Transparency = 0;
                    Utils.SendPlayerNotify(player, "", "Noclip: Aktiviert!", "green", 8000);

                }
                else
                {
                    player.TriggerEvent("toggleNoClip", false);
                    player.ResetData("noclipon");
                    player.Transparency = 255;
                    Utils.SendPlayerNotify(player, "", "Noclip: Deaktiviert!", "red", 8000);
                }
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du bist nicht im Aduty!", "red", 8000);
            }
        }


        [RemoteEvent("Server:Key:F7")]
        public void HotkeyPunktF7(Player player)
        {
            if (player.IsInVehicle) return;
            if (player.HasData("isDead")) return;

            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)Accounts.AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            if (player.HasData("isAduty")) 
            {
                if (!player.HasData("vanishon"))
                {
                    player.SetData("vanishon", true);
                    player.Transparency = 0;
                    Utils.SendPlayerNotify(player, "", "Vanish: Aktiviert!", "green", 8000);
                }
                else
                {
                    player.ResetData("vanishon");
                    player.Transparency = 255;
                    Utils.SendPlayerNotify(player, "", "Vanish: Deaktiviert!", "red", 8000);
                }
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du bist nicht im Aduty!", "red", 8000);
            }
        }
    }
}
