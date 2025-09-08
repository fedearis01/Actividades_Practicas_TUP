using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using RepositoryFacturation.Domain;


namespace Proyecto_Practica01_.Data.Helpers
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-OIF9LLG\SQLEXPRESS;Initial Catalog=Facturation_2025;Integrated Security=True;Trust Server Certificate=True");
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
        public DataTable ExecuteQuery(string sp,List<ParameterSP>? p = null)
        {
            DataTable dt = new DataTable();
            _connection.Open();
            var cmd = new SqlCommand(sp,_connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (p != null) 
            {
                foreach (ParameterSP param in p)
                {
                    cmd.Parameters.AddWithValue(param.Name,param.Value);
                }
            }
            dt.Load(cmd.ExecuteReader());
            _connection.Close();
            return dt;
        }
        public int ExecuteSave(string sp,List<ParameterSP>? lp = null)
        {
            int filasAfectadas = 0;
            _connection.Open();
            var cmd =new SqlCommand(sp,_connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (lp != null)
            {
                foreach (ParameterSP param in lp)
                {
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
                }
            }

            filasAfectadas = cmd.ExecuteNonQuery();
            _connection.Close();
            return filasAfectadas;
        }

        public bool ExecuteTransactionSp(Bills b)
        {
            _connection.Open();
            SqlTransaction t = _connection.BeginTransaction();

            var cmd =new SqlCommand("SP_SAVE_BILLS",_connection,t);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(@"id", b.N_Bill);
            cmd.Parameters.AddWithValue(@"date", b.Date_bill);
            cmd.Parameters.AddWithValue(@"client", b.Client);
            cmd.Parameters.AddWithValue(@"id_pm", b.Paym_meth);
            cmd.Parameters.AddWithValue(@"id_det", b.id_det);
            cmd.Parameters.AddWithValue(@"cancelled", b.Cancelled);

           int filasaf = cmd.ExecuteNonQuery();
            if (filasaf <= 0)
            {
                t.Rollback();
                return false;
            }

            else
            {
                foreach(BillDetails b1 in b.id_det)
                {
                    SqlCommand billdetail = new SqlCommand("SP_SAVE_BILLSDETAILS", _connection, t);
                    billdetail.CommandType = CommandType.StoredProcedure;
                    int codigo = 1;
                    billdetail.Parameters.AddWithValue(@"id_product", b1.Product);
                    billdetail.Parameters.AddWithValue(@"amount",b1.Amount);

                    int afectedrow = billdetail.ExecuteNonQuery();

                    if (afectedrow <= 0)
                    {
                        t.Rollback();
                        return false;
                    }

                }
                t.Commit();

                return true;

            }


        }
    }
}
