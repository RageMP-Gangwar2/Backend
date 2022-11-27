using Discord;
using GTANetworkAPI;
using RageGW.Handler;
using RageGW.Handler.AntiCheatHandler;
using RageGW.Modules.Database;
using RageGW.Modules.Discord;
using RageGW.Modules.DiscordWebhook;
using RageGW.Modules.Events;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Security.Principal;
using System.Timers;
using Object = System.Object;

namespace RageGW
{
    public class Resources : Script
    {
        private static Timer aTimer;

        static void Main(string[] args) {}

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Server.SetGlobalServerChat(false);
            NAPI.Server.SetAutoSpawnOnConnect(true);
            NAPI.Server.SetCommandErrorMessage("[Gangwar] Dieser Befehl wurde nicht gefunden.");
            NAPI.Server.SetAutoRespawnAfterDeath(false);

            Logger.Write("Der Server wird gerade gestartet!", LoggerEnums.LogType.Info);

            //Database
            DatabaseHandler.InitConnection();

            //Timer
            SetPlayerSaveAndVehicleDeleteTimer();

            //SetHealkeyTimer();

            Logger.Write("Der Server wurde erfolgreich gestartet!", LoggerEnums.LogType.Info);

            NAPI.World.SetWeather(Weather.CLEAR);
            NAPI.World.SetTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        /*private static void SetHealkeyTimer()
        {
            aTimer = new Timer(10000);
            aTimer.Elapsed += OnHealkeyTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }*/

        private static void SetPlayerSaveAndVehicleDeleteTimer()
        {
            aTimer = new Timer(60000);
            aTimer.Elapsed += OnPlayerSaveAndVehicleDeleteTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        //Save all players and delete all unused vehicles
        private static void OnPlayerSaveAndVehicleDeleteTimedEvent(Object source, ElapsedEventArgs e)
        {
            NAPI.Task.Run(() =>
            {
                foreach (Player player in NAPI.Pools.GetAllPlayers())
                {
                    Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

                    if (accountPlayer != null && Accounts.IsAccountAlreadyLoggedIn(player))
                    {
                        DatabaseHandler.SaveAccount(player);
                    }
                }

                //i don't know how to make it work :(
                /*foreach (Vehicle vehicle in NAPI.Pools.GetAllVehicles())
                {
                    Player driver = (Player)NAPI.Vehicle.GetVehicleDriver(vehicle);

                    if (driver.VehicleSeat == 1)
                    {
                        return;
                    }
                    else
                    {
                        vehicle.Delete();

                        foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                        {
                            Utils.SendGlobalNotify(allplayers, "AutoClear", "Alle unbenutzten Fahrzeuge wurden gelöscht", "blue", 10000);
                        }
                    }
                }*/

                Logger.Write("OnPlayerSaveAndVehicleDeleteTimedEvent wurde Ausgeführt", LoggerEnums.LogType.Info);
            });
        }

        //Healkey Detection i don't know how to make it work :(
        /*private static void OnHealkeyTimedEvent(Object source, ElapsedEventArgs e)
        {
            NAPI.Task.Run(() =>
            {
                //CheckAllPlayers
                foreach (Player player in NAPI.Pools.GetAllPlayers())
                {
                    Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

                    if (accountPlayer != null && Accounts.IsAccountAlreadyLoggedIn(player))
                    {
                        //Health Detection
                        if (player.Health > 99)
                        {
                            string banreason = "Anticheat ban Grund: (Healkey).";

                            string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Healkey) für mehr informationen erstelle ein Ticket in unserem Discord!";

                            string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Healkey).";

                            accountPlayer.Ban = 1;
                            accountPlayer.BanReason = banreason;
                            DatabaseHandler.SaveAccount(player);
                            Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                            DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                            NAPI.Task.Run(() =>
                            {
                                player.Kick();
                            }, delayTime: 50);

                            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                            {
                                Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                            }
                        }

                        //Armor Detection
                        if (player.Armor > 99)
                        {
                            string banreason = "Anticheat ban Grund: (Healkey).";

                            string banreasonPlayerNotify = "Du wurdest vom Anticheat gebannt Grund: (Healkey) für mehr informationen erstelle ein Ticket in unserem Discord!";

                            string globalreason = $"Der Spieler {player.Name} wurde vom Anticheat gebannt Grund: (Healkey).";

                            accountPlayer.Ban = 1;
                            accountPlayer.BanReason = banreason;
                            DatabaseHandler.SaveAccount(player);
                            Utils.SendPlayerNotify(player, "", banreasonPlayerNotify, "red", 15000);

                            DiscordWebhook.SendMessage("AnticheatSystem", globalreason, Webhooks.anticheatLogs, "AnticheatSystem");

                            NAPI.Task.Run(() =>
                            {
                                player.Kick();
                            }, delayTime: 50);

                            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
                            {
                                Utils.SendGlobalNotify(allplayers, "", globalreason, "red", 15000);
                            }
                        }
                    }

                    Logger.Write("OnHealkeyDetectionTimer wurde Ausgeführt", LoggerEnums.LogType.Info);
                }
            });
        }*/

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Der Server wurde erfolgreich heruntergefahren!", LoggerEnums.LogType.Info);
        }
    }
}