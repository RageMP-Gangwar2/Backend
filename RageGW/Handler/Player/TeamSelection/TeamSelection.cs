using GTANetworkAPI;
using RageGW.Modules.Database;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RageGW.Handler
{
    class TeamSelection : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: TeamSelection geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: TeamSelection entladen", LoggerEnums.LogType.Info);
        }

        [RemoteEvent("Server:TeamBrowser:selectTeam")]
        public void selectTeam(Player player, int teamId)
        {
            Accounts account = new Accounts(player.Name, player);

            if (player.HasData("isInFFA"))
            {
                Utils.SendPlayerNotify(player, "", $"Du bist in einer FFA-Zone, Teamauswahl aktuell nicht verfügbar!", "red", 8000);
                return;
            }

            if (teamId == 1) // YakuZa Mafia
            {
                player.Position = new Vector3(-1521.4286f, 853.1868f, 181.58533f);
                player.Rotation = new Vector3(0, 0, 0.44526514f);

                //Weapons and some other stuff
                Utils.GiveWeaponsArmorHealthToPlayer(player);

                player.Armor = 99;
                player.Health = 99;

                player.SetClothes(1, 111, 5); // Maske
                player.SetClothes(4, 24, 4); //Hose
                player.SetClothes(11, 134, 1); // Oberteil
                player.SetClothes(8, 15, 0); // Undershirt
                player.SetClothes(6, 34, 0); // Schuhe
                player.SetClothes(3, 4, 0); //Torso
                player.SetClothes(9, 16, 2); // Weste
                player.SetAccessories(0, 30, 0); // Hut
                player.SetAccessories(1, 3, 0); // Brille

                player.ResetData("team1");
                player.ResetData("team2");
                player.ResetData("team3");
                player.ResetData("team4");
                player.ResetData("team5");
                player.ResetData("team6");

                player.SetData("team1", true);

                DatabaseHandler.SaveAccount(player);
            }

            if (teamId == 2) // Grove Street Families
            {
                player.Position = new Vector3(1382.7693f, -590.53186f, 74.3363f);
                player.Rotation = new Vector3(0, 0, 0.8905303f);

                //Weapons and some other stuff
                Utils.GiveWeaponsArmorHealthToPlayer(player);

                player.Armor = 99;
                player.Health = 99;

                player.SetClothes(1, 118, 0); // Maske
                player.SetClothes(4, 5, 6); //Hose
                player.SetClothes(11, 305, 7); // Oberteil
                player.SetClothes(8, 15, 0); // Undershirt
                player.SetClothes(6, 6, 0); // Schuhe
                player.SetClothes(3, 4, 0); //Torso
                player.SetClothes(9, 16, 2); // weste
                player.SetAccessories(1, 3, 0); // Brille
                player.SetAccessories(0, -1, 0); // Hut

                player.ResetData("team1");
                player.ResetData("team2");
                player.ResetData("team3");
                player.ResetData("team4");
                player.ResetData("team5");
                player.ResetData("team6");

                player.SetData("team2", true);

                DatabaseHandler.SaveAccount(player);
            }

            if (teamId == 3) // Varrios Los Aztecas
            {
                player.Position = new Vector3(1415.4989f, 3633.2966f, 34.654907f);
                player.Rotation = new Vector3(0, 0, -2.8694863f);

                //Weapons and some other stuff
                Utils.GiveWeaponsArmorHealthToPlayer(player);

                player.Armor = 99;
                player.Health = 99;

                player.SetClothes(1, 54, 0);
                player.SetClothes(4, 5, 3);
                player.SetClothes(11, 134, 2);
                player.SetClothes(8, 15, 0);
                player.SetClothes(6, 34, 0);
                player.SetClothes(3, 1, 0);
                player.SetClothes(9, 16, 2);
                player.SetAccessories(1, 3, 0); // Brille
                player.SetAccessories(0, -1, 0); // Hut


                player.ResetData("team1");
                player.ResetData("team2");
                player.ResetData("team3");
                player.ResetData("team4");
                player.ResetData("team5");
                player.ResetData("team6");

                player.SetData("team3", true);
                DatabaseHandler.SaveAccount(player);
            }

            if (teamId == 4) // 52 Hxxver Crips
            {
                player.Position = new Vector3(1286.5319f, -1603.5692f, 54.82422f);
                player.Rotation = new Vector3(0, 0, 0.24736951f);

                //Weapons and some other stuff
                Utils.GiveWeaponsArmorHealthToPlayer(player);

                player.Armor = 99;
                player.Health = 99;

                player.SetClothes(1, 118, 1); // Maske
                player.SetClothes(4, 5, 7); //Hose
                player.SetClothes(11, 96, 0); // Oberteil
                player.SetClothes(8, 15, 0); // Undershirt
                player.SetClothes(6, 34, 0); // Schuhe
                player.SetClothes(3, 4, 0); //Torso
                player.SetClothes(9, 16, 2); // weste
                player.SetAccessories(1, 3, 0); // Brille
                player.SetAccessories(0, -1, 0); // Hut

                player.ResetData("team1");
                player.ResetData("team2");
                player.ResetData("team3");
                player.ResetData("team4");
                player.ResetData("team5");
                player.ResetData("team6");

                player.SetData("team4", true);
                DatabaseHandler.SaveAccount(player);
            }

            if (teamId == 5) // La Cosa Nostra
            {
                player.Position = new Vector3(-1535.7627f, 97.63516f, 56.761963f);
                player.Rotation = new Vector3(0, 0, -2.2757995f);

                //Weapons and some other stuff
                Utils.GiveWeaponsArmorHealthToPlayer(player);

                player.Armor = 99;
                player.Health = 99;

                player.SetClothes(1, 111, 17); // Maske
                player.SetClothes(4, 24, 0); //Hose
                player.SetClothes(11, 111, 3); // Oberteil
                player.SetClothes(8, 15, 0); // Undershirt
                player.SetClothes(6, 34, 0); // Schuhe
                player.SetClothes(3, 12, 0); //Torso
                player.SetClothes(9, 16, 2); // weste
                player.SetAccessories(0, 12, 0); // Hut
                player.SetAccessories(1, 3, 0); // Brille

                player.ResetData("team1");
                player.ResetData("team2");
                player.ResetData("team3");
                player.ResetData("team4");
                player.ResetData("team5");
                player.ResetData("team6");

                player.SetData("team5", true);
                DatabaseHandler.SaveAccount(player);
            }

            if (teamId == 6) // Davis Braxton Ballas
            {
                player.Position = new Vector3(84.64616f, -1958.3737f, 21.107666f);
                player.Rotation = new Vector3(0, 0, -0.64316076f);

                //Weapons and some other stuff
                Utils.GiveWeaponsArmorHealthToPlayer(player);

                player.Armor = 99;
                player.Health = 99;

                player.SetClothes(1, 118, 2);
                player.SetClothes(4, 5, 9);
                player.SetClothes(11, 111, 3);
                player.SetClothes(8, 15, 0);
                player.SetClothes(6, 34, 0);
                player.SetClothes(3, 4, 0);
                player.SetClothes(9, 16, 2);
                player.SetAccessories(1, 3, 0); // Brille
                player.SetAccessories(0, -1, 0); // Hut

                player.ResetData("team1");
                player.ResetData("team2");
                player.ResetData("team3");
                player.ResetData("team4");
                player.ResetData("team5");
                player.ResetData("team6");

                player.SetData("team6", true);

                DatabaseHandler.SaveAccount(player);
            }
        }
    }
}
