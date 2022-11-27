using Discord;
using GTANetworkAPI;
using Org.BouncyCastle.Asn1.X509;
using RageGW.Modules.Database;
using RageGW.Modules.DiscordWebhook;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using static RageGW.Handler.Accounts;

namespace RageGW.Handler.Commands
{
    class CommandsAdmin : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: Commands.CommandsAdmin geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: Commands.CommandsAdmin entladen", LoggerEnums.LogType.Info);
        }

        [Command("veh")]
        public void cmd_veh(Player player, string vehname)
        {
            Accounts account = player.GetData<Accounts>(Account_Key);
            if (!account.IsPlayerAdmin((int)AdminRanks.Administrator))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            uint vehash = NAPI.Util.GetHashKey(vehname);
            if (vehash == 0)
            {
                Utils.SendPlayerNotify(player, "", "Ungültiges Fahrzeug!", "red", 8000);
                return;
            }

            Vehicle veh = NAPI.Vehicle.CreateVehicle(vehash, player.Position, player.Heading, 0, 0);
            veh.NumberPlate = "Gangwar";
            veh.Locked = false;
            veh.Dimension = player.Dimension;
            veh.EngineStatus = true;
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler: {player.Name} hat sich ein/e/en {vehname} gespawnt!", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("ban", GreedyArg = true)]
        public void cmd_ban(Player player, Player target, string banreason)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);
            Accounts accountTarget = target.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Administrator))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            Utils.SendPlayerNotify(target, "", "Du wurdest gebannt Grund: " + banreason, "red", 10000);

            accountTarget.Ban = 1;
            accountTarget.BanReason = banreason;
            DatabaseHandler.SaveAccount(target);

            NAPI.Task.Run(() =>
            {
                target.Kick();
            }, delayTime: 1000);

            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
            {
                Utils.SendGlobalNotify(allplayers, "", $"Der Spieler {target.Name} wurde von {player.Name} gebannt (Grund: {banreason})", "red", 15000);
            }

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {target.Name} wurde von {player.Name} gebannt (Grund: {banreason})", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("kick", GreedyArg = true)]
        public void cmd_kick(Player player, Player target, string kickreason)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            Utils.SendPlayerNotify(target, "", "Du wurdest gekickt Grund: " + kickreason, "red", 10000);

            DatabaseHandler.SaveAccount(target);

            NAPI.Task.Run(() =>
            {
                target.Kick();
            }, delayTime: 1000);

            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
            {
                Utils.SendGlobalNotify(allplayers, "", $"Der Spieler {target.Name} wurde von {player.Name} gekickt (Grund: {kickreason})", "red", 15000);
            }

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {target.Name} wurde von {player.Name} gekickt (Grund: {kickreason})", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("announce", GreedyArg = true)]
        public void cmd_announce(Player player, string message)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
            {
                Utils.SendGlobalNotify(allplayers, "Announcement", message, "blue", 15000);
            }

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {player.Name} hat eine Announcement mit dem Grund: {message} ausgelöst!", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("krieg", GreedyArg = true)]
        public void cmd_krieg(Player player, string team1, string team2)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
            {
                Utils.SendGlobalNotify(allplayers, "Krieg", $"Hiermit beginnt Offiziell ein Blutiger Krieg zwischen der Partei: {team1} und der Partei: {team2}", "red", 15000);
            }

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {player.Name} hat einen Krieg zwischen der Partei: {team1} und der Partei: {team2} ausgelöst!", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("pos", GreedyArg = true)]
        public void cmd_pos(Player player)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            string PositionX = player.Position.X.ToString();
            if (PositionX.Contains(",")) PositionX = PositionX.Replace(",", ".");

            string PositionY = player.Position.Y.ToString();
            if (PositionY.Contains(",")) PositionY = PositionY.Replace(",", ".");

            string PositionZ = player.Position.Z.ToString();
            if (PositionZ.Contains(",")) PositionZ = PositionZ.Replace(",", ".");

            string PositionA = player.Heading.ToString();
            if (PositionA.Contains(",")) PositionA = PositionA.Replace(",", ".");

            Logger.Write($"new Vector3({PositionX}f, {PositionY}f, {PositionZ}f)", LoggerEnums.LogType.Info);
            Logger.Write("", LoggerEnums.LogType.Info);
            Logger.Write($"X: {player.Position.X} | Y: {player.Position.Y} | Z: {player.Position.Z} | Heading: {player.Heading} | Rotation: {player.Rotation}", LoggerEnums.LogType.Info);
        }

        [Command("dv", GreedyArg = true)]
        public void cmd_dv(Player player)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }
            player.Vehicle.Delete();
            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gelöscht!", "green", 8000);

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {player.Name} hat ein/e/en {player.Vehicle.DisplayName} gelöscht!", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("dimension")]
        public void cmd_dimension(Player player, Player target, uint dimension)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            Utils.SendPlayerNotify(player, "", $"Du hast {target.Name} in die Dimension: {dimension} gesetzt!", "black", 8000);
            Utils.SendPlayerNotify(target, "", $"Du wurdest in die Dimension: {dimension} gesetzt!", "black", 8000);

            target.Dimension = dimension;
        }

        [Command("weapon")]
        public void cmd_weapon(Player player, string name)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Administrator))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            player.GiveWeapon(NAPI.Util.WeaponNameToModel(name), 9999);

            Utils.SendPlayerNotify(player, "", $"Du hast dir eine {name} gegeben!", "black", 8000);

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {player.Name} hat sich ein/e/en {name} gegeben!", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("goto")]
        public void cmd_goto(Player player, Player target)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            Utils.SendPlayerNotify(player, "", $"Du hast dich zum Spieler {target.Name} teleportiert!", "green", 8000);
            Utils.SendPlayerNotify(target, "", $"Das Teammitglied {player.Name} hat sich zu dir teleportiert!", "green", 8000);

            player.Position = target.Position;

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {player.Name} hat sich zu dem Spieler {target.Name} teleportiert!", Webhooks.adminLogs, "AdminSystem");
        }

        [Command("tphere")]
        public void cmd_tphere(Player player, Player target)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);

            if (!accountPlayer.IsPlayerAdmin((int)AdminRanks.Supporter))
            {
                Utils.SendPlayerNotify(player, "", "Dein Adminlevel ist zu gering!", "red", 8000);
                return;
            }

            Utils.SendPlayerNotify(player, "", $"Du hast den Spieler {target.Name} zu dir teleportiert!", "green", 8000);
            Utils.SendPlayerNotify(target, "", $"Das Teammitglied {player.Name} hat dich zu sich teleportiert!", "green", 8000);

            target.Position = player.Position;

            DiscordWebhook.SendMessage("AdminSystem", $"Der Spieler {player.Name} hat den Spieler {target.Name} zu sich teleportiert!", Webhooks.adminLogs, "AdminSystem");
        }
    }
}
