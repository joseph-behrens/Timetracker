﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TimeTracker
{
    public class SqLiteDb
    {
        private static readonly string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string timeTrackerFolder = Path.Combine(appDataFolder, "TimeTracker");
        private static readonly string databaseFile = Path.Combine(timeTrackerFolder, "TimeTracker.db");
        private static readonly string connectionString = "Data Source=" + databaseFile + ";Version=3;";
        public static string GetPath()
        {
            if (!File.Exists(databaseFile))
            {
                Directory.CreateDirectory(timeTrackerFolder);
                SQLiteConnection.CreateFile(databaseFile);
                using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
                {
                    dbConnection.Open();
                    // TODO: Better design database and classes, Project should be own, TimeEntry should be own, etc.
                    string sql = "CREATE TABLE ProjectTask (ProjectTitle VARCHAR(32), ProjectNotes VARCHAR(250), TimeSpent VARCHAR(32), DateOfEntry VARCHAR(32));";
                    SQLiteCommand cmd = new SQLiteCommand(sql, dbConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            return databaseFile;
        }

        public static List<ProjectTask> GetProjectTasks()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                List<ProjectTask> ProjectTasks = new List<ProjectTask>();
                dbConnection.Open();
                string sql = "SELECT * FROM ProjectTask;";
                SQLiteCommand cmd = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjectTask thisTask = new ProjectTask(reader["ProjectTitle"].ToString(), reader["ProjectNotes"].ToString(), reader["TimeSpent"].ToString(), reader["DateOfEntry"].ToString());
                    ProjectTasks.Add(thisTask);
                }
                return ProjectTasks;
            }
        }

        public static void AddTask(ProjectTask projectTask)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sql = String.Format("INSERT INTO ProjectTask (ProjectTitle, ProjectNotes, TimeSpent, DateOfEntry) VALUES ('{0}','{1}','{2}','{3}');",
                    projectTask.ProjectTitle, projectTask.ProjectNotes, projectTask.TimeSpent, projectTask.DateOfEntry);
                SQLiteCommand cmd = new SQLiteCommand(sql, dbConnection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
