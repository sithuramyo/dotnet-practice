using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.Services
{
    public class ADONetService
    {
        public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public ADONetService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }

        private string GetConnection()
        {
            return _sqlConnectionStringBuilder.ConnectionString;
        }

        public int Excute(string Query)
        {
            SqlConnection dbConnection = new SqlConnection(GetConnection());
            dbConnection.Open();

            SqlCommand cmd = new SqlCommand(Query,dbConnection);
            cmd.CommandType = CommandType.Text;
            int result = cmd.ExecuteNonQuery();
           
            dbConnection.Close();
            return result;
        }

        public DataTable Query(string Query)
        {
            SqlConnection dbConnection = new SqlConnection(GetConnection());
            dbConnection.Open();

            SqlCommand cmd = new SqlCommand(Query,dbConnection);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            dbConnection.Close();
            return dt;
        }
    }
}
