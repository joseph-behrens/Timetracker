using System.Collections.Generic;
using SQLite;
using System.Linq;
using TimeTracker.Data;
using System;

namespace TimeTracker.Controllers
{
    public class ClientController
    {
        private static string _databaseFile = DatabaseHelper.GetDatabaseConnection();

        public static List<Client> GetClients()
        {
            // Preconditons: database exists
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Client>().ToList();
            }
        }

        public static Client GetClientByName(string _clientName)
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Preconditon: database exists with Client table and row with provided client name
                try
                {
                    return db.Table<Client>().Where(c => c.Name == _clientName).First();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static Client GetClientById(int _clientId)
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Preconditon: database exists with Client table and row with provided client name
                try
                {
                    return db.Table<Client>().Where(c => c.Id == _clientId).First();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void DeleteProject(Client _client)
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                //Preconditon: client to delete must exist
                if (_client.Exists())
                {
                    db.Delete(_client);
                }
            }
        }

        public static void AddClient(Client _newClient)
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Precondition: given client ojbect is not null                
                if (_newClient != null)
                {
                    db.Insert(_newClient);
                }
            }
        }
    }
}
