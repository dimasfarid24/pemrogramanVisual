using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    public class SupplierController : BaseController
    {
        public SupplierController()
        {
            this.table = "suppliers";
        }

        private bool ValidasiFormSupplier(Models.SupplierModel Supplier)
        {
            if (Supplier.id < 0 || Supplier.nama == "" || Supplier.telp == "" || Supplier.email == "" || Supplier.alamat == "")
            {
                MessageBox.Show("Masukkan data yang valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(Models.SupplierModel Supplier)
        {
            if(ValidasiFormSupplier(Supplier))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("nama", Supplier.nama);
            request.Add("telp", Supplier.telp);
            request.Add("email", Supplier.email);
            request.Add("alamat", Supplier.alamat);
            this.Create(request);
            MessageBox.Show("Supplier telah ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
