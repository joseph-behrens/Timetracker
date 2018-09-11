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
    public class Report
    {
        public static IEnumerable<ProjectTask> ViewReport()
        {
            return SqLiteDb.GetProjectTasks();
        }
    }
}
