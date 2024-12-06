﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace UI
{
    public partial class FormNewOrderSepatu : Form
    {
        FormOrder proses;

        public FormNewOrderSepatu()
        {
            InitializeComponent();
        }

        private decimal CalculateHarga(float berat)
        {
            decimal hargaPerKg = 20000; // Harga per kg
            return (decimal)berat * hargaPerKg;
        }

        // Contoh fungsi untuk mendapatkan ID user yang login
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


        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            // Validasi input dari TextBox
            if (!float.TryParse(txtBerat.Text, out float berat) || berat <= 0)
            {
                MessageBox.Show("Berat harus berupa angka positif.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(service.Text))
            {
                MessageBox.Show("Layanan harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serviceType = service.Text;
            decimal harga = CalculateHarga(berat);
            DateTime tglBooking = DateTime.Now;
            DateTime tglSelesai = tglBooking.AddDays(3);

            try
            {
                int userId = GetLoggedInUserId(); // Dapatkan ID user dari sesi login

                // Koneksi ke database
                string mySqlConn = "server=localhost; database=db_laundry; user=root; password=";
                using (MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn))
                {
                    string query = "INSERT INTO tb_booking (jml_cucian, service_type, tgl_Booking, tgl_selesai, ttl_Harga, User_id) " +
                                   "VALUES (@berat, @serviceType, @tglBooking, @tglSelesai, @harga, @userId)";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        // Bind parameter untuk menghindari SQL Injection
                        cmd.Parameters.AddWithValue("@berat", berat);
                        cmd.Parameters.AddWithValue("@serviceType", serviceType);
                        cmd.Parameters.AddWithValue("@tglBooking", tglBooking);
                        cmd.Parameters.AddWithValue("@tglSelesai", tglSelesai);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        // Buka koneksi dan eksekusi query
                        mySqlConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Pesanan berhasil dibuat!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FormLayanan form = new FormLayanan())
            {
                form.ShowDialog();
            }
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            // Ambil input dari TextBox
            string customerName = customername.Text.Trim();
            string beratText = txtBerat.Text.Trim();
            string alamatText = alamat.Text.Trim();

            // Validasi input
            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(beratText) || string.IsNullOrWhiteSpace(alamatText) || !float.TryParse(beratText, out float berat) || berat <= 0)
            {
                MessageBox.Show("Semua field harus diisi dengan benar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hitung total harga
            decimal totalHarga = CalculateHarga(berat);

            // Tampilkan data di tampilan kanan
            namatampil.Text = customerName;
            berattampil.Text = berat + " kg";
            alamattampil.Text = alamatText;

            // Tampilkan total harga di kotak putih
            txttotalHarga.Text = "Rp. " + totalHarga.ToString("N0"); // Format angka dengan ribuan
        }
    }
}
