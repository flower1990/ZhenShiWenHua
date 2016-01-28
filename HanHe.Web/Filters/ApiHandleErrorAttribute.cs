using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HanHe.Util;

namespace HanHe.Web.Filters
{
    public class ApiHandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            LogHelper.LogWriterFromFilter(filterContext.Exception);
        }
    }
}