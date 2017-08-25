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

namespace TimeTracker
{
    public partial class Form1 : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        Report writeData;
        public Form1()
        {
            InitializeComponent();
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
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            textBoxTime.Text = elapsedTime;
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
            stopWatch.Reset();
            textBoxTime.Text = "00:00:00";
            button1.Text = ">";
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            writeData.ViewReport();
        }
    }
}
