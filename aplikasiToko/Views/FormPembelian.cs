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
    public partial class FormPembelian : Form
    {
        Models.PembelianModel Beli = new Models.PembelianModel();
        Controllers.PembelianController pembelianController = new Controllers.PembelianController();

        public FormPembelian()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtKodeBarang.ReadOnly = false;
            //txtNamaBarang.ReadOnly = false;
            txtHargaJual.ReadOnly = false;
        }

        private void FormPembelian_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            clearForm();
        }

        private void clearForm()
        {
            faktur.Text = "";
            cbSupplier.SelectedIndex = -1;
            cbProduk.SelectedIndex = -1;
            txtStok.Text = "";
            txtTotalBeli.Text = "";
            txtHargaJual.Text = "";
            txtHargaBeli.Text = "";
            txtJumlahBarang.Text = "";

        }

        private void LoadComboBoxData()
        {
            cbProduk.DataSource = pembelianController.GetProduk();
            cbProduk.DisplayMember = "ValueName";
            cbProduk.ValueMember = "ValueCode";
            cbSupplier.DataSource = pembelianController.GetSupplier();
            cbSupplier.ValueMember = "Id";
            cbSupplier.DisplayMember = "ValueName";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Beli.faktur = faktur.Text;
            Beli.idSupplier = (int)cbSupplier.SelectedValue;
            Beli.kodeBarang = txtKodeBarang.Text;
            Beli.tglBeli = tgl.Value;
            Beli.hargaBeli = int.Parse(txtHargaBeli.Text);
            Beli.jumlah = int.Parse(txtJumlahBarang.Text);
            Beli.totalBayar = int.Parse(txtTotalBeli.Text, NumberStyles.AllowThousands);
            pembelianController.Create(Beli);
            pembelianController.TambahStok(Beli);
            clearForm();
            MessageBox.Show("Data Pembelian Telah Dimasukkan!", "Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void txtJumlahBarang_TextChanged(object sender, EventArgs e)
        {
            int harga;
            int jumlah;
            if (int.TryParse(txtHargaBeli.Text, out harga) && int.TryParse(txtJumlahBarang.Text, out jumlah))
            {
                int totalHarga = jumlah * harga;
                txtTotalBeli.Text = totalHarga.ToString("N0");
            }
        }

        private void cbProduk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cari = cbProduk.Text;
            Models.ProductModel produkInfo = pembelianController.getProductInfoByName(cari);
            txtKodeBarang.Text = produkInfo.kodeBarang;
            txtStok.Text = produkInfo.stok.ToString("N0");
            txtHargaJual.Text = produkInfo.hargaJual.ToString("N0");
            txtSatuan.Text = produkInfo.satuan;
        }

    }
}
