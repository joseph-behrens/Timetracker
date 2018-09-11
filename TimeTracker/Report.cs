using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TimeTracker
{
    [Serializable]
    public class Report
    {

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TimeTracker/data.xml");
        List<ProjectTask> trackedProjects;
        public Report() { }
        public void SaveList()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var timeTrackerFolder = Path.Combine(appDataFolder, "TimeTracker");
            Directory.CreateDirectory(timeTrackerFolder);
            XmlSerializer xs = new XmlSerializer(typeof(List<ProjectTask>));
            TextWriter tw = new StreamWriter(filePath);
            xs.Serialize(tw, trackedProjects);
            tw.Close();
        }

        public void OpenList()
        {
            using (var sr = new StreamReader(filePath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<ProjectTask>));
                trackedProjects = (List<ProjectTask>)xs.Deserialize(sr);
            }
        }

        public void AddTaskToList(ProjectTask projectTask)
        {
            if(trackedProjects == null)
            {
                trackedProjects = new List<ProjectTask>() { projectTask };
            }
            else
            {
                trackedProjects.Add(projectTask);
            }
        }

        public IEnumerable<ProjectTask> ViewReport()
        {
            return SqLiteDb.GetProjectTasks();
        }
    }
}
