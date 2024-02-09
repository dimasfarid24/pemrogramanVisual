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
    public partial class Parent : Form
    {
        FormLogin _login;
        FormPenjualan _transaksi;
        FormKaryawan _karyawan;
        FormBarang _produk;
        Pelanggan _pelanggan;
        FormSupplier _supplier;
        FormPembelian _pembelianStok;
        LaporanPenjualan _penjualan;
        LaporanPembelian _laporanbeli;
        public static Parent menu;

        public Parent()
        {
            InitializeComponent();
        }

        //code berikut akan dijalankan saat Parent dibuka
        private void Parent_Load(object sender, EventArgs e)
        {
            //this.HandleLogin();
            //menu = this;

            if (_login == null)
            {
                _login = new FormLogin();
                _login.MdiParent = this;
                _login.FormClosed += new FormClosedEventHandler(_login_FormClosed);
                _login.Show();
            }
            _login.Activate();
            loginToolStripMenuItem.Enabled = false;
            menu = this;
        }

        public void HandleMenu(bool status)
        {
            loginToolStripMenuItem.Enabled = !status;
            logoutToolStripMenuItem.Enabled = status;
            transaksiToolStripMenuItem.Enabled = status;
            pengaturanToolStripMenuItem.Enabled = status;
            laporanToolStripMenuItem.Enabled = status;
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        //dijalankan saat form transaksi penjualan ditutup
        private void TransaksiClose(object sender, FormClosedEventArgs e)
        {
            _transaksi = null;
        }
        //ketika tombol transaksi penjualan di klik
        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_transaksi == null)
            {
                _transaksi = new FormPenjualan();
                _transaksi.MdiParent = this;
                _transaksi.FormClosed += new FormClosedEventHandler(TransaksiClose);
                _transaksi.Show();
            }
            else
            {
                _transaksi.Activate();
            }
        }

        //ketika tombol pengguna di klik
        private void penggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_karyawan == null)
            {
                _karyawan = new FormKaryawan();
                _karyawan.MdiParent = this;
                _karyawan.FormClosed += new FormClosedEventHandler(KaryawanClose);
                _karyawan.Show();
            }
            else
            {
                _karyawan.Activate();
            }
        }
        //ketika form pengguna ditutup
        private void KaryawanClose(object sender, FormClosedEventArgs e)
        {
            _karyawan = null;
        }

        //ketika tombol barang di klik
        private void barangToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_produk == null)
            {
                _produk = new FormBarang();
                _produk.MdiParent = this;
                _produk.FormClosed += new FormClosedEventHandler(ProdukClose);
                _produk.Show();
            }
            else
            {
                _produk.Activate();
            }
        }
        //ketika form barang ditutup
        private void ProdukClose(object sender, FormClosedEventArgs e)
        {
            _produk = null;
        }

        //menu strip login button
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_login== null)
            {
                _login = new FormLogin();
                _login.MdiParent = this;
                _login.FormClosed += new FormClosedEventHandler(_login_FormClosed);
                _login.Show();
            }
            else
            {
                _login.Activate();
                loginToolStripMenuItem.Enabled = false;
            } 
        }

        void _login_FormClosed(object sender, FormClosedEventArgs e)
        {
            _login = null;
            loginToolStripMenuItem.Enabled = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pelanggan == null)
            {
                _pelanggan = new Pelanggan();
                _pelanggan.MdiParent = this;
                _pelanggan.FormClosed += new FormClosedEventHandler(PelangganClose);
                _pelanggan.Show();
            }
            else
            {
                _pelanggan.Activate();
            }
        }
        private void PelangganClose(object sender, FormClosedEventArgs e)
        {
            _pelanggan = null;
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_supplier == null)
            {
                _supplier = new FormSupplier();
                _supplier.MdiParent = this;
                _supplier.FormClosed += new FormClosedEventHandler(SupplierClose);
                _supplier.Show();
            }
            else
            {
                _supplier.Activate();
            }
        }

        private void SupplierClose(object sender, FormClosedEventArgs e)
        {
            _supplier = null;
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pembelianStok == null)
            {
                _pembelianStok = new FormPembelian();
                _pembelianStok.MdiParent = this;
                _pembelianStok.FormClosed += new FormClosedEventHandler(PembelianClosed);
                _pembelianStok.Show();
            }
            else
            {
                _pembelianStok.Activate();
            }
        }

        private void PembelianClosed(object sender, FormClosedEventArgs e)
        {
            _pembelianStok = null;
        }

        private void penjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_penjualan == null)
            {
                _penjualan = new LaporanPenjualan();
                _penjualan.MdiParent = this;
                _penjualan.FormClosed += new FormClosedEventHandler(laporanPenjualanClosed);
                _penjualan.Show();
            }
            else
            {
                _penjualan.Activate();
            }
        }

        private void laporanPenjualanClosed(object sender, FormClosedEventArgs e)
        {
            _penjualan = null;
        }

        private void pembelianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_laporanbeli == null)
            {
                _laporanbeli = new LaporanPembelian();
                _laporanbeli.MdiParent = this;
                _laporanbeli.FormClosed += new FormClosedEventHandler(laporanBeliClosed);
                _laporanbeli.Show();
            }
            else
            {
                _laporanbeli.Activate();
            }
        }

        private void laporanBeliClosed(object sender, FormClosedEventArgs e)
        {
            _laporanbeli = null;
        }
    }
}
