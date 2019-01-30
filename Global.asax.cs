using MvcDemo.Models;
using Ofakim_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ofakim_Project
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //public static List<User> Users { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //In Case Db Connection Fail 
            //UserDb dbu = new UserDb();
            // Users = dbu.Get();
        }
    }
}
