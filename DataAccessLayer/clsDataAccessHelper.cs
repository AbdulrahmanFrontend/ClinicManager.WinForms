using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessHelper
    {
        protected static string _ConnectionString
        {
            get
            {
                return "Server=.;Database=ClinicDB;User Id=sa;Password=sa123456;TrustServerCertificate=True;";
            }
        }
        public static SqlConnection CreateConnection
        {
            get
            {
                return new SqlConnection(_ConnectionString);
            }
        }
        private static SqlCommand _PrepareComand(SqlConnection con, string query,
            Dictionary<string, object> parameters)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            if (parameters != null)
            {
                foreach(var p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }
            }
            return cmd;
        }
        private static SqlCommand _PrepareComand(SqlTransaction tran, string query,
            Dictionary<string, object> parameters)
        {
            SqlCommand cmd = new SqlCommand(query, tran.Connection, tran);
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }
            }
            return cmd;
        }
        protected static DataTable _GetDataTable(string query,
            Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand cmd = _PrepareComand(con, query, parameters))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError("GetDataTable Failed;", ex);
                    }
                }
            }
            return dt;
        }
        protected static DataRow _GetFirstRow(string query, 
            Dictionary<string, object> parameters = null)
        {
            DataTable dt = _GetDataTable(query, parameters);
            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }
        protected static object _GetScalar(string query, 
            Dictionary<string, object> parameters = null)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand cmd = _PrepareComand(con, query, parameters))
                {
                    try
                    {
                        con.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError($"GetScalar Failed;", ex);
                        return null;
                    }
                }
            }
        }
        protected static object _GetScalar(string query, SqlTransaction tran,
            SqlConnection con, Dictionary<string, object> parameters = null)
        {
            using (SqlCommand cmd =
                    _PrepareComand(tran, query, parameters))
            {
                try
                {
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Logger.LogError($"ExecuteScalar Failed;", ex);
                    throw;
                }
            }
        }
        protected static bool _ExecuteNonQuery(string query,
            Dictionary<string, object> parameters = null)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand cmd = _PrepareComand(con, query, parameters))
                {
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError($"ExecuteNonQuery Failed;", ex);
                        return false;
                    }
                }
            }
        }
        protected static bool _ExecuteNonQuery(string query, SqlTransaction tran,
            SqlConnection con, Dictionary<string, object> parameters = null)
        {
            using (SqlCommand cmd =
                    _PrepareComand(tran, query, parameters))
            {
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"ExecuteNonQuery Failed;", ex);
                    throw;
                }
            }
        }
    }
}
