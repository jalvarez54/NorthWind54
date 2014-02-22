using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Ef6WebApiDataFirstNthW.Controllers
{

    public class WebApiClientController : Controller
    {
        /// <summary>
        /// GET: /WebApiClientViewCategoriesJQuery/
        /// The view retreive data using JQuery/Ajax
        /// </summary>
        /// <returns></returns>
        public ActionResult WebApiClientViewCategoriesJQuery()
        {
            return View();
        }
        /// <summary>
        /// GET: /WebApiClientViewProductsJQuery/
        /// The view retreive data using JQuery/Ajax
        /// </summary>
        /// <returns></returns>
        public ActionResult WebApiClientViewProductsJQuery()
        {
            return View();
        }
        /// <summary>
        /// GET: /WebApiClientViewCategoriess/
        /// C# code in the controller to retreive data from WebApi server.
        /// </summary>
        /// <returns></returns>
        public ActionResult WebApiClientViewCategories()
        {
            IEnumerable<Mvc5Ef6WebApiDataFirstNthW.Models.CategoriesWebApiViewModel.Category> categories = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + Request.Url.Authority + "/NorthWind/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // List all products.
            HttpResponseMessage response = client.GetAsync("api/Category").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    categories = response.Content.ReadAsAsync<IEnumerable<Mvc5Ef6WebApiDataFirstNthW.Models.CategoriesWebApiViewModel.Category>>().Result;
                }
                catch (Exception ex)
                {
                    Helpers.Utils.SignalExceptionToElmahAndTrace(ex, this);
                    return RedirectToAction("HandledFatalException", "MyError", new { area = "" });
                }
            }
            return View(categories);
        }
        /// <summary>
        /// GET: /WebApiClientViewProducts/
        /// C# code in the controller to retreive data from WebApi server.
        /// </summary>
        /// <returns></returns>
        public ActionResult WebApiClientViewProducts()
        {
            IEnumerable<Mvc5Ef6WebApiDataFirstNthW.Models.ProductsWebApiViewModel.Product> products = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + Request.Url.Authority + "/NorthWind/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // List all products.
            HttpResponseMessage response = client.GetAsync("api/Product").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    products = response.Content.ReadAsAsync<IEnumerable<Mvc5Ef6WebApiDataFirstNthW.Models.ProductsWebApiViewModel.Product>>().Result;
                }
                catch (Exception ex)
                {
                    Helpers.Utils.SignalExceptionToElmahAndTrace(ex, this);
                    return RedirectToAction("HandledFatalException", "MyError", new { area = "" });
                }
            }
            return View(products);
        }
    }
}