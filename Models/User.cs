using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ofakim_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public GenderEnum Gender { get; set; }
    }
    public enum GenderEnum
    {
        Male = 0,
        Female = 1,
    }
}