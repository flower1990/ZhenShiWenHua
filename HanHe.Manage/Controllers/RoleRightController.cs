using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class RoleRightController : Controller
    {
        IZs_Role bRole = new BZs_Role();
        IZs_Right bRight = new BZs_Right();

        /// <summary>
        /// 角色权限分配
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleRightCreate()
        {
            return View();
        }
        public JsonResult TreeDataAPI(string parent)
        {
            int parentId = 0;
            List<Zs_Right> list = new List<Zs_Right>();
            List<Dictionary<string, object>> listDict = new List<Dictionary<string, object>>();

            if (parent == "#") parentId = 0; else parentId = int.Parse(parent);

            list = bRight.Entities.Where(f => f.ParentID == parentId).ToList();
            foreach (var item in list)
            {
                if (item.ParentID == parentId)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict.Add("id", item.RightID);
                    dict.Add("icon", "");
                    dict.Add("text", item.RightName);

                    if (list.Where(d => d.ParentID == parentId).Count() > 0)
                        dict.Add("children", true);
                    else
                        dict.Add("children", false);
                    listDict.Add(dict);
                }
            }
            return Json(listDict, JsonRequestBehavior.AllowGet);
        }
	}
}