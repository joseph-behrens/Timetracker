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



/// <summary>
/// TODO: Add stopwatch class and move stopWatch logic
/// </summary>
namespace TimeTracker
{
    public partial class Form1 : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        Report writeData;
        TimeSpan addedTime;
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(buttonHup, "Add one hour");
            toolTip1.SetToolTip(buttonHdown, "Subtract one hour");
            toolTip1.SetToolTip(buttonMup, "Add one minute");
            toolTip1.SetToolTip(buttonMdown, "Subtract one minute");
            toolTip1.SetToolTip(buttonOpenAnother, "Open another TimeTracker");
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            writeData = new Report();
            
            try
            {
                writeData.OpenList();
                Console.WriteLine("Opened existing list");
            }
            catch { Console.WriteLine("Data.xml not yet intialized"); }
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
            ProjectTask projectTask = new ProjectTask(textBoxProject.Text, textBoxNotes.Text, textBoxTime.Text);
            writeData.AddTaskToList(projectTask);
            writeData.SaveList();
            writeData.OpenList();
            ClearForm();
        }

        private void ClearForm()
        {
            textBoxNotes.Clear();
            textBoxProject.Clear();
            addedTime = new TimeSpan(0, 0, 0);
            stopWatch.Reset();
            textBoxTime.Text = "00:00:00";
            button1.Text = ">";
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.SetReport(writeData);
            f.Show();
            writeData.ViewReport();
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
    }
}