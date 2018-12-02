using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace TimeTracker.Data
{
    public class DatabaseHelper
    {
        private static readonly string _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string _timeTrackerFolder = Path.Combine(_appDataFolder, "TimeTracker");
        private static readonly string _databaseFile = Path.Combine(_timeTrackerFolder, "TimeTracker.db");

        public static void InitialiseDb()
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                db.CreateTable<Task>();
                db.CreateTable<Client>();
                db.CreateTable<Project>();
                db.Close();
            }
        }

        public static List<Client> GetClients()
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Client>().ToList();
            }
        }

        public static Client GetClientByName(string _clientName)
        {
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

        public static List<Project> GetProjects()
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Project>().ToList();
            }
        }

        public static Project GetProjectByName(string _projectName)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                try
                {
                    return db.Table<Project>().Where(p => p.Name == _projectName).First();
                }
                catch
                {
                    return null;
                }
            }
        }

        internal static Project GetProjectById(int _projectId)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                try
                {
                    return db.Table<Project>().Where(p => p.Id == _projectId).First();
                }
                catch
                {
                    return null;
                }
            }
        }

        internal static List<Project> GetProjectsByClientId(int _clientId)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Project>().Where(p => p.ClientId == _clientId).ToList();
            }
        }

        public static List<Task> GetTasks()
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Task>().ToList();
            }
        }

        internal static void AddTask(Task _newTask)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                db.Insert(_newTask);
            }
        }

        internal static void AddClient(Client _newClient)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                db.Insert(_newClient);
            }
        }

        internal static void AddProject(Project _newProject)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Precondition
                if ( GetProjectByName(_newProject.Name) == null )
                {
                    db.Insert(_newProject);
                }
            }
        }
    }
}
