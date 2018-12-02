using System.Collections.Generic;
using System.Linq;
using SQLite;
using TimeTracker.Data;

namespace TimeTracker.Controllers
{
    public class ProjectController
    {
        private static string _databaseFile = DatabaseHelper.GetDatabaseConnection();

        public static List<Project> GetProjects()
        {
            // Preconditon: database exists with Project table
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Project>().ToList();
            }
        }

        public static Project GetProjectByName(string _projectName)
        {
            // Preconditon: database exists with Project table and row containing given project name
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

        public static Project GetProjectById(int _projectId)
        {
            // Preconditon: database exists with Project table and row containing given project Id
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

        public static List<Project> GetProjectsByClientId(int _clientId)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                return db.Table<Project>().Where(p => p.ClientId == _clientId).ToList();
            }
        }

        public static void AddProject(Project _newProject)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Precondition: new project must not already exist but provided project must
                if (GetProjectByName(_newProject.Name) == null && _newProject != null)
                {
                    db.Insert(_newProject);
                }
            }
        }

        public static void DeleteProject(Project _project)
        {
            using (var db = new SQLiteConnection(_databaseFile, true))
            {
                // Precondition: project must already exist
                if (_project.Exists())
                {
                    db.Delete(_project);
                }
            }
        }
    }
}
