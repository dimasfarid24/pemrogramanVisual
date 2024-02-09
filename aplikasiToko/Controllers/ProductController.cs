using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    public class ProductController: BaseController
    {
        public ProductController()
        {
            this.table = "products";
        }

        public bool ValidationInputBarang(Models.ProductModel Produk)
        {
            if (Produk.kodeBarang == "" || Produk.nama == "" || Produk.kategori == "" || Produk.satuan == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return true;
            }
            else if (Produk.hargaJual <= 0)
            {
                MessageBox.Show("Masukkan harga jual yang benar");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(Models.ProductModel Produk)
        {
            if (this.ValidationInputBarang(Produk))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("kodeProduk", Produk.kodeBarang);
            request.Add("namaProduk", Produk.nama);
            request.Add("idKategori", Produk.kategori);
            request.Add("hargaJual", Produk.hargaJual);
            request.Add("satuan", Produk.satuan);
            request.Add("stok", Produk.stok);
            request.Add("hargaPokok", Produk.hargaPokok);
            this.Create(request);
        }

        public void Update(int id, Models.ProductModel Produk)
        {
            if (this.ValidationInputBarang(Produk))
            {
                return;
            }
            DateTime currentTime = DateTime.Now;
            string timePart = currentTime.ToString("HHmmssddMMyyyy");
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("kodeProduk", Produk.kodeBarang);
            request.Add("namaProduk", Produk.nama);
            request.Add("idKategori", Produk.kategori);
            request.Add("hargaJual", Produk.hargaJual);
            request.Add("satuan", Produk.satuan);
            request.Add("stok", Produk.stok);
            request.Add("ModifiedAt", timePart);
            this.Update(id, request);
        }

        public List<Helpers.ComboBox> GetCategories()
        {
            List<Helpers.ComboBox> items = new List<Helpers.ComboBox>();
            MySqlDataReader categories = this._connection.Query("SELECT * FROM categories");
            while (categories.Read())
            {
                //ComboBox1.Items.Add(new Helpers.ComboBox(categories.GetInt32(0), categories.GetString(1)));
                Helpers.ComboBox item = new Helpers.ComboBox
                {
                    Id = (int)categories["idKategori"],
                    ValueName = categories["nama"].ToString()
                };
                items.Add(item);
            }
            return items;
            //categories.Close();
        }
        
    }
}
