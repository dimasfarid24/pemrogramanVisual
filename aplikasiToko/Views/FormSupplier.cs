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
    public partial class FormSupplier : Form
    {
        Controllers.SupplierController supplierController = new Controllers.SupplierController();
        Models.SupplierModel supplier = new Models.SupplierModel();

        public FormSupplier()
        {
            InitializeComponent();
        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = supplierController.ShowAll();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["createdAt"].Visible = false;
            dataGridView1.Columns["updatedAt"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplier.nama = nama.Text.ToString();
            supplier.telp = telp.Text.ToString();
            supplier.email = email.Text.ToString();
            supplier.alamat = alamat.Text.ToString();
            supplierController.Create(supplier);
            clearForm();
            dataGridView1.DataSource = supplierController.ShowAll();
        }

        private void clearForm()
        {
            nama.Text = "";
            telp.Text = "";
            email.Text = "";
            alamat.Text = "";
        }
    }
}
