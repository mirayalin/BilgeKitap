using Kitap.BLL.SingletonPattern;
using Kitap.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        MyDBContext db = DBTool.DBInstance;
        protected void Application_Start()
        {
            db.AppUsers.ToList();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
