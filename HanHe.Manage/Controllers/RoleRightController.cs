using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class RoleRightController : Controller
    {
        /// <summary>
        /// 角色权限分配
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleRightCreate()
        {
            return View();
        }
	}
}