using Mvc5Ef6WebApiDataFirstNthW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc5Ef6WebApiDataFirstNthW.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private NORTHWNDEntities ctx = new NORTHWNDEntities();
       
        public IQueryable<Category> GetCategories()
        {
            ctx.Configuration.ProxyCreationEnabled = false;
            return ctx.Categories;
        }


        public Category GetCategoryById(int id)
        {
            ctx.Configuration.ProxyCreationEnabled = false;

            var category = ctx.Categories.FirstOrDefault((c) => c.CategoryID == id);

            if (category == null)
            {
                var resp = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return category;
        }

        public IEnumerable<Category> GetCategoryByName(string name)
        {
            return ctx.Categories
                .Where(c => c.CategoryName.Contains(name))
                .Select(c => c);
        } 
    }
}
