using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc5Ef6WebApiDataFirstNthW.Models;
using PagedList;
using Mvc5Ef6WebApiDataFirstNthW.CustomFiltersAttributes;

namespace Mvc5Ef6WebApiDataFirstNthW.Controllers
{
    //[MyAuthenticationAttribute]
    public class ProductController : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult IndexToPdf()
        {
            return new Rotativa.ActionAsPdf(
                           "Index") {
                               FileName = "Products.pdf",
                               CustomSwitches = "--print-media-type",
                               PageOrientation = Rotativa.Options.Orientation.Landscape
                           };
        }
        public ActionResult PrintIndex(int? pageToPdf)
        {
            return new Rotativa.ActionAsPdf(
                           "Index",
                           new { page = pageToPdf })
            {
                FileName = "Products.pdf",
                CustomSwitches = "--print-media-type",
                PageOrientation = Rotativa.Options.Orientation.Landscape
            };
        }
        public ActionResult PrintIndexAsPdf()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).OrderBy(s => s.ProductName);
            var pp = new Rotativa.ViewAsPdf(products);
            pp.CustomSwitches = "--print-media-type";
            pp.PageOrientation = Rotativa.Options.Orientation.Landscape;
            return pp;
        }
        public ActionResult PrintIndexAsPdfPageList(int? page)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).OrderBy(s => s.ProductName);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var productsPaged = products.ToPagedList(pageNumber, pageSize);
            var pp = new Rotativa.ViewAsPdf(productsPaged);
            pp.CustomSwitches = "--print-media-type";
            pp.PageOrientation = Rotativa.Options.Orientation.Landscape;           
            return pp;
        }
        // GET: /Product/
        public ViewResult Index()
        {
            //Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType().ToString(),
            //    System.Reflection.MethodBase.GetCurrentMethod().Name, "Test tracage classique", null);
            //var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            //return View(products.ToList());
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).OrderBy(s => s.ProductName);
            return View(products);

        }

        // GET: /Product/
        public ViewResult SortedProducts(int? page)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).OrderBy(s => s.ProductName);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // BUG: Don't retreive custom error with http://www.jow-alva.net/NorthWind/Product/Details/150, where 150 don't exist. Correction
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new HttpException(404, string.Format("Product id cannot be null"));
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                // BUG: Don't retreive custom error with http://www.jow-alva.net/NorthWind/Product/Details/150, where 150 don't exist. Correction
                //return HttpNotFound();
                throw new HttpException(404, string.Format("Product for id {0} was not found", id));
            }
            return View(product);
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
