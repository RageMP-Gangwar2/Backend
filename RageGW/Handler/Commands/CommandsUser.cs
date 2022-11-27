using GTANetworkAPI;
using Org.BouncyCastle.Asn1.X509;
using RageGW.Modules.Database;
using RageGW.Modules.DiscordWebhook;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageGW.Handler.Commands
{
    class CommandsUser : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: Commands.CommandsUser geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: Commands.CommandsUser entladen", LoggerEnums.LogType.Info);
        }

        [Command("kit")]
        public void CMD_kit(Player player, int kit)
        {
            if (kit > 4)
            {
                Utils.SendPlayerNotify(player, "", $"Dieses Kit existiert nicht du kannst nur die Kits 0 - 4 auswählen!", "red", 8000); 
                return;
            }

            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            player.RemoveAllWeapons();
            accountPlayer.Kit = kit;
            Utils.SendPlayerNotify(player, "", $"Du hast das Kit: {kit} ausgerüstet!", "green", 8000);
            DatabaseHandler.SaveAccount(player);
            Utils.GiveWeaponsArmorHealthToPlayer(player);
        }

        [Command("reset")]
        public void CMD_reset(Player player)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            accountPlayer.Kills = 0;
            accountPlayer.Deaths = 0;
            accountPlayer.KD = 0;
            Utils.SendPlayerNotify(player, "", $"Du hast deine Stats zurückgesetzt!", "green", 8000);
            DatabaseHandler.SaveAccount(player);
        }

        [Command("quitffa")]
        public void CMD_quitffa(Player player)
        {
            if (player.HasData("isInFFA") == false)
            {
                Utils.SendPlayerNotify(player, "", $"Du bist nicht in einer FFA-Zone!", "red", 8000);
                return;
            }

            player.ResetData("isInFFA");

            player.ResetData("FFA1");

            player.ResetData("FFA1");

            player.ResetData("FFA2");

            player.ResetData("FFA3");

            player.Dimension = 0;

            player.RemoveAllWeapons();
            Utils.SendPlayerNotify(player, "", "FFA-Zone verlassen!", "red", 8000);

            if (player.HasData("team1"))
            {
                player.ResetData("isInFFA");
                player.RemoveAllWeapons();
                NAPI.Player.SpawnPlayer(player, new Vector3(-1521.4286f, 853.1868f, 181.58533f));
                Utils.GiveWeaponsArmorHealthToPlayer(player);
            }

            if (player.HasData("team2"))
            {
                player.ResetData("isInFFA");
                player.RemoveAllWeapons();
                NAPI.Player.SpawnPlayer(player, new Vector3(1382.7693f, -590.53186f, 74.3363f));
                Utils.GiveWeaponsArmorHealthToPlayer(player);
            }

            if (player.HasData("team3"))
            {
                player.ResetData("isInFFA");
                player.RemoveAllWeapons();
                NAPI.Player.SpawnPlayer(player, new Vector3(1415.4989f, 3633.2966f, 34.654907f));
                Utils.GiveWeaponsArmorHealthToPlayer(player);
            }

            if (player.HasData("team4"))
            {
                player.ResetData("isInFFA");
                player.RemoveAllWeapons();
                NAPI.Player.SpawnPlayer(player, new Vector3(1286.5319f, -1603.5692f, 54.82422f));
                Utils.GiveWeaponsArmorHealthToPlayer(player);
            }

            if (player.HasData("team5"))
            {
                player.ResetData("isInFFA");
                player.RemoveAllWeapons();
                NAPI.Player.SpawnPlayer(player, new Vector3(-1535.7627f, 97.63516f, 56.761963f));
                Utils.GiveWeaponsArmorHealthToPlayer(player);
            }

            if (player.HasData("team6"))
            {
                player.ResetData("isInFFA");
                player.RemoveAllWeapons();
                NAPI.Player.SpawnPlayer(player, new Vector3(84.64616f, -1958.3737f, 21.107666f));
                Utils.GiveWeaponsArmorHealthToPlayer(player);
            }
        }

        [Command("ffa")]
        public void CMD_ffa(Player player)
        {
            if (player.HasData("isInFFA"))
            {
                Utils.SendPlayerNotify(player, "", $"Du bist bereits in einer FFA-Zone!", "red", 8000);
                return;
            }

            Utils.ShowFFAbrowser(player);
        }

        [Command("report", GreedyArg = true)]
        public void CMD_report(Player player, string playername, string reason)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            Utils.SendPlayerNotify(player, "", $"Du hast den Spieler: {playername} mit dem (Grund: {reason}) Reportet!", "green", 10000);
            DiscordWebhook.SendMessage("ReportSystem", $"Der Spieler: {player.Name} hat den Spieler: {playername} mit dem (Grund: {reason}) Reportet!", Webhooks.reportLogs, "ReportSystem");

            foreach (Player allplayers in NAPI.Pools.GetAllPlayers())
            {
                if (accountPlayer.Adminlevel >= 56)
                {
                    Utils.SendPlayerNotify(allplayers, "", $"Der Spieler: {player.Name} hat den Spieler: {playername} mit dem (Grund: {reason}) Reportet!", "blue", 20000);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
