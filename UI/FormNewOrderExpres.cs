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
    public partial class FormNewOrderExpres : Form
    {
        FormOrder proses;
        public FormNewOrderExpres()
        {
            InitializeComponent();
        }
         

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
                pnlExpres.Visible = false;
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
