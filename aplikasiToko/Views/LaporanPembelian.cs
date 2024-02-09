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
    public partial class LaporanPembelian : Form
    {
        Controllers.LaporanPembelianController laporanPembelian = new Controllers.LaporanPembelianController();

        public LaporanPembelian()
        {
            InitializeComponent();
        }

        private void LaporanPembelian_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = laporanPembelian.ShowAll("SELECT faktur AS Faktur, suppliers.nama AS Supplier, kodeBarang, hargaBeli, jumlah, totalHarga, tglBeli FROM transactionbuy JOIN suppliers ON transactionbuy.idSupplier = suppliers.id ");
        }
    }
}
