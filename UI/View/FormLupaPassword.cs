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
    public partial class FormLupaPassword : Form
    {
        public FormLupaPassword()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string nohp = guna2TextBox1.Text;
            string passwordBaru = guna2TextBox3.Text;

            // Koneksi ke database
            string mySqlConn = "server=127.0.0.1; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                // Validasi input
                if (string.IsNullOrWhiteSpace(nohp) || string.IsNullOrWhiteSpace(passwordBaru))
                {
                    MessageBox.Show("Semua kolom harus diisi!");
                    return;
                }

                // Query untuk mengupdate password
                string queryUpdatePassword = "UPDATE tb_user SET Password = @passwordBaru WHERE No_tlp = @nohp";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdatePassword, mySqlConnection);

                // Tambahkan parameter
                cmdUpdate.Parameters.AddWithValue("@passwordBaru", passwordBaru);
                cmdUpdate.Parameters.AddWithValue("@nohp", nohp);

                mySqlConnection.Open();
                int rowsAffected = cmdUpdate.ExecuteNonQuery(); // Jalankan query

                mySqlConnection.Close();

                if (rowsAffected > 0)
                {
                    // Jika ada data yang diupdate
                    MessageBox.Show("Password berhasil diperbarui!");
                }
                else
                {
                    // Jika nomor HP tidak ditemukan
                    MessageBox.Show("Nomor HP tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
        }
    }
}
