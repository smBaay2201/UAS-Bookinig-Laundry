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
    public partial class FormLayanan : Form
    {
        FromNewOrderReguler menu1;
        FormNewOderSetrika menu2;
        FormNewOrderSepatu menu3;
        FormNewOrderExpres menu4;
        public FormLayanan()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            pnlLayanan.Visible = false;
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            pnlLayanan.Visible = false;
        }

        private void guna2PictureBox2_Click_2(object sender, EventArgs e)
        {
            pnlLayanan.Visible = false;
        }


        private void guna2PictureBox3_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form = new Form2();
            Form.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnlLayanan.Visible = false;
            if (menu1 == null)
            {
                menu1 = new FromNewOrderReguler();
                menu1.FormClosed += menu1_FormClosed;
                menu1.MdiParent = this;
                menu1.Dock = DockStyle.Fill;
                menu1.Show();
            }
            else
            {
                menu1.Activate();
            }
        }
        private void menu1_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu1 = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pnlLayanan.Visible = false;
            if (menu2 == null)
            {
                menu2 = new FormNewOderSetrika();
                menu2.FormClosed += menu2_FormClosed;
                menu2.MdiParent = this;
                menu2.Dock = DockStyle.Fill;
                menu2.Show();
            }
            else
            {
                menu2.Activate();
            }
        }
        private void menu2_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu2 = null;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                pnlLayanan.Visible = false;
                if (menu4 == null)
                {
                    menu4 = new FormNewOrderExpres();
                    menu4.FormClosed += menu4_FormClosed;
                    menu4.MdiParent = this;
                    menu4.Dock = DockStyle.Fill;
                    menu4.Show();
                }
                else
                {
                    menu4.Activate();
                }
         }
        private void menu4_FormClosed(object sender, FormClosedEventArgs e)
         {
            menu4 = null;
         }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pnlLayanan.Visible = false;
            if (menu3 == null)
            {
                menu3 = new FormNewOrderSepatu();
                menu3.FormClosed += menu3_FormClosed;
                menu3.MdiParent = this;
                menu3.Dock = DockStyle.Fill;
                menu3.Show();
            }
            else
            {
                menu3.Activate();
            }

        }
        private void menu3_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu3 = null;
        }

        private void guna2PictureBox16_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form = new Form2();
            Form.ShowDialog();
        }


        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {
           // this.Hide();
          //  FormProfile Form = new FormProfile();
          //  Form.ShowDialog();
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apakah anda ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
        }

        private void guna2ControlBox1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();  // Menutup aplikasi
        }

        private void guna2ControlBox2_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

