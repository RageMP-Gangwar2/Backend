using GTANetworkAPI;
using RageGW.Modules.Database;
using RageGW.Modules.Logger;
using RageGW.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RageGW.Handler
{
    class VehicleSelection : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: VehicleSelection geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: VehicleSelection entladen", LoggerEnums.LogType.Info);
        }

        [RemoteEvent("Server:garageBrowser:selectVehicle")]
        public void selectVehicle(Player player, int vehicleid)
        {
            try
            {
                Accounts account = player.GetData<Accounts>(Accounts.Account_Key);


                //YakuZa
                if (player.HasData("team1"))
                {
                    if (vehicleid == 1)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Bati, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 2)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Primo2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 3)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Sultan2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 4)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Dominator, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 5)
                    {
                        if (account.Level >= 10)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Elegy, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 6)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Drafter, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 7)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Jugular, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 8)
                    {
                        if (account.Level >= 25)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(0x27816B7E, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 9)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Omnis, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 10)
                    {
                        if (account.Level >= 30)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Cyclone, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 11)
                    {
                        if (account.Level >= 35)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Emerus, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "YakuZa";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 44;
                            veh1.SecondaryColor = 44;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }
                }

                //Grove
                else if (player.HasData("team2"))
                {
                    if (vehicleid == 1)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Bati, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 2)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Primo2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 3)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Sultan2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 4)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Dominator, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 5)
                    {
                        if (account.Level >= 10)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Elegy, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 6)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Drafter, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 7)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Jugular, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 8)
                    {
                        if (account.Level >= 25)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(0x27816B7E, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 9)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Omnis, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 10)
                    {
                        if (account.Level >= 30)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Cyclone, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 11)
                    {
                        if (account.Level >= 35)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Emerus, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Grove";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 53;
                            veh1.SecondaryColor = 53;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }
                }

                //Aztecas
                else if (player.HasData("team3"))
                {
                    if (vehicleid == 1)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Bati, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 2)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Primo2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 3)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Sultan2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 4)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Dominator, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 5)
                    {
                        if (account.Level >= 10)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Elegy, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 6)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Drafter, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 7)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Jugular, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 8)
                    {
                        if (account.Level >= 25)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(0x27816B7E, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 9)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Omnis, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 10)
                    {
                        if (account.Level >= 30)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Cyclone, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 11)
                    {
                        if (account.Level >= 35)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Emerus, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Aztecas";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 140;
                            veh1.SecondaryColor = 140;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }
                }

                //Hxxver
                else if (player.HasData("team4"))
                {
                    if (vehicleid == 1)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Bati, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 2)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Primo2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 3)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Sultan2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 4)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Dominator, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 5)
                    {
                        if (account.Level >= 10)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Elegy, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 6)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Drafter, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 7)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Jugular, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 8)
                    {
                        if (account.Level >= 25)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(0x27816B7E, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 9)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Omnis, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 10)
                    {
                        if (account.Level >= 30)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Cyclone, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 11)
                    {
                        if (account.Level >= 35)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Emerus, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "Hxxver";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 38;
                            veh1.SecondaryColor = 38;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }
                }

                //LCN
                else if (player.HasData("team5"))
                {
                    if (vehicleid == 1)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Bati, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 2)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Primo2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 3)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Sultan2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 4)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Dominator, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 5)
                    {
                        if (account.Level >= 10)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Elegy, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 6)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Drafter, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 7)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Jugular, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 8)
                    {
                        if (account.Level >= 25)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(0x27816B7E, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 9)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Omnis, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 10)
                    {
                        if (account.Level >= 30)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Cyclone, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 11)
                    {
                        if (account.Level >= 35)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Emerus, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "LCN";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 0;
                            veh1.SecondaryColor = 0;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }
                }

                //D.B.B
                else if (player.HasData("team6"))
                {
                    if (vehicleid == 1)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Bati, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 2)
                    {
                        if (account.Level >= 1)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Primo2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 3)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Sultan2, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 4)
                    {
                        if (account.Level >= 5)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Dominator, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 5)
                    {
                        if (account.Level >= 10)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Elegy, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 6)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Drafter, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 7)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Jugular, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 8)
                    {
                        if (account.Level >= 25)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(0x27816B7E, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 9)
                    {
                        if (account.Level >= 15)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Omnis, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 10)
                    {
                        if (account.Level >= 30)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Cyclone, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }

                    if (vehicleid == 11)
                    {
                        if (account.Level >= 35)
                        {
                            Vehicle veh1 = NAPI.Vehicle.CreateVehicle(VehicleHash.Emerus, player.Position, player.Heading, 0, 0);
                            veh1.NumberPlate = "D.B.B";
                            veh1.Locked = false;
                            veh1.EngineStatus = true;
                            veh1.Dimension = player.Dimension;

                            veh1.PrimaryColor = 145;
                            veh1.SecondaryColor = 145;



                            player.SetIntoVehicle(veh1, (int)VehicleSeat.Driver);
                            Utils.SendPlayerNotify(player, "", "Fahrzeug erfolgreich gespawnt!", "green", 8000);
                        }
                        else
                        {
                            Utils.SendPlayerNotify(player, "", "Dein aktuelles Level reicht für dieses Fahrzeug nicht aus!", "red", 8000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write($"VehicleSelection: " + ex.ToString(), LoggerEnums.LogType.Warning);
            }
        }
    }
}
