using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NepalTradeCenter.NepalTradeCenterServiceReference;

namespace NepalTradeCenter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // start dataInitializer
            //NepalTradeCenterServiceClient nepaltradecenterserviceclient = new NepalTradeCenterServiceClient();
            //nepaltradecenterserviceclient.RunDataInitializer();
            // end dataInititalizer
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
