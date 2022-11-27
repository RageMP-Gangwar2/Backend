using GTANetworkAPI;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace RageGW.Handler
{
    class FFASelection : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: FFASelection geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: FFASelection entladen", LoggerEnums.LogType.Info);
        }

        [RemoteEvent("Server:ffaBrowser:chooseFFA")]
        public void chooseFFA(Player player, int ffaid)
        {
            if (ffaid > 3)
            {
                Utils.SendPlayerNotify(player, "", $"Diese FFA-Zone existiert nicht du kannst nur die FFA-Zonen 1 - 3 auswählen!", "red", 8000);
                return;
            }

            if (player.HasData("isInFFA"))
            {
                Utils.SendPlayerNotify(player, "", $"Du bist bereits in einer FFA-Zone!", "red", 8000);
                return;
            }

            //Würfelpark
            if (ffaid == 1)
            {
                player.SetData("isInFFA", true);
                player.SetData("FFA1", true);
                player.Dimension = 187;

                Utils.SendPlayerNotify(player, "", "FFA-Zone | Würfelpark betreten!", "green", 8000);

                int rnd = new Random().Next(1, 120);

                if (rnd >= 3 && rnd <= 24)
                {
                    player.Position = new Vector3(258.52747f, -875.9077f, 29.212402f);
                }
                else if (rnd >= 24 && rnd <= 48)
                {
                    player.Position = new Vector3(218.42638f, -937.5165f, 24.140625f);
                }
                else if (rnd >= 48 && rnd <= 72)
                {
                    player.Position = new Vector3(204.03957f, -993.7187f, 30.088623f);
                }
                else if (rnd >= 72 && rnd <= 96)
                {
                    player.Position = new Vector3(207.53406f, -994.66825f, 29.279907f);
                }
                else if (rnd >= 96 && rnd <= 120)
                {
                    player.Position = new Vector3(160.68132f, -999.0857f, 29.330444f);
                }
            }

            //Triaden
            if (ffaid == 2)
            {
                player.SetData("isInFFA", true);
                player.SetData("FFA2", true);
                player.Dimension = 187;

                Utils.SendPlayerNotify(player, "", "FFA-Zone | Triaden betreten!", "green", 8000);

                int rnd = new Random().Next(1, 120);

                if (rnd >= 3 && rnd <= 24)
                {
                    player.Position = new Vector3(1481.1019f, 1114.8245f, 114.33454f);
                }
                else if (rnd >= 24 && rnd <= 48)
                {
                    player.Position = new Vector3(1481.1019f, 1114.8245f, 114.33454f);
                }
                else if (rnd >= 48 && rnd <= 72)
                {
                    player.Position = new Vector3(1433.3723f, 1184.334f, 114.15171f);
                }
                else if (rnd >= 72 && rnd <= 96)
                {
                    player.Position = new Vector3(1370.4058f, 1147.5156f, 113.75894f);
                }
                else if (rnd >= 96 && rnd <= 120)
                {
                    player.Position = new Vector3(1406.6914f, 1117.7511f, 114.83774f);
                }
            }

            //Kirche
            if (ffaid == 3)
            {
                player.SetData("isInFFA", true);
                player.SetData("FFA3", true);
                player.Dimension = 187;

                Utils.SendPlayerNotify(player, "", "FFA-Zone | Kirche betreten!", "green", 8000);

                int rnd = new Random().Next(1, 120);

                if (rnd >= 3 && rnd <= 24)
                {
                    player.Position = new Vector3(-297.96716f, 2791.2646f, 60.21791f);
                }
                else if (rnd >= 24 && rnd <= 48)
                {
                    player.Position = new Vector3(-352.33957f, 2776.2683f, 58.762897f);
                }
                else if (rnd >= 48 && rnd <= 72)
                {
                    player.Position = new Vector3(-324.68524f, 2826.234f, 58.090813f);
                }
                else if (rnd >= 72 && rnd <= 96)
                {
                    player.Position = new Vector3(-287.95786f, 2851.0635f, 53.976055f);
                }
                else if (rnd >= 96 && rnd <= 120)
                {
                    player.Position = new Vector3(-270.33453f, 2802.7888f, 54.74635f);
                }
            }
        }
    }
}
