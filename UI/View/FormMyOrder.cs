using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMyOrder : Form
    {
        public FormMyOrder()
        {
            InitializeComponent();
            InitializeDataGridViewColumns(); // Pastikan kolom diatur sebelum memuat data
            RefreshOrderTable(); // Memuat data saat form terbuka
        }

        // Metode untuk menambahkan kolom ke DataGridView
        private void InitializeDataGridViewColumns()
        {
            try
            {
                dataGridViewOrders.Columns.Clear(); // Bersihkan kolom terlebih dahulu
                dataGridViewOrders.Columns.Add("serviceType", "Layanan");
                dataGridViewOrders.Columns.Add("jmlCucian", "Jumlah Cucian");
                dataGridViewOrders.Columns.Add("tglBayar", "Tanggal Bayar");
                dataGridViewOrders.Columns.Add("tglAmbil", "Tanggal Ambil");
                dataGridViewOrders.Columns.Add("status", "Status");
                dataGridViewOrders.Columns.Add("harga", "Harga");
                dataGridViewOrders.Columns.Add("lunas", "Lunas");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan saat inisialisasi kolom: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metode untuk menambahkan data ke DataGridView
        public void AddOrderToTable(string layanan, string jumlah, string tglBayar, string tglAmbil, string status, decimal harga, string lunas)
        {
            try
            {
                dataGridViewOrders.Rows.Add(layanan, jumlah, tglBayar, tglAmbil, status, harga.ToString("N0"), lunas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan saat menambahkan data ke tabel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metode untuk memuat ulang data dari database ke DataGridView
        public void RefreshOrderTable()
        {
            try
            {
                // Bersihkan data yang ada di DataGridView
                dataGridViewOrders.Rows.Clear();

                // Query untuk mengambil data dari tabel tb_booking
                string query = "SELECT service_type, jml_cucian, tgl_Booking, tgl_selesai, ttl_Harga FROM tb_booking";

                // Connection string ke database
                string connectionString = "server=localhost; database=db_laundry; user=root; password=";

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open(); // Membuka koneksi

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Membaca data dari database
                                string layanan = reader["service_type"].ToString();
                                string jumlah = reader["jml_cucian"].ToString();
                                string tglBayar = Convert.ToDateTime(reader["tgl_Booking"]).ToString("yyyy-MM-dd");
                                string tglAmbil = Convert.ToDateTime(reader["tgl_selesai"]).ToString("yyyy-MM-dd");
                                decimal harga = reader["ttl_Harga"] != DBNull.Value ? Convert.ToDecimal(reader["ttl_Harga"]) : 0;

                                // Tambahkan data ke DataGridView
                                AddOrderToTable(layanan, jumlah, tglBayar, tglAmbil, "Menunggu", harga, "Lunas Bro...");
                            }
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show("Kesalahan koneksi database: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk klik di DataGridView
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string layanan = dataGridViewOrders.Rows[e.RowIndex].Cells["serviceType"].Value.ToString();
                    MessageBox.Show($"Layanan yang dipilih: {layanan}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan saat memproses klik tabel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form = new Form2();
            Form.ShowDialog();
        }
    }
}
