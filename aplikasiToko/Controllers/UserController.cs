using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    public class UserController: BaseController
    {
        public UserController()
        {
            this.table = "users";
        }

        private bool ValidationForm(Models.UserModel User)
        {
            if (User.Username == "" || User.Password == "" || User.alamat == "" || User.email == "" || User.telp == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return true;
            }

            return false;
        }

        public void Create(Models.UserModel User)
        {
            if (this.ValidationForm(User))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", User.Username);
            request.Add("pass", User.Password);
            request.Add("alamat", User.alamat);
            request.Add("email", User.email);
            request.Add("telp", User.telp);
            request.Add("gender", User.gender);
            this.Create(request);
        }

        public void Update(int id, Models.UserModel User)
        {
            if (this.ValidationForm(User))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", User.Username);
            request.Add("pass", User.Password);
            request.Add("alamat", User.alamat);
            request.Add("email", User.email);
            request.Add("telp", User.telp);
            request.Add("gender", User.gender);
            this.Update(id, request);
        }

        public void Destroy(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus");
                return;
            }
            if (Utils.Notify.notifyDelete())
            {
                this.Delete(id);
            }
        } 
    }
}
