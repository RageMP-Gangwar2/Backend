using GTANetworkAPI;
using Org.BouncyCastle.Asn1.X509;
using RageGW.Modules.Database;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;

namespace RageGW.Handler.Login
{
    class LoginHandler : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: LoginHandler geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: LoginHandler entladen", LoggerEnums.LogType.Info);
        }

        [RemoteEvent("Auth.OnLogin")]
        public void OnLogin(Player player, string password)
        {
            if (Accounts.IsAccountAlreadyLoggedIn(player))
            {
                Utils.SendPlayerNotify(player, "", "Du bist bereits eingeloggt!", "red", 5000);
                return;
            }
            if (!DatabaseHandler.CheckPassword(player.Name, password))
            {
                Utils.SendPlayerNotify(player, "", "Falsches Passwort!", "red", 5000);
                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 1500);
                return;
            }
            Accounts account = new Accounts(player.Name, player);
            account.Login(player, false);
            NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", false);
            Utils.SendPlayerNotify(player, "", "Erfolgreich eingeloggt", "green", 5000);
            player.Health = 99;

            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (accountPlayer.Ban == 1)
            {
                Utils.SendPlayerNotify(player, "", $"Du bist vom Server gebannt Grund: {accountPlayer.BanReason} bitte melde dich im Support für mehr Infos", "red", 15000);

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 1000);
                return;
            }

            //Open TeamSelection
            player.TriggerEvent("Client:TeamBrowser:createBrowser");

            //Open Hud and set all Data

            Utils.ShowHud(player, account.Kills, account.Deaths, account.Level, account.Money);

            //Give WeaponComponents

            //Schalli ADV
            if (account.ADVschalli == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Advancedrifle, WeaponComponent.AtArSupp);
            }
            else
            {
                return;
            }

            //Visier ADV
            if (account.ADVvisier == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Advancedrifle, WeaponComponent.AtScopeSmall);
            }
            else
            {
                return;
            }

            //Magazin ADV
            if (account.ADVvisier == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Advancedrifle, WeaponComponent.AdvancedRifleClip02);
            }
            else
            {
                return;
            }

            //Schalli Bulli
            if (account.Bullischalli == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Bullpuprifle, WeaponComponent.AtArSupp);
            }
            else
            {
                return;
            }

            //Visier Bulli
            if (account.Bullivisier == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Bullpuprifle, WeaponComponent.AtScopeSmall);
            }
            else
            {
                return;
            }

            //Magazin Bulli
            if (account.Bullivisier == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Bullpuprifle, WeaponComponent.BullpupRifleClip02);
            }
            else
            {
                return;
            }

            //Schalli Spezi
            if (account.Spezischalli == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Specialcarbine, WeaponComponent.AtArSupp02);
            }
            else
            {
                return;
            }

            //Visier Spezi
            if (account.Spezivisier == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Specialcarbine, WeaponComponent.AtScopeMedium);
            }
            else
            {
                return;
            }

            //Magazin Spezi
            if (account.Spezivisier == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Specialcarbine, WeaponComponent.SpecialCarbineClip02);
            }
            else
            {
                return;
            }

            //Magazin Gusi
            if (account.Gusimagazin == 1)
            {
                Utils.SetOwnWeaponComponent(player, WeaponHash.Gusenberg, WeaponComponent.GusenbergClip02);
            }
            else
            {
                return;
            }
        }

        [RemoteEvent("Auth.OnRegister")]
        public void OnRegister(Player player, string password)
        {
            if (DatabaseHandler.IsAccountAlreadyExist(player.Name))
            {
                Utils.SendPlayerNotify(player, "", "Dieser Account existiert bereits!", "red", 5000);
                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 1500);
                return;
            }
            Accounts account = new Accounts(player.Name, player);
            account.Register(player.Name, password);
            NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", false);
            Utils.SendPlayerNotify(player, "", "Erfolgreich registriert", "green", 5000);
            player.Health = 99;

            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            if (accountPlayer.Ban == 1)
            {
                Utils.SendPlayerNotify(player, "", $"Du bist vom Server gebannt Grund: {accountPlayer.BanReason} bitte melde dich im Support für mehr Infos", "red", 15000);

                NAPI.Task.Run(() =>
                {
                    player.Kick();
                }, delayTime: 1000);
                return;
            }

            //Open TeamSelection
            player.TriggerEvent("Client:TeamBrowser:createBrowser");

            //Open Hud and set all Data
            Utils.ShowHud(player, account.Kills, account.Deaths, account.Level, account.Money);
        }
    }
}
