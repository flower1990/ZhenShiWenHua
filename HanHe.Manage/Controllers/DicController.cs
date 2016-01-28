using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Dic;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Repositories;
using HanHe.Manage.Models.Right;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class DicController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_Dic bDic = new BZs_Dic();

        /// <summary>
        /// 获取科目列表
        /// </summary>
        /// <returns></returns>
        public SelectList GetPropertyList(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "数据属性"},
                new SelectListItem(){ Value = "1", Text = "栏目属性"},                
            };
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        private int GetRowLevel(int parentID, List<Zs_Dic> cachedGridRows)
        {
            int level = 0;
            while (parentID != 0)
            {
                level++;
                var result = from item in cachedGridRows
                             where item.DicID == parentID
                             select item;

                parentID = result.Single().ParentID;
            }

            return level;
        }
        private bool IsLeafRow(int id, List<Zs_Dic> cachedGridRows)
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
                (from item in bDic.Entities
                 from joinProduct in bDic.Entities
                 where (item.DicID == joinProduct.ParentID)
                 where (item.DicID == id)
                 select item).Count();

            return childCount == 0;
        }
        /// <summary>
        /// 字典列表
        /// </summary>
        /// <returns></returns>
        public ActionResult DicList()
        {
            return View();
        }
        /// <summary>
        /// 字典列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            List<Zs_Dic> list = new List<Zs_Dic>();
            var cachedGridRows = bDic.Entities.OrderBy(f => f.lft).ToList();

            var hierarchyRows = from item in cachedGridRows
                                select new
                                {
                                    DicID = item.DicID,
                                    DicCode = item.DicCode,
                                    DicName = item.DicName,
                                    DicNameEn = item.DicNameEn,
                                    DicProperty = item.DicProperty,
                                    ParentID = item.ParentID,
                                    SortID = item.SortID,
                                    Remark = item.Remark,

                                    level = GetRowLevel(item.ParentID, cachedGridRows),
                                    isLeaf = IsLeafRow(item.DicID, cachedGridRows),
                                    parent = item.ParentID,
                                    expanded = true,
                                    loaded = true,
                                    lft = item.lft,
                                    rgt = item.rgt,
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
                                item.DicID.ToString(), 
                                item.DicCode,
                                item.DicName, 
                                item.DicNameEn, 
                                item.DicProperty, 
                                item.ParentID,
                                item.SortID, 
                                item.Remark,

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
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DicCreate()
        {
            @ViewBag.DicProperty = GetPropertyList(0);
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DicCreate(DicCreate model)
        {
            if (!ModelState.IsValid) { return View(model); }

            string sql = "exec SP_DicCreate @DicID,@DicCode,@DicName,@DicNameEn,@DicProperty,@ParentID,@SortID,@Remark,@isLeaf";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DicID", model.ParentID),
                new SqlParameter("@DicCode", model.DicCode),
                new SqlParameter("@DicName", model.DicName),
                new SqlParameter("@DicNameEn", model.DicNameEn),
                new SqlParameter("@DicProperty", model.DicProperty),
                new SqlParameter("@ParentID", model.ParentID),
                new SqlParameter("@SortID", model.SortID),
                new SqlParameter("@Remark", model.Remark),
                new SqlParameter("@isLeaf", true),
            };

            var result = bDic.Add(sql, param);
            if (result.DicID > 0) return RedirectToAction("DicList");
            else return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult DicEdit(int id = 0)
        {
            var item = bDic.Find(id);
            var model = new DicEdit();
            model = sysFun.InitialEntity<Zs_Dic, DicEdit>(item, model);

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DicEdit(DicEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_Dic item = bDic.Find(model.DicID);
            item = sysFun.InitialEntity<DicEdit, Zs_Dic>(model, item);
            var result = bDic.Update(item);

            if (result) return RedirectToAction("DicList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DicDelete(int id)
        {
            string sql = "exec SP_DicDelete @DicID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DicID", id),
            };

            var result = bDic.Delete(sql, param);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}