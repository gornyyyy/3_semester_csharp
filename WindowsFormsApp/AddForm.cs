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
using DataAccessLayer;
using System.Configuration;
using System.Data.SqlClient;

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
            string studentNumber = textBox5.Text;

            if (string.IsNullOrWhiteSpace(studentNumber) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(speciality) || string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Заполните все поля!!!");
                return;
            }
            
            if (!logic.AddStudent(name, speciality, group, studentNumber))
            {
                MessageBox.Show("Не удалось добавить студента :(");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
