using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Ubiety.Dns.Core.Records.NotUsed;

namespace RageGW.Modules._1vs1System
{
    class _1vs1System : Script
    {
        [Command("1vs1")]
        public void CMD_Duell(Player player, Player target, int map)
        {
            if (map == 0) return;
            if (map > 3)
            {
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Du kannst nur die Maps 1 - 3 auswählen!");
                NAPI.Chat.SendChatMessageToPlayer(player, $"");
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Übersicht Maps");
                NAPI.Chat.SendChatMessageToPlayer(player, $"");
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Map 1 Würfelpark");
                NAPI.Chat.SendChatMessageToPlayer(player, $"");
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Map 2 Würfelpark Dach");
                NAPI.Chat.SendChatMessageToPlayer(player, $"");
                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Map 3 Triaden");
                return;
            }

            if (map == 1)
            {
                player.SetData("duellRequestName", target.Name);
                target.SetData("duellRequestName", player.Name);

                player.SetData("duellRequestWürfelpark", target.Name);
                target.SetData("duellRequestWürfelpark", player.Name);

                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Du hast {target.Name} herausgefordert!");
                NAPI.Chat.SendChatMessageToPlayer(target, $"[~p~1vs1~w~] {player.Name} fordert dich zu einem 1vs1 heraus! /accept1vs1 {player.Name} um die Anfrage anzunehmen.");
            }

            if (map == 2)
            {
                player.SetData("duellRequestName", target.Name);
                target.SetData("duellRequestName", player.Name);

                player.SetData("duellRequestWürfelparkDach", target.Name);
                target.SetData("duellRequestWürfelparkDach", player.Name);

                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Du hast {target.Name} herausgefordert!");
                NAPI.Chat.SendChatMessageToPlayer(target, $"[~p~1vs1~w~] {player.Name} fordert dich zu einem 1vs1 heraus! /accept1vs1 {player.Name} um die Anfrage anzunehmen.");
            }

            if (map == 3)
            {
                player.SetData("duellRequestName", target.Name);
                target.SetData("duellRequestName", player.Name);

                player.SetData("duellRequestTriaden", target.Name);
                target.SetData("duellRequestTriaden", player.Name);

                NAPI.Chat.SendChatMessageToPlayer(player, $"[~p~1vs1~w~] Du hast {target.Name} herausgefordert!");
                NAPI.Chat.SendChatMessageToPlayer(target, $"[~p~1vs1~w~] {player.Name} fordert dich zu einem 1vs1 heraus! /accept1vs1 {player.Name} um die Anfrage anzunehmen.");
            }
        }

        [Command("accept1vs1")]
        public void CMD_DuellAccept(Player target, Player player)
        {
            if (target.HasData("duellRequestWürfelpark"))
            {
                int rnd = new Random().Next(1, 99999);

                player.ResetData("duellRequestName");
                target.ResetData("duellRequestName");
                player.ResetData("duellRequestWürfelpark");
                target.ResetData("duellRequestWürfelpark");

                player.Dimension = (uint)rnd;
                target.Dimension = (uint)rnd;
                player.Position = new Vector3(180.06946f, -963.0675f, 29.63849f);
                target.Position = new Vector3(217.7094f, -900.6989f, 30.69236f);

                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                Utils.Utils.GiveWeaponsArmorHealthToPlayer(target);
            }

            if (target.HasData("duellRequestWürfelparkDach"))
            {
                int rnd = new Random().Next(1, 99999);

                player.ResetData("duellRequestName");
                target.ResetData("duellRequestName");
                player.ResetData("duellRequestWürfelparkDach");
                target.ResetData("duellRequestWürfelparkDach");

                player.Dimension = (uint)rnd;
                target.Dimension = (uint)rnd;
                player.Position = new Vector3(117.83242f, -878.2336f, 134.76999f);
                target.Position = new Vector3(84.18074f, -865.86536f, 134.76999f);

                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                Utils.Utils.GiveWeaponsArmorHealthToPlayer(target);
            }

            if (target.HasData("duellRequestTriaden"))
            {
                int rnd = new Random().Next(1, 99999);

                player.ResetData("duellRequestName");
                target.ResetData("duellRequestName");
                player.ResetData("duellRequestTriaden");
                target.ResetData("duellRequestTriaden");

                player.Dimension = (uint)rnd;
                target.Dimension = (uint)rnd;
                player.Position = new Vector3(1441.7917f, 1113.128f, 114.27993f);
                target.Position = new Vector3(1477.2334f, 1113.1171f, 114.3342f);

                Utils.Utils.GiveWeaponsArmorHealthToPlayer(player);
                Utils.Utils.GiveWeaponsArmorHealthToPlayer(target);
            }
        }
    }
}
