using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Ef6WebApiDataFirstNthW.CustomFiltersAttributes;

namespace Mvc5Ef6WebApiDataFirstNthW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          //Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType().ToString(),
          //      System.Reflection.MethodBase.GetCurrentMethod().Name, "Test tracage classique", null);
            return View();
        }
        public ActionResult About()
        {
            //Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType().ToString(),
            //      System.Reflection.MethodBase.GetCurrentMethod().Name, "Test tracage classique", null);
            ViewBag.Message = "Project Description.";
           return View();
        }
        public ActionResult Contact()
        {
            //Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType().ToString(),
            //      System.Reflection.MethodBase.GetCurrentMethod().Name, "Test tracage classique", null);
            ViewBag.Message = "About us.";
            return View();
        }
        public ActionResult Video()
        {
            ViewBag.Message = "HTML 5 Videos";
            return View();
        }

        #region Test actions
                public ActionResult Carousel()
        {
            return View();
        }
 
    #endregion    
    }
}