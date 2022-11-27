using Discord;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using RageGW.Handler;
using RageGW.Modules.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageGW.Modules.LevelSystem
{
    class LevelSystem : Script
    {
        private const int LevelMulti = 8;

        public static void LevelCheckAndUp(Player player)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (accountPlayer.XP >= accountPlayer.Level * LevelMulti)
            {
                accountPlayer.Level++;
                accountPlayer.XP = 0;
                Utils.Utils.SendPlayerNotify(player, "", $"Du bist nun auf Level {accountPlayer.Level} aufgestiegen", "green", 8000);
                DatabaseHandler.SaveAccount(player);
            }
        }
    }
}
