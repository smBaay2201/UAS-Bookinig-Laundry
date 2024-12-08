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

        public void SetOrderDetails(string order, decimal totalPayment)
        {
            lblOrderNumber.Text = "Order #" + order;  // Label untuk layanan
            lblToPembayaran.Text = "Total Pembayaran Rp. " + totalPayment.ToString("N0"); // Format angka ribuan
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
            MessageBox.Show("Apakah anda ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pembayaran Berhasil");
            this.Hide();
            FormLayanan From = new FormLayanan();
            From.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormCheckOut_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
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
    }
}
