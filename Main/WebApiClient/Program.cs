using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleWebApiClient
{
    class Program
    {

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public Int16 UnitsInStock { get; set; }
            public Int16 UnitsOnOrder { get; set; }
            public bool Discontinued { get; set; }
            public Int16 ReorderLevel { get; set; }
        }

        static void Main(string[] args)
        {
            IEnumerable<Product> products = GetProducts();
            PrintUnitsInStock(products);
            Console.ReadLine();
            PrintProducts(products);
            Console.ReadLine();
        }
        private static IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["adressWebApiServer"].ToString());

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // List all products.
            HttpResponseMessage response = client.GetAsync("api/Product").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return products;
        }
        private static void PrintUnitsInStock(IEnumerable<Product> products)
        {
            foreach (Product item in products)
            {
                Console.Write("Name={0} ; UnitsInStock={1}\r\n", item.ProductName, item.UnitsInStock);
            }
        }
        private static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (Product item in products)
            {
                string toPrint = string.Format(
                    "ProductID={0} ProductName={1} SupplierID={2} CategoryID={3} QuantityPerUnit={4} UnitPrice={5} UnitsInStock={6} UnitsOnOrder={7} Discontinued={8} ReorderLevel={9}\r\n\r\n",
                     item.ProductID, item.ProductName, item.SupplierID, item.CategoryID, item.QuantityPerUnit, item.UnitPrice, item.UnitsInStock, item.UnitsOnOrder, item.Discontinued, item.ReorderLevel);
                Console.Write(toPrint);
            }
        }
    }
}
