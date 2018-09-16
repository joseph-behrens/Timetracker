using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TimeTracker
{
    [Serializable]
    public class ProjectTask
    {
        public string ProjectTitle { get; set; }
        public string ProjectNotes { get; set; }
        public string TimeSpent { get; set; }
        public string DateOfEntry { get => dateOfEntry; }

        private string dateOfEntry = DateTime.Now.ToString("yyyy/M/d h:mm tt");

        public ProjectTask()
        {

        }

        public ProjectTask (string projectTitle, string projectNotes, string timeSpent)
        {
            ProjectTitle = projectTitle;
            ProjectNotes = projectNotes;
            TimeSpent = timeSpent;
        }
    }
}
