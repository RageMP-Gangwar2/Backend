using GTANetworkAPI;
using RageGW.Modules.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageGW.Handler.ChatHandler
{
    class ChatHandler : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: ChatHandler geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: ChatHandler entladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ChatMessage)]
        public void EventChatMessage(Player player, string msg)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (player == null || !player.Exists) return;
            if (msg.Contains("~")) msg = msg.Replace("~", "");

            if (accountPlayer.Adminlevel == 0)
            {
                NAPI.Chat.SendChatMessageToAll($"[~y~Global-Chat~w~] [LVL: {accountPlayer.Level}] ~g~[Spieler]~w~ {player.Name}: {msg}");
            }

            if (accountPlayer.Adminlevel == 1)
            {
                NAPI.Chat.SendChatMessageToAll($"[~y~Global-Chat~w~] [LVL: {accountPlayer.Level}] ~b~[Donator]~w~ {player.Name}: {msg}");
            }

            if (accountPlayer.Adminlevel == 2)
            {
                NAPI.Chat.SendChatMessageToAll($"[~y~Global-Chat~w~] [LVL: {accountPlayer.Level}] ~q~[Supporter]~w~ {player.Name}: {msg}");
            }

            if (accountPlayer.Adminlevel == 3)
            {
                NAPI.Chat.SendChatMessageToAll($"[~y~Global-Chat~w~] [LVL: {accountPlayer.Level}] ~y~[Administrator]~w~ {player.Name}: {msg}");
            }

            if (accountPlayer.Adminlevel == 4)
            {
                NAPI.Chat.SendChatMessageToAll($"[~y~Global-Chat~w~] [LVL: {accountPlayer.Level}] ~r~[Founder]~w~ {player.Name}: {msg}");
            }
        }
    }
}
