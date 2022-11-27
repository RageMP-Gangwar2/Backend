using GTANetworkAPI;
using RageGW.Modules.Database;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageGW.Handler
{
    class AufsatzSelection : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: AufsatzSelection geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: AufsatzSelection entladen", LoggerEnums.LogType.Info);
        }

        [RemoteEvent("Server:aufsatzBrowser:chooseWeaponCompADV")]
        public void chooseWeaponCompADV(Player player, int compid)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            // Advancedrifle
            if (player.CurrentWeapon == WeaponHash.Advancedrifle)
            {
                //Schalli
                if (compid == 1)
                {
                    if (accountPlayer.Money < 2500) // weniger als 2500$
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.ADVschalli = 1;

                        accountPlayer.Money -= 2500;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Advancedrifle, WeaponComponent.AtArSupp);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Schalldämpfer auf deine Advancedrifle geschraubt!", "red", 8000);
                    }
                }

                //Visier
                if (compid == 2)
                {
                    if (accountPlayer.Money < 5000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.ADVvisier = 1;

                        accountPlayer.Money -= 5000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Advancedrifle, WeaponComponent.AtScopeSmall);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Visier auf deine Advancedrifle geschraubt!", "red", 8000);
                    }
                }

                //Magazin
                if (compid == 3)
                {
                    if (accountPlayer.Money < 15000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.ADVmagazin = 1;

                        accountPlayer.Money -= 15000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Advancedrifle, WeaponComponent.AdvancedRifleClip02);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Erweitertes Magazin in deine Advancedrifle gesteckt!", "red", 8000);
                    }
                }
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du hast keine Advancedrifle in der Hand!", "red", 8000);
                return;
            }
        }

        //BullpupRifle
        [RemoteEvent("Server:aufsatzBrowser:chooseWeaponCompBulli")]
        public void chooseWeaponCompBulli(Player player, int compid)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            // Bullpuprifle
            if (player.CurrentWeapon == WeaponHash.Bullpuprifle)
            {
                //Schalli
                if (compid == 1)
                {
                    if (accountPlayer.Money < 2500) // weniger als 2500$
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Bullischalli = 1;

                        accountPlayer.Money -= 2500;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Bullpuprifle, WeaponComponent.AtArSupp);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Schalldämpfer auf deine Bullpuprifle geschraubt!", "red", 8000);
                    }
                }

                //Visier
                if (compid == 2)
                {
                    if (accountPlayer.Money < 5000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Bullivisier = 1;

                        accountPlayer.Money -= 5000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Bullpuprifle, WeaponComponent.AtScopeSmall);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Visier auf deine Bullpuprifle geschraubt!", "red", 8000);
                    }
                }

                //Magazin
                if (compid == 3)
                {
                    if (accountPlayer.Money < 15000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Bullimagazin = 1;

                        accountPlayer.Money -= 15000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Bullpuprifle, WeaponComponent.BullpupRifleClip02);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Erweitertes Magazin in deine Bullpuprifle gesteckt!", "red", 8000);
                    }
                }
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du hast keine Bullpuprifle in der Hand!", "red", 8000);
                return;
            }
        }

        //SpecialCarbine
        [RemoteEvent("Server:aufsatzBrowser:chooseWeaponCompSpezi")]
        public void chooseWeaponCompSpezi(Player player, int compid)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            // Specialcarbine
            if (player.CurrentWeapon == WeaponHash.Specialcarbine)
            {
                //Schalli
                if (compid == 1)
                {
                    if (accountPlayer.Money < 2500) // weniger als 2500$
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Spezischalli = 1;

                        accountPlayer.Money -= 2500;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Specialcarbine, WeaponComponent.AtArSupp02);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Schalldämpfer auf deine Specialcarbine geschraubt!", "red", 8000);
                    }
                }

                //Visier
                if (compid == 2)
                {
                    if (accountPlayer.Money < 5000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Spezivisier = 1;

                        accountPlayer.Money -= 5000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Specialcarbine, WeaponComponent.AtScopeMedium);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Visier auf deine Specialcarbine geschraubt!", "red", 8000);
                    }
                }

                //Magazin
                if (compid == 3)
                {
                    if (accountPlayer.Money < 15000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Spezimagazin = 1;

                        accountPlayer.Money -= 15000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Specialcarbine, WeaponComponent.SpecialCarbineClip02);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Erweitertes Magazin in deine Specialcarbine gesteckt!", "red", 8000);
                    }
                }
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du hast keine Specialcarbine in der Hand!", "red", 8000);
                return;
            }
        }

        //Gusenberg
        [RemoteEvent("Server:aufsatzBrowser:chooseWeaponCompGusi")]
        public void chooseWeaponCompGusi(Player player, int compid)
        {
            Accounts accountPlayer = player.GetData<Accounts>(Accounts.Account_Key);

            // Gusenberg
            if (player.CurrentWeapon == WeaponHash.Gusenberg)
            {
                //Magazin
                if (compid == 1)
                {
                    if (accountPlayer.Money < 15000)
                    {
                        Utils.SendPlayerNotify(player, "", "Du hast nicht genügend geld!", "red", 8000);
                        return;
                    }
                    else
                    {
                        accountPlayer.Gusimagazin = 1;

                        accountPlayer.Money -= 15000;

                        DatabaseHandler.SaveAccount(player);
                        Utils.RefreshHud(player, accountPlayer.Kills, accountPlayer.Deaths, accountPlayer.Level, accountPlayer.Money);

                        Utils.SetOwnWeaponComponent(player, WeaponHash.Gusenberg, WeaponComponent.GusenbergClip02);

                        Utils.SendPlayerNotify(player, "", "Du hast ein Erweitertes Magazin in deine Gusenberg gesteckt!", "red", 8000);
                    }
                }
            }
            else
            {
                Utils.SendPlayerNotify(player, "", "Du hast keine Gusenberg in der Hand!", "red", 8000);
                return;
            }
        }
    }
}
