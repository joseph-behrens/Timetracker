using System.Collections.Generic;
using SQLite;
using System.Linq;
using TimeTracker.Data;

namespace TimeTracker.Controllers
{
    public class ClientController
    {
        private static string _databaseFile = DatabaseHelper.GetDatabaseConnection();

        public static List<Client> GetClients()
        {
            // Preconditon: database exists with Client table
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Client>().ToList();
            }
        }

        public static Client GetClientByName(string _clientName)
        {
            // Preconditon: database exists with Client table and row with provided client name
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
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

        internal static Client GetClientById(int _clientId)
        {
            // Preconditon: database exists with Client table and row with provided client name
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
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

        internal static void AddClient(Client _newClient)
        {
            // Precondition: given client ojbect is not null
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                if (_newClient != null)
                {
                    db.Insert(_newClient);
                }
            }
        }

    }
}
