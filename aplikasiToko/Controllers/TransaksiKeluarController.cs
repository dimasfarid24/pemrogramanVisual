using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    class TransaksiKeluarController: BaseController
    {        
        
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

        public void getProductData(string kodeProduk)
        {

        }

        public List<Helpers.ComboBox> GetPelanggan()
        {
            List<Helpers.ComboBox> pelangganItem = new List<Helpers.ComboBox>();
            MySqlDataReader products = this._connection.Query("SELECT id, nama, kodePelanggan FROM customers");
            while (products.Read())
            {
                //ComboBox1.Items.Add(new Helpers.ComboBox(categories.GetInt32(0), categories.GetString(1)));
                Helpers.ComboBox item = new Helpers.ComboBox
                {
                    Id = (int)products["id"],
                    ValueName = products["nama"].ToString(),
                    ValueCode = products["kodePelanggan"].ToString()
                };
                pelangganItem.Add(item);
            }
            return pelangganItem;
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

            // Jika tidak ada data, kembalikan nilai default atau lakukan penanganan yang sesuai
            //return null;
        }

        public Models.PelangganModel getCustomersInfoByName(string productName)
        {
            Models.PelangganModel infoCustomers = new Models.PelangganModel();
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            string query = "SELECT nama, kodePelanggan FROM customers WHERE nama = @customerName";

            using (MySqlCommand command = new MySqlCommand(query, _connection.getConnection()))
            {
                // Gunakan parameterized query untuk menghindari SQL Injection
                command.Parameters.AddWithValue("@customerName", productName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Pastikan ada data sebelum mencoba membacanya
                        //infoCustomers.id = (int)reader["id"];
                        infoCustomers.Nama = reader["nama"].ToString();
                        infoCustomers.Kode = reader["kodePelanggan"].ToString();
                    }
                }
                _connection.getConnection().Close();
                return infoCustomers;
            }

            // Jika tidak ada data, kembalikan nilai default atau lakukan penanganan yang sesuai
            //return null;
        }

        public string NotaTransaksi()
        {
            // Mendapatkan waktu saat ini
            DateTime currentTime = DateTime.Now;

            // Menggunakan format waktu tertentu untuk mendapatkan bagian awal kode
            string timePart = currentTime.ToString("yyyyMMddHHmmss");

            // Menggunakan bagian angka acak untuk memastikan keunikan
            Random random = new Random();
            string randomPart = random.Next(1000, 9999).ToString();

            // Menggabungkan kedua bagian dengan menambahkan prefix
            string uniqueCode = "TRX-" + timePart + randomPart;

            return uniqueCode;
        }
        private bool ValidasiInputBarang(Models.DetailTransaksiKeluarModel Transaksi)
        {

            if (Transaksi.nota == "" || Transaksi.namaBarang == "" || Transaksi.jumlah == 0)
            {
                MessageBox.Show("Masukkan data dengan Benar!");
                return true;
            }           
            else
            {
                return false;
            }
        }


        public void CreateDetailTransaksi(Models.DetailTransaksiKeluarModel Transaksi)
        {
            if (this.ValidasiInputBarang(Transaksi))
            {
                return;
            }
            this.table = "tempTransaksi";
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("nota", Transaksi.nota);
            request.Add("kodeBarang", Transaksi.kodeBarang);
            request.Add("namaBarang", Transaksi.namaBarang);
            request.Add("jumlah", Transaksi.jumlah);
            request.Add("hargaSatuan", Transaksi.hargaSatuan);
            request.Add("hargaAkhir", Transaksi.hargaAkhir);
            this.Create(request);
        }

        public DataTable ShowTempTransaksi()
        {
            DataTable _data = new DataTable();
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlDataReader data;            
            data = _connection.Query("SELECT * FROM temptransaksi");
            _data.Load(data);
            _connection.getConnection().Close();
            return _data;
        }

        public void DestroyTempTransaksi()
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            _connection.Query("TRUNCATE temptransaksi");
            _connection.getConnection().Close();
        }

        public void DestroyTempTransaksi(string kodeBarang)
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            _connection.Query("DELETE FROM temptransaksi WHERE kodeBarang = '" + kodeBarang + "'");
            _connection.getConnection().Close();
        }

        public void UpdateTempTransaksi(string kodeBarang, Models.DetailTransaksiKeluarModel detailTransaksi)
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            _connection.Query("UPDATE temptransaksi SET jumlah = " + detailTransaksi.jumlah + ", hargaAkhir = " + detailTransaksi.hargaAkhir + " WHERE temptransaksi.kodeBarang = '" + kodeBarang + "'");
            _connection.getConnection().Close();
        }

        private bool validasiInputTransaksi(Models.TransaksiKeluarModel Transaksi)
        {
            if(Transaksi.idUser <= 0 || Transaksi.kodePelanggan == "" || Transaksi.nota == "" || Transaksi.totalHarga <= 0 || Transaksi.bayar <= 0 || Transaksi.kembali < 0)
            {                
                MessageBox.Show("Mohon Isi Transaksi Dengan Benar","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void simpanTransaksiPembelian(Models.TransaksiKeluarModel Transaksi)
        {
            if (validasiInputTransaksi(Transaksi))
            {
                return;
            }
            this.table = "transactions";
            IDictionary<string, object> request = new Dictionary<string, object>();
            request.Add("notaTransaksi", Transaksi.nota);
            request.Add("idUser", Transaksi.idUser);
            request.Add("kodeCustomer", Transaksi.kodePelanggan);
            request.Add("totalHarga", Transaksi.totalHarga);
            request.Add("totalTagihan", Transaksi.totalTagihan);
            request.Add("bayar", Transaksi.bayar);
            request.Add("diskon", Transaksi.diskon);
            request.Add("kembali", Transaksi.kembali);

            this.Create(request);
            _connection.getConnection().Open();
            //_connection.Query("UPDATE products JOIN temptransaksi ON temptransaksi.kodeBarang = products.kodeProduk SET products.stok = products.stok - temptransaksi.jumlah");
            //_connection.Query("INSERT INTO transactiondetails ( notaTransaksi, kodeBarang, namaBarang, banyak, hargaSatuan, hargaAkhir) SELECT nota, kodeBarang, namaBarang, jumlah, hargaSatuan, hargaAkhir FROM temptransaksi");
            _connection.getConnection().Close();
        }

        public void kurangiStok()
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlCommand _command = _connection.getConnection().CreateCommand();
            string sql = "UPDATE products JOIN temptransaksi ON temptransaksi.kodeBarang = products.kodeProduk SET products.stok = products.stok - temptransaksi.jumlah";
            _command.CommandText = sql;
            _command.ExecuteNonQuery();
            _connection.getConnection().Close();
        }

        public void simpanDetailTransaksi()
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlCommand _command = _connection.getConnection().CreateCommand();
            string sql = "INSERT INTO transactiondetails ( notaTransaksi, kodeBarang, namaBarang, banyak, hargaSatuan, hargaAkhir) SELECT nota, kodeBarang, namaBarang, jumlah, hargaSatuan, hargaAkhir FROM temptransaksi;";
            _command.CommandText = sql;
            _command.ExecuteNonQuery();
            _connection.getConnection().Close();
        }

    }
}
