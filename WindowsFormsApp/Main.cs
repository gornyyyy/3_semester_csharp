using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace WindowsFormsApp
{
    public partial class Main : Form
    {
        private Logic logic = new Logic();
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshHistogram();
            RefreshTable();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }



        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            foreach (var line in logic.GetAllStudents())
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    dataGridView1.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
                }
            }
        }

        private void RefreshHistogram()
        {
            chart1.Series[0].Points.Clear();
            var distribution = logic.GetSpecialtyDistribution();
            foreach (var i in distribution)
            {
                chart1.Series[0].Points.AddXY(i.Key, i.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(logic);
            addForm.ShowDialog();
            RefreshTable();
            RefreshHistogram();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var deleteForm = new DeleteForm(logic);
            deleteForm.ShowDialog();
            RefreshTable();
            RefreshHistogram();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshHistogram();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
    }
}
