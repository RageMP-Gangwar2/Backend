using GTANetworkAPI;
using RageGW.Handler;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using static RageGW.Handler.Accounts;

namespace RageGW.Modules.PrivateFactionsSystem
{
    class PrivateFactionsSystem : Script
    {
        [Command("invite")]
        public void cmd_invite(Player player, Player target)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);
            Accounts accountTarget = target.GetData<Accounts>(Account_Key);

            if (accountPlayer.PrivateFaction == 0) return;
            if (accountPlayer.PrivateFaction_Rank < 3) return;

            if (accountPlayer.PrivateFaction_Rank >= 3)
            {
                accountTarget.PrivateFaction = accountPlayer.PrivateFaction;
                accountTarget.PrivateFaction_Rank = 0;

                Utils.Utils.SendPlayerNotify(player, "", $"Du hast {target.Name} in deine Fraktion eingeladen!", "green", 8000);
                Utils.Utils.SendPlayerNotify(target, "", $"Du wurdest von {player.Name} in eine Fraktion eingeladen!", "green", 8000);
            }
        }

        [Command("uninvite")]
        public void cmd_uninvite(Player player, Player target)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);
            Accounts accountTarget = target.GetData<Accounts>(Account_Key);

            if (accountPlayer.PrivateFaction == 0) return;
            if (accountPlayer.PrivateFaction_Rank < 3) return;

            if (accountPlayer.PrivateFaction_Rank >= 3)
            {
                accountTarget.PrivateFaction = 0;
                accountTarget.PrivateFaction_Rank = 0;

                Utils.Utils.SendPlayerNotify(player, "", $"Du hast {target.Name} aus der Fraktion geworfen!", "green", 8000);
                Utils.Utils.SendPlayerNotify(target, "", $"Du wurdest von {player.Name} aus der Fraktion geworfen!", "red", 8000);
            }
        }

        [Command("setrank")]
        public void cmd_setrank(Player player, Player target, int rank)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Account_Key);
            Accounts accountTarget = target.GetData<Accounts>(Account_Key);

            if (accountPlayer.PrivateFaction == 0) return;
            if (accountPlayer.PrivateFaction_Rank < 4) return;
            if (rank > 3) return;

            if (accountPlayer.PrivateFaction_Rank >= 4)
            {
                accountTarget.PrivateFaction_Rank = rank;

                Utils.Utils.SendPlayerNotify(player, "", $"Du hast den Rang von {target.Name} verändert!", "black", 8000);
                Utils.Utils.SendPlayerNotify(target, "", $"Dein Rang wurde von {player.Name} verändert!", "black", 8000);
            }
        }
    }
}
