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
    public partial class LaporanPenjualan : Form
    {
        Controllers.LaporanPenjualanController laporanPenjualan = new Controllers.LaporanPenjualanController();
        string nota = "";

        public LaporanPenjualan()
        {
            InitializeComponent();
        }

        private void LaporanPenjualan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = laporanPenjualan.ShowAll("SELECT notaTransaksi,users.username AS Kasir, kodeCustomer, totalHarga, diskon, totalTagihan, bayar, kembali, DATE_FORMAT(tglTransaksi, '%d-%m-%Y') AS Tanggal FROM transactions JOIN users ON transactions.idUser = users.id");
            dataGridView1.Columns["notaTransaksi"].Width = 200;
            //dataGridView1.Columns["idKategori"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nota = dataGridView1.Rows[e.RowIndex].Cells["notaTransaksi"].Value.ToString();
            cari.Text = nota;
            //dataGridView2.DataSource = laporanPenjualan.getDetailTransaksi(nota);
        }

        private void cari_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = laporanPenjualan.cariDetailTransaksi(cari.Text);
        }

    }
}
