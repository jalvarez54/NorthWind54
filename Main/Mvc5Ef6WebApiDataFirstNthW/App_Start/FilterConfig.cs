using System.Web;
using System.Web.Mvc;
using Mvc5Ef6WebApiDataFirstNthW.CustomFiltersAttributes;

namespace Mvc5Ef6WebApiDataFirstNthW
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyRequestLogFilter());
            //filters.Add(new MyAuthenticationAttribute());
        }
    }
}
