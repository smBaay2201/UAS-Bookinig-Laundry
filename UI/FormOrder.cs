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
    public partial class FormOrder : Form
    {
        FormCheckOut proses;
        FormMyOrder proses1;
        public FormOrder()
        {
            InitializeComponent();
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            pnlOrder.Visible = false;
            if (proses == null)
            {
                proses = new FormCheckOut();
                proses.FormClosed += proses_FormClosed;
                this.Hide();
                proses.Dock = DockStyle.Fill;
                proses.Show();
            }
            else
            {
                proses.Activate();   
            }
        }
        private void proses_FormClosed(object sender, FormClosedEventArgs e)
        {
            proses = null;
        }

        private void guna2PictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox14_Click(object sender, EventArgs e)
        {
            pnlOrder.Visible = false;
            if (proses1 == null)
            {
                proses1 = new FormMyOrder();
                proses1.FormClosed += proses1_FormClosed;
                this.Hide();
                proses1.Dock = DockStyle.Fill;
                proses1.Show();
            }
            else
            {
                proses1.Activate();
            }
        }
        private void proses1_FormClosed(object sender, FormClosedEventArgs e)
        {
            proses1 = null;
        }

        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
