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
    public partial class TambahKategori : Form
    {
        Controllers.KategoriController kategoriController = new Controllers.KategoriController();
        Models.KategoriModel Kategori = new Models.KategoriModel();
        public TambahKategori()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori.nama = txtKategori.Text;
            kategoriController.Create(Kategori);
            this.Close();
            MessageBox.Show("Kategori berhasil ditambahkan!");
        }
    }
}
