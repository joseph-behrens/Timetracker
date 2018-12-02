using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracker.Data;

namespace TimeTracker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        internal void SetReport()
        {
            var _clients = DatabaseHelper.GetClients();
            var _projects = DatabaseHelper.GetProjects();
            var _tasks = DatabaseHelper.GetTasks();

            foreach (var _task in _tasks)
            {
                Project _project = DatabaseHelper.GetProjectById(_task.ProjectId);
                Client _client = DatabaseHelper.GetClientById(_project.ClientId);
                dataGridView1.Rows.Add(_task.DateOfEntry, _task.TimeSpent, _client.Name, _project.Name, _task.Notes);
            }

            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }
    }
}
