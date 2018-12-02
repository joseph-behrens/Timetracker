﻿using System;
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
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Task>().ToList();
            }
        }

        public static void AddTask(Task _newTask)
        {
            // Precondtion given task is not null
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                if (_newTask != null)
                {
                    db.Insert(_newTask);
                }
            }
        }

        public static void DeleteTask(Task _task)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                db.Delete(_task);
            }
        }
    }
}
