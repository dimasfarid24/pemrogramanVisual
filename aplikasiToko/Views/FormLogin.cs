using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aplikasiToko
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void tryLogin_Click(object sender, EventArgs e)
        {
            Models.Users _user = new Models.Users();
            _user.Username = txtUsername.Text;
            _user.Password = txtPassword.Text;
            Controllers.Authentication _auth = new Controllers.Authentication();
            _auth.isLogin(_user);
            if (Session.Session.Username != "")
            {
                this.Close();
                aplikasiToko.Views.Parent.menu.HandleMenu(true);
            }
            else
            {
                aplikasiToko.Views.Parent.menu.HandleMenu(false);
            } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPass.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

    }
}
