using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5Ef6WebApiDataFirstNthW.Models
{
    public class CategoriesWebApiViewModel
    {
        public partial class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public byte[] Picture { get; set; }
        }
    }
}