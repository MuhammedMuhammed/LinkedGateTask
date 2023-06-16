using DataManager;
using DataManager.Seeders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LinkedGateTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            CultureInfo.DefaultThreadCurrentCulture =culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            new PropertiesSeeder();
            new CategoriesSeeder();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //Log your exception here
            Response.Clear();
            // clear error on server
            Server.ClearError();

            Response.Redirect("~/Devices/Index");

        }
    }
}
