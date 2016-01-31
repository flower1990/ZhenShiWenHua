using HanHe.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HanHe.Manage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// 出错处理:写日志,导航到公共出错页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            //if (Server.GetLastError() == null) return;
            //Exception ex = Server.GetLastError().GetBaseException();
            //LogHelper.LogWriterFromFilter(ex);
            //this.Server.ClearError();
            //this.Response.Redirect("~/Error/Index");

        }
    }
}
