using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Ef6WebApiDataFirstNthW.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Administration/Home/
        [Authorize(Users="admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}