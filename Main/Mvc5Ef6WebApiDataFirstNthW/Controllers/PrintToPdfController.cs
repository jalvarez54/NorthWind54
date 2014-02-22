using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Ef6WebApiDataFirstNthW.Controllers
{
    public class PrintToPdfController : Controller
    {
        [ValidateInput(false)]
        public ActionResult Index(string action,string controller)
        {
            return new Rotativa.ActionAsPdf(
                           action,controller)
                           {
                               FileName = "Products.pdf",
                               CustomSwitches = "--print-media-type",
                               PageOrientation = Rotativa.Options.Orientation.Landscape
                           };
        }
    }
}