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
    public partial class DeleteForm : Form
    {
        private Logic logic;
        public DeleteForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Заполните поле ID правильно!!!");
                return;
            }

            logic.DeleteStudent(Convert.ToInt16(id));
            this.Close();
        }
    }
}
