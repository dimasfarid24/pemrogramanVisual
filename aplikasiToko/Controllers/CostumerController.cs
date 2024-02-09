using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    public class CostumerController : BaseController
    {
        public CostumerController()
        {
            this.table = "customers";
        }

        private bool ValidationForm(Models.PelangganModel Costumer)
        {
            if (Costumer.Nama == "" || Costumer.Kode == "" || Costumer.alamat == "" || Costumer.email == "" || Costumer.telp == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return true;
            }

            return false;
        }

        public void Create(Models.PelangganModel Costumer)
        {
            if (this.ValidationForm(Costumer))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("nama", Costumer.Nama);
            request.Add("kodePelanggan", Costumer.Kode);
            request.Add("alamat", Costumer.alamat);
            request.Add("email", Costumer.email);
            request.Add("telp", Costumer.telp);
            request.Add("gender", Costumer.gender);
            this.Create(request);
        }

        public void Update(int id, Models.PelangganModel Costumer)
        {
            if (this.ValidationForm(Costumer))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("nama", Costumer.Nama);
            request.Add("kodePelanggan", Costumer.Kode);
            request.Add("alamat", Costumer.alamat);
            request.Add("email", Costumer.email);
            request.Add("telp", Costumer.telp);
            request.Add("gender", Costumer.gender);
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

