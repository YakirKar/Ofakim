using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Ofakim_Project.InterFaces;
using Ofakim_Project.Models;

namespace MvcDemo.Models
{
    public class UserDb: IDbConnections
    {
        DbConnection dbCon;
        public UserDb()
        {
            dbCon = CreateDbConnection();
        }
        public List<User> Get()
        {
            return dbCon.Get("select * from User_Table", typeof(User)).Cast<User>().ToList();
        }

        public int Add(User u1)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@FullName", u1.FullName));
            parms.Add(new SqlParameter("@Email", u1.Email));
            parms.Add(new SqlParameter("@BirthDay", u1.Birthday));
            parms.Add(new SqlParameter("@Gender", u1.Gender));
            parms.Add(new SqlParameter("@Phone", u1.Phone));
            return dbCon.DoQuery("AddUser", parms);
        }

        public DbConnection CreateDbConnection()
        {
            return new DbConnection();
        }
    }
}