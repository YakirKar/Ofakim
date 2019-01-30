using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Ofakim_Project.Models;

namespace MvcDemo.Models
{
    public class UserDb
    {
        DbConnection dbCon = new DbConnection();
        public List<User> Get()
        {
            return JsonConvert.DeserializeObject <List<User>>(dbCon.Get("select * from User_Table"));
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

    
    }
}