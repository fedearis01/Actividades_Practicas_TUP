using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;


namespace RepositoryFacturation.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-OIF9LLG\SQLEXPRESS;Initial Catalog=Facturation_2025;Integrated Security=True;");
        }
        //Patron Singleton
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;  
        }
        public DataTable ExecuteQuery(string sp)
        {
            DataTable dt = new DataTable();
            _connection.Open();
            var cmd = new SqlCommand(sp,_connection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sp;
            dt.Load(cmd.ExecuteReader());
            _connection.Close();
            return dt;
        }
    }
}
