using Ofakim_Project.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ofakim_Project.Models
{
    public class User:IDbFiller
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public GenderEnum Gender { get; set; }

        public object FillRows(Dictionary<string, object> row)
        {
            this.Id = Convert.ToInt32(row["Id"]);
            this.Email = row["Email"].ToString();
            this.FullName = row["FullName"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Birthday = Convert.ToDateTime(row["BirthDay"]);
            this.Gender = (GenderEnum)Convert.ToInt32(row["Gender"]);
            return this;
        }
    }
    public enum GenderEnum
    {
        Male = 0,
        Female = 1,
    }
}