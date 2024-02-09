using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    public class KategoriController: BaseController
    {
        public KategoriController()
        {
            this.table = "categories";
        }

        public bool ValidationInputKategori(Models.KategoriModel Kategori)
        {
            if (Kategori.nama == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return true;
            }
            {
                return false;
            }
        }

        public void Create(Models.KategoriModel Kategori)
        {
            if (this.ValidationInputKategori(Kategori))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("nama", Kategori.nama);
            this.Create(request);
        }
    }
}
