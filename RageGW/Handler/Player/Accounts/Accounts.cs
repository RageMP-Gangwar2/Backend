using GTANetworkAPI;
using RageGW.Modules.Database;
using RageGW.Modules.Events;
using RageGW.Modules.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGW.Handler
{
    class Accounts
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: Accounts geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: Accounts entladen", LoggerEnums.LogType.Info);
        }

        public enum AdminRanks { Spieler, Donator, Supporter, Administrator, Founder };

        public DateTime LastInteracted { get; set; }

        public const string Account_Key = "Account_Data";
        public int ID;
        public string Name;
        public int Adminlevel;
        public int Kills;
        public int Deaths;
        public int KD;
        public int XP;
        public int Level;
        public int Money;
        public int Kit;
        public int Ban;
        public string BanReason;

        public int ADVschalli;
        public int ADVvisier;
        public int ADVmagazin;
        public int Bullischalli;
        public int Bullivisier;
        public int Bullimagazin;
        public int Spezischalli;
        public int Spezivisier;
        public int Spezimagazin;
        public int Gusimagazin;

        public int PrivateFaction;
        public int PrivateFaction_Rank;

        public Player _player;

        public Accounts()
        {
            Name = "";
            Adminlevel = 0;
            Kills = 0;
            Deaths = 0;
            KD = 0;
            XP = 0;
            Level = 1;
            Money = 0;
            Kit = 0;
            Ban = 0;
            BanReason = "";
            ADVschalli = 0;
            ADVvisier = 0;
            ADVmagazin = 0;
            Bullischalli = 0;
            Bullivisier = 0;
            Bullimagazin = 0;
            Spezischalli = 0;
            Spezivisier = 0;
            Spezimagazin = 0;
            Gusimagazin = 0;
            PrivateFaction = 0;
            PrivateFaction_Rank = 0;
        }

        public Accounts(string Name, Player player)
        {
            this.Name = Name;
            _player = player;
            Adminlevel = 0;
            Kills = 0;
            Deaths = 0;
            KD = 0;
            XP = 0;
            Level = 1;
            Money = 0;
            Kit = 0;
            Ban = 0;
            BanReason = "";
            ADVschalli = 0;
            ADVvisier = 0;
            ADVmagazin = 0;
            Bullischalli = 0;
            Bullivisier = 0;
            Bullimagazin = 0;
            Spezischalli = 0;
            Spezivisier = 0;
            Spezimagazin = 0;
            Gusimagazin = 0;
        }

        public static bool IsAccountAlreadyLoggedIn(Player player)
        {
            if (player != null) return player.HasData(Account_Key);
            return false;
        }

        public void Register(string name, string password)
        {
            DatabaseHandler.CreateNewAccount(this, password);
            Login(_player, true);
        }

        public void Login(Player player, bool firstLogin)
        {
            DatabaseHandler.LoadAccount(this);
            player.SendChatMessage("Willkommen zurück auf Gangwar!");
            player.SetData(Account_Key, this);
        }

        public bool IsPlayerAdmin(int Adminlevel)
        {
            return this.Adminlevel >= Adminlevel;
        }
    }
}
