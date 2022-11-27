using GTANetworkAPI;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509;
using RageGW.Modules.Database;
using RageGW.Modules.DiscordWebhook;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RageGW.Handler.AntiCheatHandler
{
    class AntiCheatHandler : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: AntiCheatHandler geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: AntiCheatHandler entladen", LoggerEnums.LogType.Info);
        }

        //Blacklisted Weapons
        [ServerEvent(Event.PlayerWeaponSwitch)]
        public void playerWeaponSwitch(Player player, WeaponHash oldWeapon, WeaponHash newWeapon)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (accountPlayer.Adminlevel >= 3) return;

            //Rpg
            if (oldWeapon == WeaponHash.Rpg)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Rpg]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rpg]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rpg]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Rpg
            if (newWeapon == WeaponHash.Rpg)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Rpg]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rpg]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rpg]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Grenadelauncher
            if (oldWeapon == WeaponHash.Grenadelauncher)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Grenadelauncher]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Grenadelauncher
            if (newWeapon == WeaponHash.Grenadelauncher)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Grenadelauncher]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Grenadelauncher_smoke
            if (oldWeapon == WeaponHash.Grenadelauncher_smoke)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Grenadelauncher_smoke]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher_smoke]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher_smoke]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Grenadelauncher_smoke
            if (newWeapon == WeaponHash.Grenadelauncher_smoke)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Grenadelauncher_smoke]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher_smoke]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenadelauncher_smoke]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Minigun
            if (oldWeapon == WeaponHash.Minigun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Minigun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Minigun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Minigun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Minigun
            if (newWeapon == WeaponHash.Minigun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Minigun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Minigun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Minigun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Firework
            if (oldWeapon == WeaponHash.Firework)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Firework]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Firework]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Firework]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Firework
            if (newWeapon == WeaponHash.Firework)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Firework]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Firework]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Firework]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Railgun
            if (oldWeapon == WeaponHash.Railgun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Railgun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Railgun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Railgun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Railgun
            if (newWeapon == WeaponHash.Railgun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Railgun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Railgun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Railgun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Hominglauncher
            if (oldWeapon == WeaponHash.Hominglauncher)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Hominglauncher]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Hominglauncher]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Hominglauncher]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Hominglauncher
            if (newWeapon == WeaponHash.Hominglauncher)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Hominglauncher]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Hominglauncher]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Hominglauncher]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Compactlauncher
            if (oldWeapon == WeaponHash.Compactlauncher)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Compactlauncher]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Compactlauncher]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Compactlauncher]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Compactlauncher
            if (newWeapon == WeaponHash.Compactlauncher)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Compactlauncher]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Compactlauncher]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Compactlauncher]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Rayminigun
            if (oldWeapon == WeaponHash.Rayminigun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Rayminigun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rayminigun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rayminigun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Rayminigun
            if (newWeapon == WeaponHash.Rayminigun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Rayminigun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rayminigun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Rayminigun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Grenade
            if (oldWeapon == WeaponHash.Grenade)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Grenade]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenade]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenade]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Grenade
            if (newWeapon == WeaponHash.Grenade)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Grenade]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenade]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Grenade]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Bzgas
            if (oldWeapon == WeaponHash.Bzgas)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Bzgas]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Bzgas]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Bzgas]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Bzgas
            if (newWeapon == WeaponHash.Bzgas)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Bzgas]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Bzgas]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Bzgas]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Molotov
            if (oldWeapon == WeaponHash.Molotov)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Molotov]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Molotov]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Molotov]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Molotov
            if (newWeapon == WeaponHash.Molotov)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Molotov]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Molotov]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Molotov]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Stickybomb
            if (oldWeapon == WeaponHash.Stickybomb)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Stickybomb]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Stickybomb]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Stickybomb]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Stickybomb
            if (newWeapon == WeaponHash.Stickybomb)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Stickybomb]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Stickybomb]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Stickybomb]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Proximine
            if (oldWeapon == WeaponHash.Proximine)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Proximine]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Proximine]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Proximine]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Proximine
            if (newWeapon == WeaponHash.Proximine)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Proximine]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Proximine]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Proximine]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Snowball
            if (oldWeapon == WeaponHash.Snowball)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Snowball]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Snowball]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Snowball]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Snowball
            if (newWeapon == WeaponHash.Snowball)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Snowball]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Snowball]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Snowball]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Pipebomb
            if (oldWeapon == WeaponHash.Pipebomb)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Pipebomb]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Pipebomb]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Pipebomb]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Pipebomb
            if (newWeapon == WeaponHash.Pipebomb)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Pipebomb]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Pipebomb]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Pipebomb]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Ball
            if (oldWeapon == WeaponHash.Ball)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Ball]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Ball]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Ball]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Ball
            if (newWeapon == WeaponHash.Ball)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Ball]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Ball]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Ball]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Smokegrenade
            if (oldWeapon == WeaponHash.Smokegrenade)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Smokegrenade]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Smokegrenade]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Smokegrenade]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Smokegrenade
            if (newWeapon == WeaponHash.Smokegrenade)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Smokegrenade]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Smokegrenade]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Smokegrenade]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Flare
            if (oldWeapon == WeaponHash.Flare)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Flare]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flare]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flare]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Flare
            if (newWeapon == WeaponHash.Flare)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Flare]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flare]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flare]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Raypistol
            if (oldWeapon == WeaponHash.Raypistol)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Raypistol]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Raypistol]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Raypistol]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Raypistol
            if (newWeapon == WeaponHash.Raypistol)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Raypistol]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Raypistol]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Raypistol]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Flaregun
            if (oldWeapon == WeaponHash.Flaregun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Flaregun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flaregun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flaregun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }

            //Flaregun
            if (newWeapon == WeaponHash.Flaregun)
            {
                string banreason = "Anticheat ban Grund: (Nicht erlaubte Waffe - [Flaregun]).";

                string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flaregun]) für mehr informationen erstelle ein Ticket in unserem Discord!";

                string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Nicht erlaubte Waffe - [Flaregun]).";

                accountPlayer.Ban = 1;
                accountPlayer.BanReason = banreason;
                DatabaseHandler.SaveAccount(player);
                Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 500);

                foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                {
                    Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                }
            }
        }
    }
}
