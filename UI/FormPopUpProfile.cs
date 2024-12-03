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
    public partial class FormPopUpProfile : Form
    {
        private string userNoHP;
        public FormPopUpProfile()
        {
            InitializeComponent();
        }

        public FormPopUpProfile(string noHP)
        {
            userNoHP = noHP; // Inisialisasi nomor HP
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form3EditProfilecs Form = new Form3EditProfilecs();
            Form.ShowDialog();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void FormPopUpProfile_Load(object sender, EventArgs e)
        {
            string mySqlConn = "server=127.0.0.1; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                // Query untuk mengambil data user berdasarkan nomor HP
                string querySelect = "SELECT Nama, No_tlp, Alamat FROM tb_user WHERE No_tlp = @No_tlp";
                MySqlCommand cmdSelect = new MySqlCommand(querySelect, mySqlConnection);
                cmdSelect.Parameters.AddWithValue("@No_tlp", userNoHP);

                mySqlConnection.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();
                if (reader.Read())
                {
                    // Isi data ke TextBox
                    guna2TextBox2.Text = reader["Nama"].ToString();
                    guna2TextBox3.Text = reader["No_HP"].ToString();
                    guna2TextBox4.Text = reader["Alamat"].ToString();
                }
                else
                {
                    MessageBox.Show("Data pengguna tidak ditemukan!");
                }

                reader.Close();
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

        }
    }
}
