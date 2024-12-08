using System;
using MySql.Data.MySqlClient;
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
    public partial class FormMyOrder : Form
    {
        public FormMyOrder()
        {
            InitializeComponent();
        }

        private void FormMyOrder_Load(object sender, EventArgs e)
        {
            GetLoggedInUserId();
            
        }

      

        // Dapatkan ID user dari sesi login
        private int GetLoggedInUserId()
        {
            if (CurrentUser.UserId > 0)
            {
                return CurrentUser.UserId;
            }
            else
            {
                MessageBox.Show("User belum login. Harap login terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new InvalidOperationException("User belum login.");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                // Koneksi ke database
                string mySqlConn = "server=localhost; database=db_laundry; user=root; password=";
                using (MySqlConnection conn = new MySqlConnection(mySqlConn))
                {
                    conn.Open();

                    // Query untuk mendapatkan data pesanan
                    string query = "SELECT id_booking AS 'ID Pesanan', jml_cucian AS 'Jumlah (kg)', service_type AS 'Layanan', tgl_Booking AS 'Tgl Booking', tgl_selesai AS 'Tgl Selesai', ttl_Harga AS 'Harga (Rp)', " +
                                   "CASE WHEN lunas = 1 THEN 'Lunas' ELSE 'Menunggu Pembayaran' END AS 'Status Pembayaran' " +
                                   "FROM tb_booking WHERE User_id = @userId ORDER BY tgl_Booking DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Ganti @userId dengan ID user yang login
                        cmd.Parameters.AddWithValue("@userId", GetLoggedInUserId());

                        // Ambil data menggunakan DataAdapter
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}