using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Mvc5Ef6WebApiDataFirstNthW.WebApi.Controllers
{
    public class VersionController : ApiController
    {
        public Version GetVersion()
        {
            System.Reflection.Assembly _Assembly = HttpContext.Current.ApplicationInstance.GetType().BaseType.Assembly;
            Version ApplicationVersion = _Assembly.GetName().Version;
            return ApplicationVersion;
        }
    }
}
