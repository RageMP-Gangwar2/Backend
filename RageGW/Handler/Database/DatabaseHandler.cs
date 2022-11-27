using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using RageGW.Modules.Logger;
using RageGW.Handler.Login;
using RageGW.Handler;

namespace RageGW.Modules.Database
{
    class DatabaseHandler
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Logger.Write("Handler: DatabaseHandler geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Logger.Write("Handler: DatabaseHandler entladen", LoggerEnums.LogType.Info);
        }

        public static bool DatabaseConnection = false;
        public static MySqlConnection Connection;
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public DatabaseHandler()
        {
            this.Host = "localhost";
            this.Username = "root";
            this.Password = "";
            this.Database = "ragegw";
        }

        public static void InitConnection()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = false;

            DatabaseHandler sql = new DatabaseHandler();
            string SQLConnection = $"SERVER={sql.Host}; DATABASE={sql.Database}; UID={sql.Username}; PASSWORD={sql.Password}";
            Connection = new MySqlConnection(SQLConnection);

            try
            {
                Connection.Open();
                DatabaseConnection = true;
                Logger.Logger.Write("[MYSQL] -> Verbindung erfolgreich hergestellt!", LoggerEnums.LogType.Info);
            }
            catch (Exception ex)
            {
                DatabaseConnection = false;
                Logger.Logger.Write("[MYSQL] -> Verbindung konnte nicht hergestellt werden!", LoggerEnums.LogType.Info);
                Logger.Logger.Write("[MYSQL] -> Fehler gefunden: " + ex.ToString(), LoggerEnums.LogType.Info);
            }
        }

        public static bool IsAccountAlreadyExist(string name)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", name);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
            }
            return false;
        }

        public static void CreateNewAccount(Accounts account, string password)
        {
            string saltedpw = BCrypt.HashPassword(password, BCrypt.GenerateSalt());

            try
            {
                MySqlCommand command = Connection.CreateCommand();
                command.CommandText = "INSERT INTO accounts (name, password) VALUES (@name, @password)";

                command.Parameters.AddWithValue("@name", account.Name);
                command.Parameters.AddWithValue("@password", saltedpw);

                command.ExecuteNonQuery();

                account.ID = (int)command.LastInsertedId;

                Logger.Logger.Write($"[CreateNewAccount]: Account erstellt | ID: {account.ID}, Name: {account.Name}", LoggerEnums.LogType.Info);
            }
            catch (Exception ex)
            {
                Logger.Logger.Write($"[CreateNewAccount]: " + ex.ToString(), LoggerEnums.LogType.Error);
            }
        }

        public static void LoadAccount(Accounts account)
        {
            try
            {
                MySqlCommand command = Connection.CreateCommand();
                command.CommandText = "SELECT * FROM accounts WHERE name=@name LIMIT 1";
                command.Parameters.AddWithValue("@name", account.Name);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        account.ID = reader.GetInt16("id");
                        account.Adminlevel = reader.GetInt16("adminlevel");
                        account.Kills = reader.GetInt16("kills");
                        account.Deaths = reader.GetInt16("deaths");
                        account.KD = reader.GetInt16("kd");
                        account.Level = reader.GetInt16("level");
                        account.Money = reader.GetInt32("money");
                        account.XP = reader.GetInt16("xp");
                        account.Kit = reader.GetInt16("kit");
                        account.Ban = reader.GetInt16("ban");
                        account.BanReason = reader.GetString("banreason");
                        account.ADVschalli = reader.GetInt16("advschalli");
                        account.ADVvisier = reader.GetInt16("advvisier");
                        account.ADVmagazin = reader.GetInt16("advmagazin");
                        account.Bullischalli = reader.GetInt16("bullischalli");
                        account.Bullivisier = reader.GetInt16("bullivisier");
                        account.Bullimagazin = reader.GetInt16("bullimagazin");
                        account.Spezischalli = reader.GetInt16("spezischalli");
                        account.Spezivisier = reader.GetInt16("spezivisier");
                        account.Spezimagazin = reader.GetInt16("spezimagazin");
                        account.Gusimagazin = reader.GetInt16("gusimagazin");
                        account.PrivateFaction = reader.GetInt16("privatefaction");
                        account.PrivateFaction_Rank = reader.GetInt16("privatefaction_rank");
                    }
                }

                Logger.Logger.Write($"[LoadAccount]: Konto geladen | ID: {account.ID}, Name: {account.Name}", LoggerEnums.LogType.Info);
            }
            catch (Exception ex)
            {
                Logger.Logger.Write($"[LoadAccount]: " + ex.ToString(), LoggerEnums.LogType.Error);
            }
        }

        public static void SaveAccount(Player player)
        {
            try
            {
                Accounts account = player.GetData<Accounts>(Accounts.Account_Key);
                if (account == null) return;
                MySqlCommand command = Connection.CreateCommand();
                command.CommandText = "UPDATE accounts SET adminlevel=@adminlevel, kills=@kills, deaths=@deaths, kd=@kd, level=@level, money=@money, xp=@xp, kit=@kit, ban=@ban, banreason=@banreason, advschalli=@advschalli, advvisier=@advvisier, advmagazin=@advmagazin, bullischalli=@bullischalli, bullivisier=@bullivisier, bullimagazin=@bullimagazin, spezischalli=@spezischalli, spezivisier=@spezivisier, spezimagazin=@spezimagazin, gusimagazin=@gusimagazin, privatefaction=@privatefaction, privatefaction_rank=@privatefaction_rank WHERE id=@id";

                command.Parameters.AddWithValue("@adminlevel", account.Adminlevel);
                command.Parameters.AddWithValue("@kills", account.Kills);
                command.Parameters.AddWithValue("@deaths", account.Deaths);
                command.Parameters.AddWithValue("@kd", account.KD);
                command.Parameters.AddWithValue("@level", account.Level);
                command.Parameters.AddWithValue("@money", account.Money);
                command.Parameters.AddWithValue("@xp", account.XP);
                command.Parameters.AddWithValue("@kit", account.Kit);
                command.Parameters.AddWithValue("@ban", account.Ban);
                command.Parameters.AddWithValue("@banreason", account.BanReason);
                command.Parameters.AddWithValue("@advschalli", account.ADVschalli);
                command.Parameters.AddWithValue("@advvisier", account.ADVvisier);
                command.Parameters.AddWithValue("@advmagazin", account.ADVmagazin);
                command.Parameters.AddWithValue("@bullischalli", account.Bullischalli);
                command.Parameters.AddWithValue("@bullivisier", account.Bullivisier);
                command.Parameters.AddWithValue("@bullimagazin", account.Bullimagazin);
                command.Parameters.AddWithValue("@spezischalli", account.Spezischalli);
                command.Parameters.AddWithValue("@spezivisier", account.Spezivisier);
                command.Parameters.AddWithValue("@spezimagazin", account.Spezimagazin);
                command.Parameters.AddWithValue("@gusimagazin", account.Gusimagazin);
                command.Parameters.AddWithValue("@privatefaction", account.PrivateFaction);
                command.Parameters.AddWithValue("@privatefaction_rank", account.PrivateFaction_Rank);
                command.Parameters.AddWithValue("@id", account.ID);
                command.ExecuteNonQuery();

                Logger.Logger.Write($"[LoadAccount]: Konto gespeichert | ID: {account.ID}, Name: {account.Name}", LoggerEnums.LogType.Info);
            }
            catch (Exception ex)
            {
                Logger.Logger.Write($"[SaveAccount]: " + ex.ToString(), LoggerEnums.LogType.Error);
            }
        }

        public static bool CheckPassword(string name, string passwordinput)
        {
            string password = null;

            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT password FROM accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", name);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    password = reader.GetString("password");
                }
            }

            if (BCrypt.CheckPassword(passwordinput, password)) return true;
            return false;
        }

        public static bool CheckAccount(string name)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT id FROM accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", name);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
