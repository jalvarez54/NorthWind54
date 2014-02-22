using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mvc5Ef6WebApiDataFirstNthW.Controllers;
using log4net;
using log4net.Config;

namespace Mvc5Ef6WebApiDataFirstNthW
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType(),
                  null, null, "Entering application.", null);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public void Application_BeginRequest()
        {
            // Application code for each request could go here.
        }
        public void Application_OnEnd()
        {
            // Application clean-up code goes here.
            Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType(),
                  null, null, "Exiting application.", null);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //additional actions...
        }
    }
}
