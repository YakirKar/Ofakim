using MvcDemo.Models;
using Ofakim_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ofakim_Project.Controllers
{
    public class UserController : ApiController
    {
        private UserDb dbu;
        public UserController()
        {
            dbu = new UserDb();
        }
        // GET api/User
        [HttpGet]
        public List<User> Get()
        {
            //need to create some security
            return dbu.Get();
        }


        //POST api/User/AddUser
        [HttpPost]
        public int AddUser(User user)
        {
            //need to create some security
            return dbu.Add(user);
        }

    
    }
}
