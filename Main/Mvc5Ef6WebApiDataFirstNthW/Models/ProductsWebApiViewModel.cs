using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5Ef6WebApiDataFirstNthW.Models
{
    public class ProductsWebApiViewModel
    {
        public class Product
        {
            public string ProductName { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public Int16 UnitsInStock { get; set; }
            public Int16 UnitsOnOrder { get; set; }
            public bool Discontinued { get; set; }
            public Int16 ReorderLevel { get; set; }
        }
    }
}