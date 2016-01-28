using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Http.Filters;
using HanHe.Web.Filters;

namespace HanHe.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
