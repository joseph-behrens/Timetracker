using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using TimeTracker.Data;

/// <summary>
/// TODO: Add stopwatch class and move stopWatch logic
/// </summary>
namespace TimeTracker
{
    public partial class Form1 : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        TimeSpan addedTime;

        public Form1()
        {
            DatabaseHelper.InitialiseDb();
            InitializeComponent();
            UpdateClientDropDown();
            toolTip1.SetToolTip(buttonHup, "Add one hour");
            toolTip1.SetToolTip(buttonHdown, "Subtract one hour");
            toolTip1.SetToolTip(buttonMup, "Add one minute");
            toolTip1.SetToolTip(buttonMdown, "Subtract one minute");
            toolTip1.SetToolTip(buttonOpenAnother, "Open another TimeTracker");
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning == false)
            {
                stopWatch.Start();
                timer1.Start();
                button1.Text = "||";
            }
            else
            {
                stopWatch.Stop();
                timer1.Stop();
                button1.Text = ">";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTimeText();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning == true)
            {
                stopWatch.Stop();
            }
            stopWatch.Reset();
            UpdateTimeText();
            button1.Text = ">";
        }

        private void UpdateTimeText()
        {
            TimeSpan ts = stopWatch.Elapsed + addedTime;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            if(ts >= new TimeSpan(0, 0, 0))
            {
                textBoxTime.Text = elapsedTime;
            }
            else
            {
                stopWatch.Reset();
                addedTime = new TimeSpan(0, 0, 0);
                stopWatch.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();

            Project _newProject = new Project();

            if (ProjectDropDown.SelectedItem != null)
            {
                _newProject.Name = ProjectDropDown.SelectedItem.ToString();
            }
            else
            {
                _newProject.Name = ProjectDropDown.Text;
            }

            Client _newClient = new Client();

            if (ClientDropDown.SelectedItem != null)
            {
                _newClient.Name = ClientDropDown.SelectedItem.ToString();
            }
            else
            {
                _newClient.Name = ClientDropDown.Text;
            }

            if (!(_newClient.Exists()))
            {
                DatabaseHelper.AddClient(_newClient);
            }

            _newProject.ClientId = _newClient.Id;
            _newProject.Client = _newClient;

            if (_newProject.Exists())
            {
                _newProject.Id = DatabaseHelper.GetProjectsByClientId(_newClient.Id).Where(p => p.Name == _newProject.Name).First().Id;
            }
            else
            {
                DatabaseHelper.AddProject(_newProject);
            }

            Task _newTask = new Task(_newProject.Id, textBoxNotes.Text, textBoxTime.Text);
            DatabaseHelper.AddTask(_newTask);
            ClearForm();
        }

        private void ClearForm()
        {
            textBoxNotes.Clear();
            ClientDropDown.ResetText();
            ClientDropDown.Items.Clear();
            ProjectDropDown.ResetText();
            ProjectDropDown.Items.Clear();
            UpdateClientDropDown();
            addedTime = new TimeSpan(0, 0, 0);
            stopWatch.Reset();
            textBoxTime.Text = "00:00:00";
            button1.Text = ">";
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.SetReport();
            f.Show();
        }

        private void buttonHup_Click(object sender, EventArgs e)
        {
            addedTime += new TimeSpan(1, 0, 0);
            UpdateTimeText();
        }

        private void buttonHdown_Click(object sender, EventArgs e)
        {
            addedTime -= new TimeSpan(1, 0, 0);
            UpdateTimeText();
        }

        private void buttonMup_Click(object sender, EventArgs e)
        {
            addedTime += new TimeSpan(0, 1, 0);
            UpdateTimeText();
        }

        private void buttonMdown_Click(object sender, EventArgs e)
        {
            addedTime -= new TimeSpan(0, 1, 0);
            UpdateTimeText();
        }

        private void buttonOpenAnother_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TimeTracker.exe");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ProjectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClientDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProjectDropDown(ClientDropDown.SelectedItem.ToString());
        }

        private void UpdateClientDropDown()
        {
            ClientDropDown.Items.Clear();
            List<Client> _clients = DatabaseHelper.GetClients();

            foreach (var _client in _clients)
            {
                ClientDropDown.Items.Add(_client.Name);
            }
        }

        private void UpdateProjectDropDown(string _clientName)
        {
            ProjectDropDown.Items.Clear();
            ProjectDropDown.ResetText();

            var _clientId = DatabaseHelper.GetClientByName(_clientName).Id;
            List<Project> _projects = DatabaseHelper.GetProjectsByClientId(_clientId);

            foreach (var _project in _projects)
            {
                ProjectDropDown.Items.Add(_project.Name);
            }
        }
    }
}