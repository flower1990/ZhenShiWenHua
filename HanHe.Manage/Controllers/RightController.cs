using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Repositories;
using HanHe.Manage.Models.Right;
using HanHe.Model;
using HanHe.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class RightController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_User bUser = new BZs_User();
        IZs_Role bRole = new BZs_Role();
        IZs_Right bRight = new BZs_Right();

        private int GetRowLevel(int parentID, List<Zs_Right> cachedGridRows)
        {
            int level = 0;
            while (parentID != 0)
            {
                level++;
                var result = from item in cachedGridRows
                             where item.RightID == parentID
                             select item;

                parentID = result.Single().ParentID;
            }

            return level;
        }
        private bool IsLeafRow(int id, List<Zs_Right> cachedGridRows)
        {
            foreach (var retailData in cachedGridRows)
            {
                if (retailData.ParentID == id)
                {
                    return false;
                }
            }

            return true;
        }
        private bool IsLeafRow(int id)
        {
            int childCount =
                (from item in bRight.Entities
                 from joinProduct in bRight.Entities
                 where (item.RightID == joinProduct.ParentID)
                 where (item.RightID == id)
                 select item).Count();
            
            return childCount == 0;
        }
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RightList()
        {
            return View();
        }
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            List<Zs_Right> list = new List<Zs_Right>();
            var cachedGridRows = bRight.Entities.OrderBy(f => f.lft).ToList();

            var hierarchyRows = from item in cachedGridRows
                                select new
                                {
                                    RightID = item.RightID,
                                    RightCode = item.RightCode,
                                    RightName = item.RightName,
                                    ControllerName = item.ControllerName,
                                    ActionName = item.ActionName,
                                    ParentID = item.ParentID,
                                    SortID = item.SortID,
                                    RightProperty = item.RightProperty,
                                    Remark = item.Remark,
                                    CreateDate = item.CreateDate,

                                    lft = item.lft,
                                    rgt = item.rgt,
                                    level = GetRowLevel(item.ParentID, cachedGridRows),
                                    isLeaf = IsLeafRow(item.RightID, cachedGridRows),
                                    parent = item.ParentID,
                                    expanded = true,
                                    loaded = true,
                                };

            //converting in grid format
            var result = new
            {
                total = 1,
                page = 1,
                records = 1,
                rows = (from item in hierarchyRows
                        select new
                        {
                            cell = new object[]
                            { 
                                item.RightID, 
                                item.RightCode,
                                item.RightName, 
                                item.ControllerName, 
                                item.ActionName, 
                                item.ParentID,
                                item.SortID, 
                                item.RightProperty,
                                item.Remark,
                                item.CreateDate,

                                item.level,
                                item.isLeaf,
                                item.parent,
                                item.expanded,
                                item.loaded,
                                item.lft,
                                item.rgt,
                            }
                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(hierarchyRows, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <returns></returns>
        public ActionResult RightCreateChildNode()
        {
            var model = new RightCreateChildNode();
            model.SortID = 0;

            @ViewBag.RightProperty = DicUtil.Instance.RightProperties(0);

            return View(model);
        }
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RightCreateChildNode(RightCreateChildNode model)
        {
            if (!ModelState.IsValid) { return View(model); }

            string sql = "exec SP_RightCreate @RightID,@RightCode,@RightName,@ControllerName,@ActionName,@ParentID,@SortID,@RightProperty,@Remark,@isLeaf";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@RightID", model.ParentID),
                new SqlParameter("@RightCode", model.RightCode),
                new SqlParameter("@RightName", model.RightName),
                new SqlParameter("@ControllerName", model.ControllerName),
                new SqlParameter("@ActionName", model.ActionName),
                new SqlParameter("@ParentID", model.ParentID),
                new SqlParameter("@SortID", model.SortID),
                new SqlParameter("@RightProperty", model.RightProperty),
                new SqlParameter("@Remark", model.Remark),
                new SqlParameter("@isLeaf", true),
            };

            var result = bRight.Add(sql, param);
            if (result.RightID > 0) return RedirectToAction("RightList");
            else return View(model);
        }
        /// <summary>
        /// 添加跟节点
        /// </summary>
        /// <returns></returns>
        public ActionResult RightCreateRootNode()
        {
            var model = new RightCreateRootNode();
            model.SortID = 0;

            @ViewBag.RightProperty = DicUtil.Instance.RightProperties(0);

            return View(model);
        }
        /// <summary>
        /// 添加跟节点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RightCreateRootNode(RightCreateRootNode model)
        {
            if (!ModelState.IsValid) { return View(model); }

            string sql = "exec SP_RightCreate @RightID,@RightCode,@RightName,@ControllerName,@ActionName,@ParentID,@SortID,@RightProperty,@Remark,@isLeaf";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@RightID", model.ParentID),
                new SqlParameter("@RightCode", model.RightCode),
                new SqlParameter("@RightName", model.RightName),
                new SqlParameter("@ControllerName", model.ControllerName),
                new SqlParameter("@ActionName", model.ActionName),
                new SqlParameter("@ParentID", model.ParentID),
                new SqlParameter("@SortID", model.SortID),
                new SqlParameter("@RightProperty", model.RightProperty),
                new SqlParameter("@Remark", model.Remark),
                new SqlParameter("@isLeaf", false),
            };

            var result = bRight.Add(sql, param);
            if (result.RightID > 0) return RedirectToAction("RightList");
            else return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult RightEdit(int id = 0)
        {
            var item = bRight.Find(id);
            var model = new RightEdit();
            model = sysFun.InitialEntity<Zs_Right, RightEdit>(item, model);
            
            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RightEdit(RightEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_Right item = bRight.Find(model.RightID);
            item = sysFun.InitialEntity<RightEdit, Zs_Right>(model, item);
            var result = bRight.Update(item);
            
            if (result) return RedirectToAction("RightList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult RightDelete(int id)
        {
            string sql = "exec SP_RightDelete @RightID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@RightID", id),
            };

            var result = bRight.Delete(sql, param);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}