using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TimeTracker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void SetReport(Report reportData)
        {
            foreach (var project in reportData.ViewReport())
            {
                dataGridView1.Rows.Add(project.Element("DateOfEntry").Value, project.Element("TimeSpent").Value,
                        project.Element("ProjectTitle").Value, project.Element("ProjectNotes").Value);
            }

            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
