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
        //public ActionResult Index()
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
        //public ActionResult Index()
        public ViewResult SortedProducts(int? page)
        {
            //Helpers.MyTracer.MyTrace(System.Diagnostics.TraceLevel.Info, this.GetType().ToString(),
            //    System.Reflection.MethodBase.GetCurrentMethod().Name, "Test tracage classique", null);
            //var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            //return View(products.ToList());
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // GET: /Product/Create
        //[AuthorizationAttribute]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        // POST: /Product/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // POST: /Product/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
