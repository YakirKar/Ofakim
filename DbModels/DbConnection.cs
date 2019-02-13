using System;
using System.Collections;
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
using Ofakim_Project.InterFaces;

namespace Ofakim_Project.Models
{
    public class DbConnection : IDisposable
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
      

      
        public IEnumerable Get(string sqlText, Type Objecttype, CommandType type = CommandType.Text)
        {
            DataTable dt = new DataTable();
            SqlDataReader sdr = GetCommand(sqlText, type).ExecuteReader();
            dt.Load(sdr);
            //Or
            //SqlDataAdapter adpter = new SqlDataAdapter(sql, GetCon());
            //adpter.Fill(dt);
            Dispose();

            var rows = FillFromDb(dt);
            return FillObject(Objecttype, rows);

        }

        IEnumerable FillObject(Type type, List<Dictionary<string, object>> rows)
        {
        
            List<object> OjectList = new List<object>();
            foreach (var row in rows)
            {
				    var instance = Activator.CreateInstance(type);
                OjectList.Add(((IDbFiller)instance).FillRows(row));
            }
            return (IEnumerable)OjectList;
        }

        SqlCommand GetCommand(string sqlText,CommandType type)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = type;
            cmd.Connection = GetCon();
            cmd.CommandText = sqlText;
            return cmd;
        }








        public List<Dictionary<string, object>> FillFromDb(DataTable dt)
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
            return rows;
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

        public void Dispose()
        {
            CloseCon();
        }
    }
}