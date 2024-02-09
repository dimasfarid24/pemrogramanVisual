using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    public class PembelianController: BaseController
    {
        public PembelianController()
        {
            this.table = "transactionbuy";
        }

        public bool ValidasiFormBeli(Models.PembelianModel Beli)
        {
            if (Beli.faktur == "" || Beli.idSupplier < 0 || Beli.kodeBarang == "" || Beli.jumlah < 0 || Beli.hargaBeli < 0 || Beli.totalBayar < 0 || Beli.tglBeli == null)
            {
                MessageBox.Show("Masukkan Data Dengan Benar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(Models.PembelianModel Beli)
        {
            if (ValidasiFormBeli(Beli))
            {
                return;
            }
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("faktur", Beli.faktur);
            request.Add("idSupplier", Beli.idSupplier);
            request.Add("tglBeli", Beli.tglBeli);
            request.Add("hargaBeli", Beli.hargaBeli);
            request.Add("kodebarang", Beli.kodeBarang);
            request.Add("jumlah", Beli.jumlah);
            request.Add("totalHarga", Beli.totalBayar);
            this.Create(request);
        }

        public void TambahStok(Models.PembelianModel Beli)
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlCommand _command = _connection.getConnection().CreateCommand();
            string sql = "UPDATE products SET stok = (stok + " + Beli.jumlah + "), hargaPokok = " + Beli.hargaBeli + " WHERE products.kodeProduk = '" + Beli.kodeBarang + "'";
            _command.CommandText = sql;
            _command.ExecuteNonQuery();
            _connection.getConnection().Close();
        }

        public List<Helpers.ComboBox> GetSupplier()
        {
            List<Helpers.ComboBox> supplierItem = new List<Helpers.ComboBox>();
            MySqlDataReader suppliers = this._connection.Query("SELECT id, nama FROM suppliers");
            while (suppliers.Read())
            {
                //ComboBox1.Items.Add(new Helpers.ComboBox(categories.GetInt32(0), categories.GetString(1)));
                Helpers.ComboBox item = new Helpers.ComboBox
                {
                    Id = (int)suppliers["id"],
                    ValueName = suppliers["nama"].ToString(),
                };
                supplierItem.Add(item);
            }
            return supplierItem;
        }

        public List<Helpers.ComboBox> GetProduk()
        {
            List<Helpers.ComboBox> produkItem = new List<Helpers.ComboBox>();
            MySqlDataReader products = this._connection.Query("SELECT idProduk, namaProduk, kodeProduk FROM products");
            while (products.Read())
            {
                //ComboBox1.Items.Add(new Helpers.ComboBox(categories.GetInt32(0), categories.GetString(1)));
                Helpers.ComboBox item = new Helpers.ComboBox
                {
                    Id = (int)products["idProduk"],
                    ValueName = products["namaProduk"].ToString(),
                    ValueCode = products["kodeProduk"].ToString()
                };
                produkItem.Add(item);
            }
            return produkItem;
            //categories.Close();
        }

        public Models.ProductModel getProductInfoByName(string productName)
        {
            Models.ProductModel infoProduk = new Models.ProductModel();
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            string query = "SELECT * FROM products WHERE namaProduk = @productName";

            using (MySqlCommand command = new MySqlCommand(query, _connection.getConnection()))
            {
                // Gunakan parameterized query untuk menghindari SQL Injection
                command.Parameters.AddWithValue("@productName", productName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Pastikan ada data sebelum mencoba membacanya
                        infoProduk.kodeBarang = reader["kodeProduk"].ToString();
                        infoProduk.stok = (int)reader["stok"];
                        infoProduk.satuan = reader["satuan"].ToString();
                        infoProduk.hargaJual = (int)reader["hargaJual"];
                    }
                }
                _connection.getConnection().Close();
                return infoProduk;
            }
        }
    }
}
