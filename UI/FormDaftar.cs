using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace UI
{
    public partial class FormDaftar : Form
    {
        public FormDaftar()
        {
            InitializeComponent();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text;
            string nohp = guna2TextBox4.Text;
            string alamat = guna2TextBox2.Text;
            string password = guna2TextBox3.Text;


            // Koneksi ke database
            string mySqlConn = "server=127.0.0.1; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                // Query untuk insert data
                string queryInsert = "INSERT INTO tb_user (Nama, No_tlp, Alamat, Password) VALUES (@username, @notlp, @alamat, @password)";
                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, mySqlConnection);

                // Tambahkan parameter
                cmdInsert.Parameters.AddWithValue("@username", username);
                cmdInsert.Parameters.AddWithValue("@notlp", nohp);
                cmdInsert.Parameters.AddWithValue("@alamat", alamat);
                cmdInsert.Parameters.AddWithValue("@password", password);

                mySqlConnection.Open();
                cmdInsert.ExecuteNonQuery();
                mySqlConnection.Close();

                // Beri notifikasi sukses
                MessageBox.Show("Pendaftaran berhasil!");
            }
            catch (Exception ex)
            {
                // Tangani error
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(nohp) || string.IsNullOrWhiteSpace(alamat) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }


            // Tutup form pendaftaran dan buka form login
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
