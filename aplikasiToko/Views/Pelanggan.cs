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
    public partial class Pelanggan : Form
    {
        Controllers.CostumerController costumerController = new Controllers.CostumerController();
        Models.PelangganModel Costumer = new Models.PelangganModel();
        int id_costumer = 0;


        public Pelanggan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tambahkan.Text == "Simpan")
            {
                Costumer.Kode = txtKodePelanggan.Text;
                Costumer.Nama = txtNama.Text;
                Costumer.alamat = inAlamat.Text;
                Costumer.email = inEmail.Text;
                Costumer.telp = inTelp.Text;
                if (cbMale.Checked == true)
                {
                    Costumer.gender = "L";
                }
                if (cbFemale.Checked == true)
                {
                    Costumer.gender = "P";
                }
                costumerController.Update(id_costumer, Costumer);
                dataGridView1.DataSource = costumerController.ShowAll();
                tambahkan.Text = "Tambah";
                id_costumer = 0;
            }
            else
            {
                if (id_costumer > 0)
                {
                    id_costumer = 0;
                    txtKodePelanggan.Text = "";
                    txtNama.Text = "";
                    inAlamat.Text = "";
                    inEmail.Text = "";
                    inTelp.Text = "";
                    return;
                }
                Costumer.Kode = txtKodePelanggan.Text;
                Costumer.Nama = txtNama.Text;
                Costumer.alamat = inAlamat.Text;
                Costumer.email = inEmail.Text;
                Costumer.telp = inTelp.Text;
                if (cbMale.Checked == true)
                {
                    Costumer.gender = "L";
                }
                if (cbFemale.Checked == true)
                {
                    Costumer.gender = "P";
                }
                costumerController.Create(Costumer);
                dataGridView1.DataSource = costumerController.ShowAll();
            }
            clearForm();
            tambahkan.Enabled = true;
            editkan.Text = "Edit";
            hapuskan.Enabled = true;
        }

        private void clearForm()
        {
            txtKodePelanggan.Text = "";
            txtNama.Text = "";
            inAlamat.Text = "";
            inEmail.Text = "";
            inTelp.Text = "";
        }

        private void lockForm()
        {
            txtKodePelanggan.Enabled = false;
            txtNama.Enabled = false;
            inAlamat.Enabled = false;
            inEmail.Enabled = false;
            inTelp.Enabled = false;
            cbFemale.Enabled = false;
            cbMale.Enabled = false;
        }

        private void unlockForm()
        {
            txtKodePelanggan.Enabled = true;
            txtNama.Enabled = true;
            inAlamat.Enabled = true;
            inEmail.Enabled = true;
            inTelp.Enabled = true;
            cbFemale.Enabled = true;
            cbMale.Enabled = true;
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            
        }

        private void tambahkan_Click(object sender, EventArgs e)
        {
            if (tambahkan.Text == "Simpan")
            {
                Costumer.Kode = txtKodePelanggan.Text;
                Costumer.Nama = txtNama.Text;
                Costumer.alamat = inAlamat.Text;
                Costumer.email = inEmail.Text;
                Costumer.telp = inTelp.Text;
                if (cbMale.Checked == true)
                {
                    Costumer.gender = "L";
                }
                if (cbFemale.Checked == true)
                {
                    Costumer.gender = "P";
                }
                costumerController.Update(id_costumer, Costumer);
                dataGridView1.DataSource = costumerController.ShowAll();
                tambahkan.Text = "Tambah";
                id_costumer = 0;
            }
            else
            {
                if (id_costumer > 0)
                {
                    id_costumer = 0;
                    txtKodePelanggan.Text = "";
                    txtNama.Text = "";
                    inAlamat.Text = "";
                    inEmail.Text = "";
                    inTelp.Text = "";
                    return;
                }
                Costumer.Kode = txtKodePelanggan.Text;
                Costumer.Nama = txtNama.Text;
                Costumer.alamat = inAlamat.Text;
                Costumer.email = inEmail.Text;
                Costumer.telp = inTelp.Text;
                if (cbMale.Checked == true)
                {
                    Costumer.gender = "L";
                }
                if (cbFemale.Checked == true)
                {
                    Costumer.gender = "P";
                }
                costumerController.Create(Costumer);
                dataGridView1.DataSource = costumerController.ShowAll();
            }
            clearForm();
            tambahkan.Enabled = true;
            editkan.Text = "Edit";
            hapuskan.Enabled = true; 
        }

        private void Pelanggan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = costumerController.ShowAll();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["createdAt"].Visible = false;
            dataGridView1.Columns["updatedAt"].Visible = false;
            cbMale.Checked = true;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id_costumer = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                txtKodePelanggan.Text = dataGridView1.Rows[e.RowIndex].Cells["kodePelanggan"].Value.ToString();
                txtNama.Text = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                inAlamat.Text = dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value.ToString();
                inEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                inTelp.Text = dataGridView1.Rows[e.RowIndex].Cells["telp"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString() == "P")
                {
                    cbMale.Checked = true;
                }
                else
                {
                    cbFemale.Checked = true;
                }
                lockForm();
                tambahkan.Enabled = false;
                editkan.Text = "Edit";
                hapuskan.Enabled = true;
            }
        }

        private void editkan_Click(object sender, EventArgs e)
        {
            if (editkan.Text == "Batal")
            {
                editkan.Text = "Edit";
                tambahkan.Text = "Tambah";
                hapuskan.Enabled = true;
                clearForm();
            }
            else
            {
                unlockForm();
                tambahkan.Text = "Simpan";
                hapuskan.Enabled = false;
                editkan.Text = "Batal";
                tambahkan.Enabled = true;
            }
        }

        private void hapuskan_Click(object sender, EventArgs e)
        {
            costumerController.Destroy(id_costumer);
            dataGridView1.DataSource = costumerController.ShowAll();
            clearForm();
            tambahkan.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
