using Google.Protobuf.WellKnownTypes;
using GTANetworkAPI;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
using RageGW.Handler;
using RageGW.Modules.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;

namespace RageGW.Modules.Utils
{
    class Utils : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Logger.Write("Module: Utils geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Logger.Write("Module: Utils entladen", LoggerEnums.LogType.Info);
        }

        public static void SendPlayerNotify(Player player, string title, string message, string color, int time)
        {
            player.TriggerEvent("client:sendplayernotify", title, message, color, time);
        }

        public static void SendGlobalNotify(Player player, string title, string message, string color, int time)
        {
            player.TriggerEvent("client:sendglobalnotify", title, message, color, time);
        }

        public static int IntParseFast(string value)
        {
            // An optimized int parse method.
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = 10 * result + (value[i] - 48);
            }
            return result;
        }

        public static void ShowHud(Player player, int kills, int death, int level, int money)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            int killsanddeaths = accountPlayer.Kills + accountPlayer.Deaths;
            int kd = killsanddeaths / 2;

            //Open Hud and set all Data
            player.TriggerEvent("Hud:open", kills, death, kd, level, money);
        }

        public static void RefreshHud(Player player, int kills, int death, int level, int money)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            int killsanddeaths = accountPlayer.Kills + accountPlayer.Deaths;
            int kd = killsanddeaths / 2;

            //Refresh Hud and set all Data
            player.TriggerEvent("Hud:RefreshDataHud", kills, death, kd, level, money);
        }
        public static void ShowFFAbrowser(Player player)
        {
            player.TriggerEvent("Client:ffaBrowser:createBrowser");
        }

        public static void ShowProgressBar(Player player)
        {
            player.TriggerEvent("ProgressBar:open");

            NAPI.Task.Run(() =>
            {
                player.TriggerEvent("ProgressBar:close");
            }, delayTime: 4500);
        }

        public static void HideProgressBar(Player player)
        {
            player.TriggerEvent("ProgressBar:close");
        }

        public static void SetOwnWeaponComponent(Player player, WeaponHash weaponHash, WeaponComponent weaponComponent)
        {
            player.Eval($"mp.events.callRemote('giveWeaponComponent', '{(uint)weaponHash}', '{(uint)weaponComponent}');");
        }

        public static bool CanInteractAntiFlood(Player player, int seconds = 5)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (accountPlayer.LastInteracted.AddSeconds(seconds) > DateTime.Now)
            {
                SendPlayerNotify(player, "", "Bitte warte kurz!", "black", 8000);
                return false;
            }
            accountPlayer.LastInteracted = DateTime.Now;
            return true;
        }

        public static void GiveWeaponsArmorHealthToPlayer(Player player)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (accountPlayer.Kit == 0)
            {
                player.GiveWeapon(WeaponHash.Pistol_mk2, 9999);
                player.GiveWeapon(WeaponHash.Advancedrifle, 9999);
                player.GiveWeapon(WeaponHash.Bullpuprifle, 9999);
                player.GiveWeapon(WeaponHash.Specialcarbine, 9999);
                player.GiveWeapon(WeaponHash.Hatchet, 9999);
                player.GiveWeapon(WeaponHash.Gusenberg, 9999);

                player.Armor = 99;
                player.Health = 99;
                player.Dimension = 0;
            }

            else if (accountPlayer.Kit == 1)
            {
                player.GiveWeapon(WeaponHash.Pistol_mk2, 9999);
                player.GiveWeapon(WeaponHash.Advancedrifle, 9999);
                player.GiveWeapon(WeaponHash.Hatchet, 9999);

                player.Armor = 99;
                player.Health = 99;
            }

            else if (accountPlayer.Kit == 2)
            {
                player.GiveWeapon(WeaponHash.Pistol_mk2, 9999);
                player.GiveWeapon(WeaponHash.Bullpuprifle, 9999);
                player.GiveWeapon(WeaponHash.Hatchet, 9999);

                player.Armor = 99;
                player.Health = 99;
            }

            else if (accountPlayer.Kit == 3)
            {
                player.GiveWeapon(WeaponHash.Pistol_mk2, 9999);
                player.GiveWeapon(WeaponHash.Specialcarbine, 9999);
                player.GiveWeapon(WeaponHash.Hatchet, 9999);

                player.Armor = 99;
                player.Health = 99;
            }

            else if (accountPlayer.Kit == 4)
            {
                player.GiveWeapon(WeaponHash.Pistol_mk2, 9999);
                player.GiveWeapon(WeaponHash.Gusenberg, 9999);
                player.GiveWeapon(WeaponHash.Hatchet, 9999);

                player.Armor = 99;
                player.Health = 99;
            }
        }
    }
}
