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

            string mySqlConn = "server=127.0.0.1; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {

                int newUserId = 0;
                string queryGetLastId = "SELECT last_user_id FROM user_id_counter LIMIT 1";
                MySqlCommand cmdGetLastId = new MySqlCommand(queryGetLastId, mySqlConnection);
                mySqlConnection.Open();
                MySqlDataReader reader = cmdGetLastId.ExecuteReader();

                if (reader.Read())
                {
                    newUserId = reader.GetInt32("last_user_id") + 1; // Menambahkan 1 ke ID terakhir
                }
                else
                {
                    newUserId = 1; // Jika tidak ada data, mulai dari 1
                }
                reader.Close();

                string queryInsert = "INSERT INTO user (user_id, Nama, No_HP, Alamat, Password) VALUES (@userId, @username, @nohp, @alamat, @password)";
                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, mySqlConnection);
                cmdInsert.Parameters.AddWithValue("@userId", newUserId);
                cmdInsert.Parameters.AddWithValue("@username", username);
                cmdInsert.Parameters.AddWithValue("@nohp", nohp);
                cmdInsert.Parameters.AddWithValue("@alamat", alamat);
                cmdInsert.Parameters.AddWithValue("@password", password);

                cmdInsert.ExecuteNonQuery();

                // Langkah 3: Update user_id terakhir di tabel user_id_counter
                string queryUpdateCounter = "UPDATE user_id_counter SET last_user_id = @newUserId";
                MySqlCommand cmdUpdateCounter = new MySqlCommand(queryUpdateCounter, mySqlConnection);
                cmdUpdateCounter.Parameters.AddWithValue("@newUserId", newUserId);
                cmdUpdateCounter.ExecuteNonQuery();

                mySqlConnection.Close();

                MessageBox.Show("Pendaftaran berhasil!");
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
