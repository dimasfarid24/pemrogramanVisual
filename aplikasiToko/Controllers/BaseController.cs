using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace aplikasiToko.Controllers
{
    public class BaseController
    {
        public string table = "";
        public Config.Connection _connection = Config.Connection.getInstance();

        public DataTable ShowAll(string query = "")
        {
            DataTable _data = new DataTable();
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlDataReader data;
            if (query == "")
            {
                data = _connection.Query("SELECT * FROM " + this.table);
            }
            else
            {
                data = _connection.Query(query);
            }
            _data.Load(data);
            _connection.getConnection().Close();
            return _data;
        }

        public void Create(IDictionary<string, object> request)
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlCommand _command = _connection.getConnection().CreateCommand();
            string fields = string.Join(", ", request.Keys);
            string values = string.Join(", ", request.Keys.Select(key => "@" + key));
            string sql = "INSERT INTO " + this.table + " (" + fields + ") VALUES (" + values + ")";
            _command.CommandText = sql;
            foreach (var kvp in request)
            {
                _command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
            }

            _command.ExecuteNonQuery();
            _connection.getConnection().Close();
        }

        public void Update(int id, IDictionary<string, object> request)
        {
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlCommand _command = _connection.getConnection().CreateCommand();
            string fields = string.Join(", ", request.Keys.Select(key => key + " = @" + key));
            string sql = "UPDATE " + this.table + " SET " + fields + " WHERE id = " + id;
            _command.CommandText = sql;
            foreach (var kvp in request)
            {
                _command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
            }
            _command.ExecuteNonQuery();
            _connection.getConnection().Close();

        }

        public void Delete(int id)
        {

            if (id < 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus");
                return;
            }
            _connection.getConnection().Close();
            _connection.getConnection().Open();
            MySqlCommand _command = _connection.getConnection().CreateCommand();
            string sql = "DELETE FROM " + this.table + " WHERE id = " + id;
            _command.CommandText = sql;
            _command.ExecuteNonQuery();
            _connection.getConnection().Close();
        }
    }
}