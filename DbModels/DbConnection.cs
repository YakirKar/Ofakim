using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using MvcDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ofakim_Project.Models
{
    public class DbConnection
    {
        protected SqlConnection Con { get; private set; }

        public DbConnection()
        {
            if (IsServerConnected(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString))
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            else
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr2"].ConnectionString);
        }

        public SqlConnection GetCon()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            return Con;
        }

        private void CloseCon()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
        }

        public int DoQuery(string sql,List<SqlParameter> parms)
        {
            SqlCommand cmd = new SqlCommand(sql, GetCon());
            if(parms != null)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parms.ToArray());
            }
            int rowsaffected = -1;
            try
            {
                rowsaffected = cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                return -1;
            }
            
            CloseCon();
            return rowsaffected;
        }
      

      
        public string Get(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetCon());
            SqlDataReader sdr;
            DataTable dt = new DataTable();
            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            var str = FillFromDb(dt);
            CloseCon();
            return str;
        }


     
        

     


        public string FillFromDb(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);
        }

        private  bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }











    }
}