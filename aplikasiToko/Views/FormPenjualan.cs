using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace aplikasiToko
{
    public partial class FormPenjualan : Form
    {
        Controllers.TransaksiKeluarController transaksiController = new Controllers.TransaksiKeluarController();
        Models.TransaksiKeluarModel Transaksi = new Models.TransaksiKeluarModel();
        Models.DetailTransaksiKeluarModel detailTransaksi = new Models.DetailTransaksiKeluarModel();
        string kode_Barang = "";

        //private List<Models.DetailTransaksiKeluarModel> detailTransaksiList = new List<Models.DetailTransaksiKeluarModel>();   

        public FormPenjualan()
        {
            InitializeComponent();
            //txtDiskon.Text = "0";
            LoadComboBoxData();            
            cbNamaBarang.SelectedIndex = -1;
            cbPelanggan.SelectedIndex = -1;
            txtJumlahBeli.TextChanged += txtJumlahBeli_TextChanged;
            lockForm();
            transaksiController.DestroyTempTransaksi();
        }

        private void lockForm()
        {
            cbNamaBarang.Enabled = false;
            cbPelanggan.Enabled = false;
            txtJumlahBeli.Enabled = false;
            btHapusBarang.Enabled = false;
            btHapusDaftarPembelian.Enabled = false;
            btPilihBarang.Enabled = false;
            txtBayar.Enabled = false;
            txtDiskon.Enabled = false;
            btBatalTransaksi.Enabled = false;
            btSimpanTransaksi.Enabled = false;
            isKredit.Enabled = false;
            edit.Enabled = false;
        }

        private void unlockForm()
        {
            cbNamaBarang.Enabled = true;
            //cbPelanggan.Enabled = true;
            txtJumlahBeli.Enabled = true;
            //btHapusBarang.Enabled = true;
            //btHapusDaftarPembelian.Enabled = true;
            btPilihBarang.Enabled = true;
            txtBayar.Enabled = true;
            txtDiskon.Enabled = true;
            btBatalTransaksi.Enabled = true;
            btSimpanTransaksi.Enabled = true;
            isKredit.Enabled = true;

        }

        private void LoadComboBoxData()
        {
            cbNamaBarang.DataSource = transaksiController.GetProduk();
            cbNamaBarang.DisplayMember = "ValueName";
            cbNamaBarang.ValueMember = "Id";
            cbPelanggan.DataSource = transaksiController.GetPelanggan();
            cbPelanggan.DisplayMember = "ValueName";
            cbPelanggan.ValueMember = "ValueCode";
            //txtPelanggan.Text = transaksiController.GetPelang
            //cbNamaBarang.Text = ""; 
            //txtKodeBarang.Text = "ValueCode";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FormPenjualan_Load(object sender, EventArgs e)
        {
            namaKaryawan.Text = Session.Session.Username.ToString();
        }

        private void cbNamaBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cari = cbNamaBarang.Text;
            Models.ProductModel produkInfo = transaksiController.getProductInfoByName(cari);
            txtKodeBarang.Text = produkInfo.kodeBarang;
            stok.Text = produkInfo.stok.ToString("N0");
            txtHargaJual.Text = produkInfo.hargaJual.ToString("N0");
            satuan.Text = produkInfo.satuan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNota.Text = transaksiController.NotaTransaksi();
            unlockForm();
            cbPelanggan.Text = "CUSTOMER";            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isKredit.Checked == true)
            {
                //btPelanggan.Enabled = true;
                cbPelanggan.Enabled = true;
                txtPelanggan.Text = "";
                cbPelanggan.Text = "";
            }
            else
            {
                //btPelanggan.Enabled = false;
                cbPelanggan.Enabled = false;
                cbPelanggan.Text = "CUSTOMER";
                txtPelanggan.Text = "CASH";
            }
        }

        private void txtJumlahBeli_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int stokValue = int.Parse(stok.Text, NumberStyles.AllowThousands);
                int jumlahBeliValue = int.Parse(txtJumlahBeli.Text);
                int hargaJualValue = int.Parse(txtHargaJual.Text, NumberStyles.AllowThousands);

                if (jumlahBeliValue > stokValue)
                {
                    txtHargaAkhir.Text = "Stok tidak cukup";
                }
                else
                {
                    int hasil = jumlahBeliValue * hargaJualValue;
                    txtHargaAkhir.Text = hasil.ToString("N0");
                }
            }
            catch (FormatException)
            {
                // Tangani kesalahan jika teks tidak dapat diubah menjadi angka bulat
                txtHargaAkhir.Text = "Format tidak valid";
            }
        }

        private bool IsDataExists(string targetValue)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Pastikan bahwa baris bukan baris baru yang belum diisi atau tidak aktif
                if (!row.IsNewRow)
                {
                    // Ganti "ColumnTarget" dengan nama kolom yang sesuai
                    string cellValue = row.Cells["kodeBarang"].Value.ToString();

                    // Lakukan perbandingan nilai dengan nilai target
                    if (cellValue.Equals(targetValue, StringComparison.OrdinalIgnoreCase))
                    {
                        // Data sudah ada, return true atau berikan tindakan lain sesuai kebutuhan
                        return true;
                    }
                }
            }

            // Data tidak ditemukan, return false
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (btPilihBarang.Text == "Pilih Item" && txtHargaAkhir.Text != "Stok tidak cukup")
            {
                int totalHarga = 0;
                detailTransaksi.nota = txtNota.Text;
                detailTransaksi.idPelanggan = txtPelanggan.Text;
                detailTransaksi.namaBarang = cbNamaBarang.Text;
                detailTransaksi.kodeBarang = txtKodeBarang.Text;
                detailTransaksi.jumlah = int.Parse(txtJumlahBeli.Text);
                detailTransaksi.hargaSatuan = int.Parse(txtHargaJual.Text, NumberStyles.AllowThousands);
                detailTransaksi.hargaAkhir = int.Parse(txtHargaAkhir.Text, NumberStyles.AllowThousands);

                if (!IsDataExists(detailTransaksi.kodeBarang))
                {
                    transaksiController.CreateDetailTransaksi(detailTransaksi);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DataSource = transaksiController.ShowTempTransaksi();
                    dataGridView1.Columns["nota"].Visible = false;
                    txtJumlahBeli.Text = "";
                    txtHargaAkhir.Text = "";
                    btHapusDaftarPembelian.Enabled = true;
                    cbNamaBarang.SelectedIndex = -1;

                    //perulangan untuk menjumlahkan kolom hargaAkhir
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Pastikan bahwa baris bukan baris header
                        if (!row.IsNewRow)
                        {
                            // Mengambil nilai di kolom "Harga" (ganti "Harga" dengan nama kolom yang sesuai)
                            int hargaBaris = Convert.ToInt32(row.Cells["hargaAkhir"].Value);

                            // Menambahkan nilai ke total
                            totalHarga += hargaBaris;
                            subTotal.Text = totalHarga.ToString("N0");
                        }
                    }
                }
                else
                {
                    // Data sudah ada, berikan pesan atau lakukan tindakan lain
                    MessageBox.Show("Data sudah ada.");
                }
            }
            else if (btPilihBarang.Text == "Simpan")
            {
                detailTransaksi.jumlah = int.Parse(txtJumlahBeli.Text);
                detailTransaksi.hargaAkhir = int.Parse(txtHargaAkhir.Text, NumberStyles.AllowThousands);

                transaksiController.UpdateTempTransaksi(kode_Barang, detailTransaksi);
                dataGridView1.DataSource = transaksiController.ShowTempTransaksi();

                edit.Text = "Edit";
                edit.Enabled = false;
                btPilihBarang.Text = "Pilih Item";
            }
            else if (txtHargaAkhir.Text == "Stok tidak cukup")
            {
                MessageBox.Show("Stok tidak cukup", "Error", MessageBoxButtons.OK);
            }
        }        

        private void FormPenjualan_FormClosed(object sender, FormClosedEventArgs e)
        {
            transaksiController.DestroyTempTransaksi();
        }

        private void cbNamaBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cari = cbPelanggan.Text;
            Models.PelangganModel infoPelanggan = transaksiController.getCustomersInfoByName(cari);
            txtPelanggan.Text = infoPelanggan.Kode;
            if (cbPelanggan.Text == "CUSTOMER")
            {
                isKredit.Checked = false;
            }
            //stok.Text = produkInfo.stok.ToString();
        }

        private void btHapusDaftarPembelian_Click(object sender, EventArgs e)
        {
            transaksiController.DestroyTempTransaksi();
            dataGridView1.DataSource = transaksiController.ShowTempTransaksi();
        }

        private void txtDiskon_TextChanged(object sender, EventArgs e)
        {
            if (txtDiskon.Text != null)
            {
                try
                {
                    //int stokValue = int.Parse(stok.Text, NumberStyles.AllowThousands);
                    int Diskon = int.Parse(txtDiskon.Text);
                    int subTotalValue = int.Parse(subTotal.Text, NumberStyles.AllowThousands);

                    if (Diskon > 100 || Diskon < 0)
                    {
                        totalDiskon.Text = "Masukkan Diskon 0-100";
                    }
                    else
                    {
                        double persenDiskon = (double)Diskon / 100;
                        int hasil = (int)(subTotalValue * persenDiskon);
                        totalDiskon.Text = hasil.ToString("N0");
                        lblDiskon.Text = hasil.ToString("N0");
                        int total = subTotalValue - hasil;
                        totalHarga.Text = total.ToString("N0");
                        lblTagihan.Text = total.ToString("N0");
                    }
                }
                catch (FormatException)
                {
                    // Tangani kesalahan jika teks tidak dapat diubah menjadi angka bulat
                    totalDiskon.Text = "Invalid Input, Masukkan Diskon 0-100";
                }
            }
            else
            {
                txtDiskon.Text = "0";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btHapusBarang_Click(object sender, EventArgs e)
        {
            transaksiController.DestroyTempTransaksi(kode_Barang);
            dataGridView1.DataSource = transaksiController.ShowTempTransaksi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //id_user = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                kode_Barang = dataGridView1.Rows[e.RowIndex].Cells["kodeBarang"].Value.ToString();
                cbNamaBarang.Text = dataGridView1.Rows[e.RowIndex].Cells["namaBarang"].Value.ToString();
                //txtAlamat.Text = dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value.ToString();
                //txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                txtJumlahBeli.Text = dataGridView1.Rows[e.RowIndex].Cells["jumlah"].Value.ToString();
                //lockForm();
                btPilihBarang.Enabled = false;
                edit.Enabled = true;
                btHapusBarang.Enabled = true;
                cbNamaBarang.Enabled = false;
                txtJumlahBeli.Enabled = false;
                //btH.Enabled = true;
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (edit.Text == "Edit")
            {
                cbNamaBarang.Enabled = true;
                txtJumlahBeli.Enabled = true;
                btPilihBarang.Enabled = true;
                btPilihBarang.Text = "Simpan";
                edit.Text = "Batal";
            }
            else if (edit.Text == "Batal")
            {
                txtJumlahBeli.Text = "";
                txtHargaAkhir.Text = "";
                //btHapusDaftarPembelian.Enabled = true;
                cbNamaBarang.SelectedIndex = -1;
                btPilihBarang.Text = "Pilih Item";
                edit.Text = "Edit";
                edit.Enabled = false;   
            }
        }

        private void subTotal_TextChanged(object sender, EventArgs e)
        {
            totalHarga.Text = subTotal.Text;
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBayar.Text != null)
                {

                    int a = int.Parse(txtBayar.Text);
                    lblBayar.Text = a.ToString("N0");
                    int totalTagihan = int.Parse(totalHarga.Text, NumberStyles.AllowThousands);

                    if (totalTagihan > a)
                    {
                        txtKembalian.Text = "Pembayaran Kurang";
                    }
                    else
                    {
                        int kembalian = a - totalTagihan;
                        txtKembalian.Text = kembalian.ToString("N0");
                        lblKembali.Text = kembalian.ToString("N0");
                    }
                }
                else
                {
                    txtKembalian.Text = "Masukkan Jumlah Pembayaran";
                }
            }
            catch (FormatException)
            {
                txtKembalian.Text = "Masukkan Nilai Pembayaran!";
            }
        }

        private void lblTagihan_Click(object sender, EventArgs e)
        {

        }

        private void clearForm()
        {
            lblBayar.Text = "";
            txtDiskon.Text = "";
            totalDiskon.Text = "";
            lockForm();
            txtNota.Text = "";
            txtPelanggan.Text = "";
            cbPelanggan.SelectedIndex = -1;
            cbNamaBarang.SelectedIndex = -1;
            subTotal.Text = "";
            txtKembalian.Text = "";
            txtBayar.Text = "";
            totalHarga.Text = "";
            lblDiskon.Text = "";
            lblTagihan.Text = "";
            lblKembali.Text = "";
            transaksiController.DestroyTempTransaksi();
        }

        private void btBatalTransaksi_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btSimpanTransaksi_Click(object sender, EventArgs e)
        {
            Transaksi.nota = txtNota.Text;
            Transaksi.idUser = int.Parse(Session.Session.Id);
            Transaksi.kodePelanggan = txtPelanggan.Text;
            Transaksi.totalHarga = int.Parse(subTotal.Text, NumberStyles.AllowThousands);
            Transaksi.totalTagihan = int.Parse(totalHarga.Text, NumberStyles.AllowThousands);
            Transaksi.diskon = int.Parse(totalDiskon.Text, NumberStyles.AllowThousands);
            Transaksi.bayar = int.Parse(txtBayar.Text);
            Transaksi.kembali = int.Parse(txtKembalian.Text, NumberStyles.AllowThousands);

            transaksiController.simpanTransaksiPembelian(Transaksi);
            transaksiController.simpanDetailTransaksi();
            transaksiController.kurangiStok();
            transaksiController.DestroyTempTransaksi();
            dataGridView1.DataSource = transaksiController.ShowTempTransaksi();
            MessageBox.Show("Terima Kasih Telah Belanja", "TokoKU", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearForm();
        }

    }
}
