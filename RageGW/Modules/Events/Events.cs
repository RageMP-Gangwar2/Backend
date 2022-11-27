using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using Microsoft.VisualBasic;
using RageGW.Handler;
using RageGW.Modules.Database;
using RageGW.Modules.Discord;
using RageGW.Modules.LevelSystem;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;

namespace RageGW.Modules.Events
{
    class Events : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Logger.Write("Module: Events geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Logger.Write("Module: Events entladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.PlayerConnected)]
        public static void OnPlayerConnected(Player player)
        {
            if (player.Name == "WeirdNewbie") player.Kick("Bitte änder dein namen im Rage:MP launcher WeirdNewbie ist nicht zulässig");

            player.Health = 99;
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnect(Player player, DisconnectionType type, string reason)
        {
            DatabaseHandler.SaveAccount(player);
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatID)
        {
            player.TriggerEvent("setPlayerVehicleMultiplier", 30);
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {
            player.Vehicle.EngineStatus = true;
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player player, Player killer, uint reason)
        {
            if (player.HasData("isInFFA"))
            {
                //Würfelpark
                if (player.HasData("FFA1"))
                {
                    player.SetData("isDead", true);

                    player.TriggerEvent("toggleDisableAllControls", true);

                    Accounts accountKiller = killer.GetData<Accounts>(Accounts.Account_Key);

                    Utils.Utils.SendPlayerNotify(killer, "", $"Du hast {player.Name} getötet! + 25$", "green", 8000);
                    accountKiller.Kills++;
                    accountKiller.KD++;
                    killer.Health = 99;
                    killer.Armor = 99;
                    accountKiller.Money += 25;
                    accountKiller.XP++;

                    Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

                    player.RemoveAllWeapons();
                    NAPI.Player.SpawnPlayer(player, player.Position);
                    player.Health = 99;
                    player.PlayAnimation("missarmenian2", "corpse_search_exit_ped", 33);

                    Utils.Utils.SendPlayerNotify(player, "", $"Du wurdest von {killer.Name}({killer.Health}HP/{killer.Armor}AP) getötet!", "red", 8000);
                    accountPlayer.Deaths++;
                    accountPlayer.KD--;

                    DatabaseHandler.SaveAccount(player);
                    DatabaseHandler.SaveAccount(killer);
                    LevelSystem.LevelSystem.LevelCheckAndUp(player);
                    LevelSystem.LevelSystem.LevelCheckAndUp(killer);

                    Utils.Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);
                    Utils.Utils.RefreshHud(killer, accountKiller.Kills, accountKiller.Deaths, accountKiller.Level, accountKiller.Money);

                    NAPI.Task.Run(() =>
                    {
                        if (!killer.IsNull)
                        {
                            int rnd = new Random().Next(1, 120);

                            if (rnd >= 3 && rnd <= 24)
                            {
                                player.Position = new Vector3(258.52747f, -875.9077f, 29.212402f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(258.52747f, -875.9077f, 29.212402f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 24 && rnd <= 48)
                            {
                                player.Position = new Vector3(218.42638f, -937.5165f, 24.140625f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(218.42638f, -937.5165f, 24.140625f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 48 && rnd <= 72)
                            {
                                player.Position = new Vector3(204.03957f, -993.7187f, 30.088623f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(204.03957f, -993.7187f, 30.088623f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 72 && rnd <= 96)
                            {
                                player.Position = new Vector3(207.53406f, -994.66825f, 29.279907f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(207.53406f, -994.66825f, 29.279907f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 96 && rnd <= 120)
                            {
                                player.Position = new Vector3(160.68132f, -999.0857f, 29.330444f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(160.68132f, -999.0857f, 29.330444f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                        }
                    }, delayTime: 5000);
                }

                //Triaden
                if (player.HasData("FFA2"))
                {
                    player.SetData("isDead", true);

                    player.TriggerEvent("toggleDisableAllControls", true);

                    Accounts accountKiller = killer.GetData<Accounts>(Accounts.Account_Key);

                    Utils.Utils.SendPlayerNotify(killer, "", $"Du hast {player.Name} getötet! + 25$", "green", 8000);
                    accountKiller.Kills++;
                    accountKiller.KD++;
                    killer.Health = 99;
                    killer.Armor = 99;
                    accountKiller.Money += 25;
                    accountKiller.XP++;

                    Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

                    player.RemoveAllWeapons();
                    NAPI.Player.SpawnPlayer(player, player.Position);
                    player.Health = 99;
                    player.PlayAnimation("missarmenian2", "corpse_search_exit_ped", 33);

                    Utils.Utils.SendPlayerNotify(player, "", $"Du wurdest von {killer.Name}({killer.Health}HP/{killer.Armor}AP) getötet!", "red", 8000);
                    accountPlayer.Deaths++;
                    accountPlayer.KD--;

                    DatabaseHandler.SaveAccount(player);
                    DatabaseHandler.SaveAccount(killer);
                    LevelSystem.LevelSystem.LevelCheckAndUp(player);
                    LevelSystem.LevelSystem.LevelCheckAndUp(killer);

                    Utils.Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);
                    Utils.Utils.RefreshHud(killer, accountKiller.Kills, accountKiller.Deaths, accountKiller.Level, accountKiller.Money);

                    NAPI.Task.Run(() =>
                    {
                        if (!killer.IsNull)
                        {
                            int rnd = new Random().Next(1, 120);

                            if (rnd >= 3 && rnd <= 24)
                            {
                                player.Position = new Vector3(1481.1019f, 1114.8245f, 114.33454f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(1481.1019f, 1114.8245f, 114.33454f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 24 && rnd <= 48)
                            {
                                player.Position = new Vector3(1481.1019f, 1114.8245f, 114.33454f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(1481.1019f, 1114.8245f, 114.33454f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 48 && rnd <= 72)
                            {
                                player.Position = new Vector3(1433.3723f, 1184.334f, 114.15171f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(1433.3723f, 1184.334f, 114.15171f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 72 && rnd <= 96)
                            {
                                player.Position = new Vector3(1370.4058f, 1147.5156f, 113.75894f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(1370.4058f, 1147.5156f, 113.75894f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 96 && rnd <= 120)
                            {
                                player.Position = new Vector3(1406.6914f, 1117.7511f, 114.83774f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(1406.6914f, 1117.7511f, 114.83774f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                        }
                    }, delayTime: 5000);
                }

                //Kirche
                if (player.HasData("FFA3"))
                {
                    player.SetData("isDead", true);

                    player.TriggerEvent("toggleDisableAllControls", true);

                    Accounts accountKiller = killer.GetData<Accounts>(Accounts.Account_Key);

                    Utils.Utils.SendPlayerNotify(killer, "", $"Du hast {player.Name} getötet! + 25$", "green", 8000);
                    accountKiller.Kills++;
                    accountKiller.KD++;
                    killer.Health = 99;
                    killer.Armor = 99;
                    accountKiller.Money += 25;
                    accountKiller.XP++;

                    Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

                    player.RemoveAllWeapons();
                    NAPI.Player.SpawnPlayer(player, player.Position);
                    player.Health = 99;
                    player.PlayAnimation("missarmenian2", "corpse_search_exit_ped", 33);

                    Utils.Utils.SendPlayerNotify(player, "", $"Du wurdest von {killer.Name}({killer.Health}HP/{killer.Armor}AP) getötet!", "red", 8000);
                    accountPlayer.Deaths++;
                    accountPlayer.KD--;

                    DatabaseHandler.SaveAccount(player);
                    DatabaseHandler.SaveAccount(killer);
                    LevelSystem.LevelSystem.LevelCheckAndUp(player);
                    LevelSystem.LevelSystem.LevelCheckAndUp(killer);

                    Utils.Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);
                    Utils.Utils.RefreshHud(killer, accountKiller.Kills, accountKiller.Deaths, accountKiller.Level, accountKiller.Money);

                    NAPI.Task.Run(() =>
                    {
                        if (!killer.IsNull)
                        {
                            int rnd = new Random().Next(1, 120);

                            if (rnd >= 3 && rnd <= 24)
                            {
                                player.Position = new Vector3(-297.96716f, 2791.2646f, 60.21791f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(-297.96716f, 2791.2646f, 60.21791f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 24 && rnd <= 48)
                            {
                                player.Position = new Vector3(-352.33957f, 2776.2683f, 58.762897f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(-352.33957f, 2776.2683f, 58.762897f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 48 && rnd <= 72)
                            {
                                player.Position = new Vector3(-324.68524f, 2826.234f, 58.090813f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(-324.68524f, 2826.234f, 58.090813f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 72 && rnd <= 96)
                            {
                                player.Position = new Vector3(-287.95786f, 2851.0635f, 53.976055f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(-287.95786f, 2851.0635f, 53.976055f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                            else if (rnd >= 96 && rnd <= 120)
                            {
                                player.Position = new Vector3(-270.33453f, 2802.7888f, 54.74635f);
                                NAPI.Player.SpawnPlayer(player, new Vector3(-270.33453f, 2802.7888f, 54.74635f));
                                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                                player.StopAnimation();

                                player.ResetData("isDead");

                                player.TriggerEvent("toggleDisableAllControls", false);
                            }
                        }
                    }, delayTime: 5000);
                }
            }
            else
            {
                if (!killer.IsNull)
                {
                    player.SetData("isDead", true);

                    player.TriggerEvent("toggleDisableAllControls", true);

                    Accounts accountKiller = killer.GetData<Accounts>(Accounts.Account_Key);

                    Utils.Utils.SendPlayerNotify(killer, "", $"Du hast {player.Name} getötet! + 25$", "green", 8000);
                    accountKiller.Kills++;
                    accountKiller.KD++;
                    killer.Health = 99;
                    killer.Armor = 99;
                    accountKiller.Money += 25;
                    accountKiller.XP++;

                    Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

                    player.RemoveAllWeapons();
                    NAPI.Player.SpawnPlayer(player, player.Position);
                    player.Health = 99;
                    player.PlayAnimation("missarmenian2", "corpse_search_exit_ped", 33);

                    Utils.Utils.SendPlayerNotify(player, "", $"Du wurdest von {killer.Name}({killer.Health}HP/{killer.Armor}AP) getötet!", "red", 8000);
                    accountPlayer.Deaths++;
                    accountPlayer.KD--;

                    DatabaseHandler.SaveAccount(player);
                    DatabaseHandler.SaveAccount(killer);
                    LevelSystem.LevelSystem.LevelCheckAndUp(player);
                    LevelSystem.LevelSystem.LevelCheckAndUp(killer);

                    Utils.Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);
                    Utils.Utils.RefreshHud(killer, accountKiller.Kills, accountKiller.Deaths, accountKiller.Level, accountKiller.Money);

                    NAPI.Task.Run(() =>
                    {
                        if (player.HasData("team1"))
                        {
                            NAPI.Player.SpawnPlayer(player, new Vector3(-1521.4286f, 853.1868f, 181.58533f));
                            Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                            player.StopAnimation();

                            player.ResetData("isDead");

                            player.TriggerEvent("toggleDisableAllControls", false);
                        }

                        if (player.HasData("team2"))
                        {
                            NAPI.Player.SpawnPlayer(player, new Vector3(1382.7693f, -590.53186f, 74.3363f));
                            Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                            player.StopAnimation();

                            player.ResetData("isDead");

                            player.TriggerEvent("toggleDisableAllControls", false);
                        }

                        if (player.HasData("team3"))
                        {
                            NAPI.Player.SpawnPlayer(player, new Vector3(1415.4989f, 3633.2966f, 34.654907f));
                            Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                            player.StopAnimation();

                            player.ResetData("isDead");

                            player.TriggerEvent("toggleDisableAllControls", false);
                        }

                        if (player.HasData("team4"))
                        {
                            NAPI.Player.SpawnPlayer(player, new Vector3(1286.5319f, -1603.5692f, 54.82422f));
                            Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                            player.StopAnimation();

                            player.ResetData("isDead");

                            player.TriggerEvent("toggleDisableAllControls", false);
                        }

                        if (player.HasData("team5"))
                        {
                            NAPI.Player.SpawnPlayer(player, new Vector3(-1535.7627f, 97.63516f, 56.761963f));
                            Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                            player.StopAnimation();

                            player.ResetData("isDead");

                            player.TriggerEvent("toggleDisableAllControls", false);
                        }

                        if (player.HasData("team6"))
                        {
                            NAPI.Player.SpawnPlayer(player, new Vector3(84.64616f, -1958.3737f, 21.107666f));
                            Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                            player.StopAnimation();

                            player.ResetData("isDead");

                            player.TriggerEvent("toggleDisableAllControls", false);
                        }
                    }, delayTime: 5000);
                }
                else{}
            }
        }
    }
}
