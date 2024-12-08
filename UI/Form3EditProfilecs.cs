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
    public partial class Form3EditProfilecs : Form
    {
        public Form3EditProfilecs()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) || string.IsNullOrWhiteSpace(guna2TextBox2.Text) || string.IsNullOrWhiteSpace(guna2TextBox3.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nama = guna2TextBox1.Text;
            string noTlp = guna2TextBox2.Text;
            string alamat = guna2TextBox3.Text;

            try
            {
                // Koneksi ke database
                string mySqlConn = "server=127.0.0.1; database=db_laundry; user=root; password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

                // Query untuk memperbarui data user
                string queryUpdate = "UPDATE tb_user SET Nama = @Nama, No_tlp = @No_tlp, Alamat = @Alamat WHERE No_tlp = @No_tlp";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, mySqlConnection);
                cmdUpdate.Parameters.AddWithValue("@Nama", nama);
                cmdUpdate.Parameters.AddWithValue("@No_tlp", noTlp);
                cmdUpdate.Parameters.AddWithValue("@Alamat", alamat);

                mySqlConnection.Open();
                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tidak ada perubahan pada data.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

            this.Hide();
            FormPopUpProfile Form = new FormPopUpProfile();
            Form.ShowDialog();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
