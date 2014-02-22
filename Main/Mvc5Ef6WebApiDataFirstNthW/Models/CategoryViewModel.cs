using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5Ef6WebApiDataFirstNthW.Models
{
    public class CategoryViewModel
    {
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}