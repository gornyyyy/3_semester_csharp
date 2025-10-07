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
using BusinessLogic;

namespace WindowsFormsApp
{
    public partial class AddForm : Form
    {
        private Logic logic;
        public AddForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string speciality = textBox2.Text;
            string group = textBox3.Text;
            string id = textBox4.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(speciality) || string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Заполните все поля!!!");
                return;
            }
            
            if (!logic.AddStudent(name, speciality, group, Convert.ToInt16(id)))
            {
                MessageBox.Show("У студентов не может быть одиннаковых ID");
            }
            this.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
