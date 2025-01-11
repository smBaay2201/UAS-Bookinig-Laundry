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
    public partial class FormOrder : Form
    {
        FormCheckOut proses;
        FormMyOrder proses1;
        public FormOrder()
        {
            InitializeComponent();
        }

        public void SetOrderDetails(string orderServiceType, string jml_cucian, string tgl_bayar, string tgl_ambil, decimal totalPayment)
        {
            lblLayanan.Text = orderServiceType; // Label untuk layanan
            lblBerat.Text = jml_cucian; // label untuk berat cucian
            lblTglBayar.Text = tgl_bayar; // label untuk tanggal bayar
            lblAmbil.Text = tgl_ambil; // label untuk tanggal ambil
            lblBiaya.Text = " " + totalPayment.ToString("N0"); // Format angka ribuan
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            pnlOrder.Visible = false;
            if (proses == null)
            {
                proses = new FormCheckOut();
                proses.FormClosed += proses_FormClosed;
                this.Hide();
                proses.Dock = DockStyle.Fill;
                proses.Show();
            }
            else
            {
                proses.Activate();   
            }

            try
            {
                // Koneksi ke database
                string mySqlConn = "server=localhost; database=db_laundry; user=root; password=";
                using (MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn))
                {
                    // Query untuk mendapatkan nomor order terbaru dan total harga dari tabel booking
                    string query = "SELECT id_Booking, ttl_Harga FROM tb_booking ORDER BY id_booking DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open();

                        // Eksekusi query
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Ambil nomor order dan total harga
                                string order = " " + reader["id_Booking"].ToString();
                                decimal totalPayment = Convert.ToDecimal(reader["ttl_Harga"]);


                                // Panggil form checkout dan tampilkan data
                                this.Hide();
                                using (FormCheckOut formCheckOut = new FormCheckOut())
                                {
                                    formCheckOut.SetOrderDetails(order, totalPayment);
                                    formCheckOut.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Data pesanan tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void proses_FormClosed(object sender, FormClosedEventArgs e)
        {
            proses = null;
        }

        private void guna2PictureBox14_Click(object sender, EventArgs e)
        {
            pnlOrder.Visible = false;
            if (proses1 == null)
            {
                proses1 = new FormMyOrder();
                proses1.FormClosed += proses1_FormClosed;
                this.Hide();
                proses1.Dock = DockStyle.Fill;
                proses1.Show();
            }
            else
            {
                proses1.Activate();
            }
        }
        private void proses1_FormClosed(object sender, FormClosedEventArgs e)
        {
            proses1 = null;
        }

       

        private void guna2PictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apakah anda ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
        }


        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLayanan Form = new FormLayanan();
            Form.ShowDialog();
        }

        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPopUpProfile Form = new FormPopUpProfile();
            Form.ShowDialog();
        }

        private void guna2PictureBox16_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form = new Form2();
            Form.ShowDialog();
        }
    }
}
