using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5Ef6WebApiDataFirstNthW.Models
{
    public class MyErrorModel
    {
        public int HttpStatusCode { get; set; }
        public Exception Exception { get; set; }
    }
}