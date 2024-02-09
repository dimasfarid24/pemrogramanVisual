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
    public partial class FormKaryawan : Form
    {
        Controllers.UserController userController = new Controllers.UserController();
        Models.UserModel User = new Models.UserModel();
        int id_user = 0;

        public FormKaryawan()
        {
            InitializeComponent();
        }

        private void FormKaryawan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = userController.ShowAll();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["createdAt"].Visible = false;
            dataGridView1.Columns["updatedAt"].Visible = false;
            rbMale.Checked = true;
            edit.Enabled = false;
            hapus.Enabled = false;
        }

        private void lockForm()
        {
            txtUsername.Enabled = false;
            txtPass.Enabled = false;
            txtAlamat.Enabled = false;
            txtEmail.Enabled = false;
            txtTelp.Enabled = false;
            rbFemale.Enabled = false;
            rbMale.Enabled = false;
        }

        private void unlockForm()
        {
            txtUsername.Enabled = true;
            txtPass.Enabled = true;
            txtAlamat.Enabled = true;
            txtEmail.Enabled = true;
            txtTelp.Enabled = true;
            rbFemale.Enabled = true;
            rbMale.Enabled = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id_user = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                txtPass.Text = dataGridView1.Rows[e.RowIndex].Cells["pass"].Value.ToString();
                txtAlamat.Text = dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                txtTelp.Text = dataGridView1.Rows[e.RowIndex].Cells["telp"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString() == "P")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
                lockForm();
                tambah.Enabled = false;
                edit.Text = "Edit";
                hapus.Enabled = true;
                edit.Enabled = true;
            }
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            if (tambah.Text == "Simpan")
            {
                User.Username = txtUsername.Text;
                User.Password = txtPass.Text;
                User.alamat = txtAlamat.Text;
                User.email = txtEmail.Text;
                User.telp = txtTelp.Text;
                if (rbMale.Checked == true)
                {
                    User.gender = "L";
                }
                if (rbFemale.Checked == true)
                {
                    User.gender = "P";
                }
                userController.Update(id_user, User);
                dataGridView1.DataSource = userController.ShowAll();
                tambah.Text = "Tambah";
                id_user = 0;
            }
            else
            {
                if (id_user > 0)
                {
                    id_user = 0;
                    clearForm();
                    return;
                }
                User.Username = txtUsername.Text;
                User.Password = txtPass.Text;
                User.alamat = txtAlamat.Text;
                User.email = txtEmail.Text;
                User.telp = txtTelp.Text;
                if (rbMale.Checked == true)
                {
                    User.gender = "L";
                }
                if (rbFemale.Checked == true)
                {
                    User.gender = "P";
                }
                userController.Create(User);
                dataGridView1.DataSource = userController.ShowAll();
            }
            clearForm();
            tambah.Enabled = true;
            edit.Text = "Edit";
            hapus.Enabled = true; 
        }

        private void clearForm()
        {
            txtUsername.Text = "";
            txtPass.Text = "";
            txtAlamat.Text = "";
            txtEmail.Text = "";
            txtTelp.Text = "";
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (edit.Text == "Batal")
            {
                edit.Text = "Edit";
                tambah.Text = "Tambah";
                edit.Enabled = false;
                clearForm();
            }
            else
            {
                unlockForm();
                tambah.Text = "Simpan";
                hapus.Enabled = false;
                edit.Text = "Batal";
                tambah.Enabled = true;
            }
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            userController.Destroy(id_user);
            dataGridView1.DataSource = userController.ShowAll();
            clearForm();
            tambah.Enabled = true;
        }
    }
}
