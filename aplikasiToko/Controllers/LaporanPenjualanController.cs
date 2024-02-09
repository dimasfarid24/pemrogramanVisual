using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace aplikasiToko.Controllers
{
    class LaporanPenjualanController : BaseController
    {

        public LaporanPenjualanController()
        {
            this.table = "transactions";
            //this.ShowAll();
        }

        public DataTable cariDetailTransaksi(string notaTransaksi)
        {
            DataTable detailTransaksi = new DataTable();
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            string query = "SELECT * FROM transactiondetails WHERE notaTransaksi Like @productName";

            MySqlCommand command = new MySqlCommand(query, _connection.getConnection());
            
            // Gunakan parameterized query untuk menghindari SQL Injection
            command.Parameters.AddWithValue("@productName", "%" + notaTransaksi + "%");

            MySqlDataReader data = command.ExecuteReader();
            detailTransaksi.Load(data);
            _connection.getConnection().Close();
            return detailTransaksi;              
        }

    }
}
