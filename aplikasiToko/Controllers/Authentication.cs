using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    class Authentication
    {
        private Config.Connection __connection = Config.Connection.getInstance();
        public void isLogin(Models.Users User)
        {
            try
            {
                MySqlDataReader exist = __connection.Query("SELECT * FROM users WHERE username = '" + User.Username + "' AND pass ='" + User.Password + "'");
                if (exist.Read())
                {
                    Session.Session.Username = exist["username"].ToString();
                    Session.Session.Id = exist["id"].ToString();
                    MessageBox.Show("Semoga Harimu Menyenangkan!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Session.Session.Username = "";
                    MessageBox.Show("Username atau Password Salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
