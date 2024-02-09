using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;

namespace aplikasiToko.Config
{
    public class Connection
    {
        private static Connection instance;
        private static MySqlConnection connection;
        private readonly string url = "datasource=localhost;username=root;password=;database=aplikasitoko;Convert Zero Datetime=True";

        private Connection()
        {
            try
            {
                connection = new MySqlConnection(this.url);
            }
            catch (Exception err)
            {
                Utils.Notify.notifyError(err);
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public MySqlDataReader Query(string sql)
        {
            try
            {
                MySqlDataReader response;
                connection.Close();
                connection.Open();
                MySqlCommand query = new MySqlCommand(sql, getConnection());
                query.ExecuteNonQuery();
                response = query.ExecuteReader();
                return response;
            }
            catch (Exception error)
            {
                Utils.Notify.notifyError(error);
            }
            return null;
        }

        public static Connection getInstance()
        {
            if (instance == null)
            {
                instance = new Connection();
            }
            return instance;
        }
    }
}