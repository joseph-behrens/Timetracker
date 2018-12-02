using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TimeTracker.Data;
using TimeTracker.Controllers;


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

            // Preconditon: If selected item and the text field are not null
            if (ProjectDropDown.SelectedItem != null)
            {
                _newProject.Name = ProjectDropDown.SelectedItem.ToString();
            }
            else if (!String.IsNullOrEmpty(ProjectDropDown.Text))
            {
                _newProject.Name = ProjectDropDown.Text;
            }

            Client _newClient = new Client();

            // Preconditon: If selected item and the text field are not null
            if (ClientDropDown.SelectedItem != null)
            {
                _newClient.Name = ClientDropDown.SelectedItem.ToString();
            }
            else if (!String.IsNullOrEmpty(ClientDropDown.Text))
            {
                _newClient.Name = ClientDropDown.Text;
            }

            // Preconditon: If there isn't a new client create it
            if (!(_newClient.Exists()))
            {
                ClientController.AddClient(_newClient);
            }

            _newProject.ClientId = _newClient.Id;
            _newProject.Client = _newClient;

            // Preconditon: project is not null
            if (_newProject.Exists())
            {
                _newProject.Id = ProjectController.GetProjectsByClientId(_newClient.Id).Where(p => p.Name == _newProject.Name).First().Id;
            }
            else if (_newProject != null)
            {
                ProjectController.AddProject(_newProject);
            }

            Task _newTask = new Task(_newProject.Id, textBoxNotes.Text, textBoxTime.Text);
            TaskController.AddTask(_newTask);
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
            List<Client> _clients = ClientController.GetClients();

            foreach (var _client in _clients)
            {
                ClientDropDown.Items.Add(_client.Name);
            }
        }

        private void UpdateProjectDropDown(string _clientName)
        {
            ProjectDropDown.Items.Clear();
            ProjectDropDown.ResetText();

            var _clientId = ClientController.GetClientByName(_clientName).Id;
            List<Project> _projects = ProjectController.GetProjectsByClientId(_clientId);

            foreach (var _project in _projects)
            {
                ProjectDropDown.Items.Add(_project.Name);
            }
        }
    }
}