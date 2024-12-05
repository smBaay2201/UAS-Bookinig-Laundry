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
    public partial class FormNewOrderSepatu : Form
    {
        FormOrder proses;
        public FormNewOrderSepatu()
        {
            InitializeComponent();

            GetLoggedInUserId();
        }

        private decimal CalculateHarga(float berat)
        {
            decimal hargaPerKg = 10000; // Contoh harga per kg
            return (decimal)berat * hargaPerKg;
        }

        // Contoh fungsi untuk mendapatkan ID user yang login
        private int GetLoggedInUserId()
        {
            // Anda bisa mengatur userId saat login dan simpan di variabel global/session
            return 1; // Contoh, user ID 1
        }


        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            // Ambil data dari inputan form
            string customerName = customername.Text;  // Sesuaikan dengan nama kontrol TextBox
            string serviceType = service.Text;
            float berat = float.Parse(txtBerat.Text);    // Pastikan validasi angka dilakukan
            string alamatt = alamat.Text;
            decimal harga = CalculateHarga(berat);// Fungsi untuk menghitung harga
            int idBooking = 1;

            // Koneksi database
            string mySqlConn = "server=localhost; database=db_laundry; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                // Query untuk insert data ke tb_booking
                string query = "INSERT INTO tb_booking (jml_cucian, service_type, tgl_Booking, tgl_selesai, ttl_Harga, User_id, id_Booking) " +
                               "VALUES (@berat, @serviceType, @tglBooking, @tglSelesai, @harga, @userId, @idBooking)";

                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                cmd.Parameters.AddWithValue("@idBooking", idBooking);
                cmd.Parameters.AddWithValue("@berat", berat);
                cmd.Parameters.AddWithValue("@serviceType", serviceType);
                cmd.Parameters.AddWithValue("@tglBooking", DateTime.Now);           // Tanggal booking
                cmd.Parameters.AddWithValue("@tglSelesai", DateTime.Now.AddDays(3)); // Estimasi selesai
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@userId", GetLoggedInUserId());        // Fungsi untuk mendapatkan user id aktif

                mySqlConnection.Open();
                cmd.ExecuteNonQuery();

                // Tampilkan popup sukses
                MessageBox.Show("Pesanan berhasil dibuat! Lanjut ke pembayaran.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigasi ke halaman pembayaran atau lainnya
            }
            catch (Exception ex)
            {
                // Tampilkan error jika gagal
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        private void proses_FormClosed(object sender, FormClosedEventArgs e)
        {
            proses = null;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            // Ambil input dari TextBox
            string customerName = customername.Text;
            string beratText = txtBerat.Text;
            string alamatt = alamat.Text;

            // Validasi input
            if (string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(beratText) ||
                string.IsNullOrWhiteSpace(alamatt) ||
                !int.TryParse(beratText, out int berat))
            {
                MessageBox.Show("Semua field harus diisi dengan valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Harga per kilogram
            int hargaPerKg = 20000;

            // Hitung total harga
            int totalHarga = berat * hargaPerKg;

            // Tampilkan data di kotak kanan
            namatampil.Text = customerName;
            berattampil.Text = berat + " ";
            alamattampil.Text = alamatt;

            // Tampilkan total harga di kotak putih
            txttotalHarga.Text = "Rp. " + totalHarga.ToString("N0"); // Format angka dengan ribuan (misal: Rp. 5,000)

            // Kosongkan input di kotak kiri untuk entri berikutnya
            customername.Clear();

            alamat.Clear();
        }
    }

}
