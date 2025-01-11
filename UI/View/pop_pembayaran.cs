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
    public partial class pop_pembayaran : Form
    {
        public pop_pembayaran()
        {
            InitializeComponent();
          
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            // Membuka form lain setelah selesai
            Form2 formKonfirmasi = new Form2();
            this.Hide(); // Menyembunyikan form pembayaran
            formKonfirmasi.ShowDialog(); // Menampilkan form konfirmasi
            this.Close(); // Menutup form pembayaran
        }
        

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
