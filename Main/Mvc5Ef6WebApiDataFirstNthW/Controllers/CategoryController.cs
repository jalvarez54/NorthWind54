using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc5Ef6WebApiDataFirstNthW.Models;

namespace Mvc5Ef6WebApiDataFirstNthW.Controllers
{
    public class CategoryController : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult IndexToPdf()
        {
            return new Rotativa.ActionAsPdf(
                           "Index")
                           {
                               FileName = "Categories.pdf",
                               CustomSwitches = "--print-media-type",
                               PageOrientation = Rotativa.Options.Orientation.Landscape
                           };
        }
        public ActionResult PrintIndex()
        {
            return new Rotativa.ActionAsPdf(
                           "Index") { FileName = "Categories.pdf" };
        }

        // GET: /Category/
        [OutputCache(Duration=30)]
        public async Task<ActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
        }

        // GET: /Category/
        [OutputCache(Duration = 30)]
        public async Task<ActionResult> TrunckedCategories()
        {
            //return View(await db.Categories.ToListAsync());

            var model = await (from b in db.Categories
                               orderby b.CategoryName
                               select new CategoryViewModel { 
                                   CategoryName = b.CategoryName, 
                                   Description = b.Description 
                               }).ToListAsync();
           
            return View(model);
        }

        // GET: /Category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
