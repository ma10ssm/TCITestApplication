using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TCIApplication.DAL;

namespace TCIApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer<TCIApplicationContext>(new TCIApplication.DAL.TCIApplicationInitializer());

            using (var db = new TCIApplicationContext())
            {
                db.Database.Initialize(false);
            }

           AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
