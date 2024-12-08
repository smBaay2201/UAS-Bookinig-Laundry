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
    
    public partial class Form1 : Form
    {
        public static string CurrentUserNoHP { get; set; } // Menyimpan nomor HP pengguna yang login

        public Form1()
        {
            InitializeComponent();
            TestDatabaseConnection();
        }

        private void TestDatabaseConnection()
        {
            string mySqlConn = "server=localhost; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                mySqlConnection.Open();
                MessageBox.Show("Koneksi ke database berhasil!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal terhubung ke database: {ex.Message}");
            }
            finally { mySqlConnection.Close(); }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormLupaPassword Form = new FormLupaPassword();
            Form.ShowDialog();
        }
        //halo namamu siapa
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = nama.Text;
            string password = pass.Text;

            string mySqlConn = "server=127.0.0.1; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                string query = "SELECT user_id, Nama, Alamat, No_tlp FROM tb_user WHERE Nama = @username AND Password = @password";
                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                mySqlConnection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Simpan data user ke CurrentUser
                    CurrentUser.UserId = reader.GetInt32("user_id");
                    CurrentUser.Nama = reader.GetString("Nama");
                    CurrentUser.Alamat = reader.GetString("Alamat");
                    CurrentUser.NoTelepon = reader.GetString("No_tlp");

                    MessageBox.Show("Login berhasil!");
                    this.Hide();

                    // Navigasi ke Form berikutnya
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormDaftar Form = new FormDaftar();
            Form.ShowDialog();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Menutup aplikasi
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
