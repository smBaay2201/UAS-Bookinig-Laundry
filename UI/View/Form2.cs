using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

  

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        } 

        
      

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Jika pengguna memilih "Yes", kembali ke Form1
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                // Jika pengguna memilih "No", tetap berada di Form2
                // Tidak ada aksi karena Form2 tetap aktif
            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMyOrder form = new FormMyOrder();
            form.ShowDialog();
        }

        private void guna2ControlBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Menutup aplikasi
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
            Form3EditProfilecs form = new Form3EditProfilecs();
            form.ShowDialog();
        }
    }
}
