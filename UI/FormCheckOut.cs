using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormCheckOut : Form
    {
        public FormCheckOut()
        {
            InitializeComponent();
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormOrder Form = new FormOrder();
            Form.ShowDialog();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void guna2PictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
        }

        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {
           this.Hide();
            FormPopUpProfile From = new FormPopUpProfile();
            From.ShowDialog();
        }
    }
}
