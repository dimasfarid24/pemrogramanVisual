using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aplikasiToko.Views
{
    public partial class FormBarang : Form
    {
        Controllers.ProductController productController = new Controllers.ProductController();
        Models.ProductModel Produk = new Models.ProductModel();
        TambahKategori _kategori;
        int id_product = 0;
                
        public FormBarang()
        {
            InitializeComponent();
            LoadComboBoxData();
            cbKategori.SelectedIndex = -1;
            
        }

        private void LoadComboBoxData()
        {
            cbKategori.DataSource = productController.GetCategories();
            cbKategori.DisplayMember = "ValueName";
            cbKategori.ValueMember = "Id";
            cbKategori.Text = "";
        }

        private void visibleButtonOn()
        {
            simpan.Visible = true;
            batal.Visible = true;
        }
        private void visibleButtonOff()
        {
            simpan.Visible = false;
            batal.Visible = false;
        }

        private void lockForm()
        {
            txtHargaJual.Enabled = false;
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            cbKategori.Enabled = false;
            cbSatuan.Enabled = false;
        }

        private void unlockForm()
        {
            txtHargaJual.Enabled = true;
            txtKode.Enabled = true;
            txtNama.Enabled = true;
            cbKategori.Enabled = true;
            cbSatuan.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            unlockForm();
            clearForm();
            tambah.Enabled = false;
            tambahkategori.Enabled = false;
            editBarang.Enabled = false;
            visibleButtonOn();
        }
        private void batal_Click(object sender, EventArgs e)
        {
            lockForm();
            clearForm();
            tambah.Enabled = true;
            tambahkategori.Enabled = true;
            editBarang.Enabled = true;
            visibleButtonOff();
        }

        private void simpan_Click(object sender, EventArgs e)
        {
           Produk.nama = txtNama.Text;
           Produk.kodeBarang = txtKode.Text;
           Produk.kategori = cbKategori.SelectedValue.ToString();
           Produk.satuan = cbSatuan.Text;
           Produk.stok = 0;
           Produk.hargaPokok = 0;
           try
           {
               Produk.hargaJual = int.Parse(txtHargaJual.Text);
               // Lanjutkan dengan penggunaan nilai integer yang sudah diubah
           }
           catch (FormatException)
           {
               // Penanganan kesalahan jika input tidak dapat diubah menjadi integer
               MessageBox.Show("Masukkan Harga Jual dengan Angka yang benar");
               return;
           }
           productController.Create(Produk);
           dataGridView1.DataSource = productController.ShowAll("SELECT idProduk kodeProduk, namaProduk, categories.nama AS kategori, hargaPokok, hargaJual, satuan, stok  FROM products JOIN categories ON products.idKategori = categories.idKategori");
           clearForm();
        }

        private void clearForm()
        {
            txtHargaJual.Text = "";
            txtKode.Text = "";
            txtNama.Text = "";
            cbKategori.Text = "";
            cbSatuan.Text = "";
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = productController.ShowAll("SELECT idProduk, products.idKategori AS idKategori, kodeProduk, namaProduk, categories.nama AS kategori, hargaPokok, hargaJual, satuan, stok  FROM products JOIN categories ON products.idKategori = categories.idKategori");
            dataGridView1.Columns["idProduk"].Visible = false;
            dataGridView1.Columns["idKategori"].Visible = false;
        }

        private void tambahkategori_Click(object sender, EventArgs e)
        {
            if (_kategori == null)
            {
                _kategori = new TambahKategori();
                //_kategori.MdiParent = this;
                _kategori.FormClosed += new FormClosedEventHandler(_kategori_FormClosed);
                tambah.Enabled = false;
                tambahkategori.Enabled = false;
                editBarang.Enabled = false;
                _kategori.Show();
            }
            else
            {
                _kategori.Activate();
            }
        }

        void _kategori_FormClosed(object sender, FormClosedEventArgs e)
        {
            _kategori = null;
            tambah.Enabled = true;
            tambahkategori.Enabled = true;
            editBarang.Enabled = true;
        }

        private void cbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string item = ((Helpers.ComboBox)cbKategori.SelectedItem).Id.ToString();
            //string value = ((Helpers.ComboBox)cbKategori.SelectedItem).Value.ToString();
        }

        private void tambahstok_Click(object sender, EventArgs e)
        {
            if (editBarang.Text == "Edit Barang")
            {
                unlockForm();
                editBarang.Text = "Batal";                
            }
            else
            {
                lockForm();
                editBarang.Text = "Edit Barang";
                editBarang.Enabled = false;
                clearForm();
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id_product = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idProduk"].Value.ToString());
                txtKode.Text = dataGridView1.Rows[e.RowIndex].Cells["kodeProduk"].Value.ToString();
                txtNama.Text = dataGridView1.Rows[e.RowIndex].Cells["namaProduk"].Value.ToString();
                cbKategori.Text = dataGridView1.Rows[e.RowIndex].Cells["kategori"].Value.ToString();
                cbSatuan.Text = dataGridView1.Rows[e.RowIndex].Cells["satuan"].Value.ToString();
                txtStok.Text = dataGridView1.Rows[e.RowIndex].Cells["stok"].Value.ToString();
                txtHargaPokok.Text = dataGridView1.Rows[e.RowIndex].Cells["hargaPokok"].Value.ToString();
                txtHargaJual.Text = dataGridView1.Rows[e.RowIndex].Cells["hargaJual"].Value.ToString();             
                //lockForm();
                
                //tambah.Enabled = false;
                editBarang.Enabled = true;
                //hapus.Enabled = true;
                //edit.Enabled = true;
            }
        }
    }
}
