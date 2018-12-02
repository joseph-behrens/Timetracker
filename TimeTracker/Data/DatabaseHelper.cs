using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;

namespace TimeTracker.Data
{
    public class DatabaseHelper
    {
        private static string _databaseFile = GetDatabaseConnection();

        public static void InitialiseDb()
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                db.CreateTable<Task>();
                db.CreateTable<Client>();
                db.CreateTable<Project>();
            }
        }

        public static string GetDatabaseConnection()
        {
            string _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string _timeTrackerFolder = Path.Combine(_appDataFolder, "TimeTracker");
            return Path.Combine(_timeTrackerFolder, "TimeTracker.db");
        }
           
    }
}
