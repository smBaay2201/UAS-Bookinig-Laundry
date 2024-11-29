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
    public partial class FromNewOrderReguler : Form
    {
        FormOrder proses;
        public FromNewOrderReguler()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            pnlReguler.Visible = false;
            if (proses == null)
            {
                proses = new FormOrder();
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

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }
    }
}
