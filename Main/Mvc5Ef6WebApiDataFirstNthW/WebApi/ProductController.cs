using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Mvc5Ef6WebApiDataFirstNthW.Models;

namespace Mvc5Ef6WebApiDataFirstNthW.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        // GET api/Product
        //[ActionName("GetTruncProducts")]
        //public IEnumerable<ProductsWebApiViewModel.Product> GetTruncProducts()
        //{
        //    var product = from e in db.Products
        //                  select new ProductsWebApiViewModel.Product
        //                  {
        //                      ProductName = e.ProductName,
        //                      QuantityPerUnit = e.QuantityPerUnit,
        //                      UnitPrice = e.UnitPrice.Value,
        //                      UnitsInStock = e.UnitsInStock.Value,
        //                      UnitsOnOrder = e.UnitsOnOrder.Value,
        //                      Discontinued = e.Discontinued,
        //                      ReorderLevel = e.ReorderLevel.Value
        //                  };
        //    return product.ToList();
        //}
        // GET api/Product
        public IQueryable<Product> GetProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Products;
        }

        // GET api/Product/5
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> GetProduct(int id)
        //{
        //    Product product = await db.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}
        public Product GetProductById(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var product = db.Products.FirstOrDefault((c) => c.ProductID == id);

            if (product == null)
            {
                var resp = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return product;
        }


        // PUT api/Product/5
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Product
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE api/Product/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}