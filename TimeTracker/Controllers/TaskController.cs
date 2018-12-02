using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TimeTracker.Data;

namespace TimeTracker.Controllers
{
    public class TaskController
    {
        private static string _databaseFile = DatabaseHelper.GetDatabaseConnection();

        public static List<Task> GetTasks()
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Task>().ToList();
            }
        }

        public static void AddTask(Task _newTask)
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Precondtion given task is not null
                if (_newTask != null)
                {
                    db.Insert(_newTask);
                }
            }
        }

        public static void DeleteTask(Task _task)
        {
            DatabaseExceptions.ValidateConnectionString(_databaseFile);

            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Precondtion given task is not null
                if (_task != null)
                {
                    db.Delete(_task);
                }
            }
        }
    }
}
