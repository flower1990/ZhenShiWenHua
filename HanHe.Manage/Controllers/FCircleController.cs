using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.FCircle;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class FCircleController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_FCircle bFCircle = new BZs_FCircle();
        
        /// <summary>
        /// 交友圈列表
        /// </summary>
        /// <returns></returns>
        public ActionResult FCircleList()
        {
            return View();
        }
        /// <summary>
        /// 交友圈列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bFCircle.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_FCircle>(grid, query);
            
            //sorting
            query = query.OrderBy<Zs_FCircle>(grid.SortColumn, grid.SortOrder);

            //count
            var count = query.Count();

            //paging
            var data = query.Skip((grid.PageIndex - 1) * grid.PageSize).Take(grid.PageSize).ToArray();

            //converting in grid format
            var result = new
            {
                total = (int)Math.Ceiling((double)count / grid.PageSize),
                page = grid.PageIndex,
                records = count,
                rows = (from item in data
                        select new
                        {
                            FCID = item.FCID,
                            MID = item.MID,
                            FCTitle = item.FCTitle,
                            FCInfo = item.FCInfo,
                            FCUrl = item.FCUrl,
                            ViewCount = item.ViewCount,
                            GoodCount = item.GoodCount,
                            CreateDate = item.CreateDate,

                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult FCircleEdit(int id = 0)
        {
            var item = bFCircle.Find(id);
            var model = new FCircleEdit();
            model = sysFun.InitialEntity<Zs_FCircle, FCircleEdit>(item, model);

            //@ViewBag.Category01 = GetCategory01List(0);
            //@ViewBag.Category02 = GetCategory01List(0);
            //@ViewBag.Category03 = GetCategory01List(0);
            //@ViewBag.GxStatus = GetGxStatusList(1);

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FCircleEdit(FCircleEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_FCircle item = bFCircle.Find(model.FCID);
            item = sysFun.InitialEntity<FCircleEdit, Zs_FCircle>(model, item);
            var result = bFCircle.Update(item);

            if (result) return RedirectToAction("FCircleList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult FCircleDelete(int id)
        {
            string sql = "exec SP_DicDelete @DicID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DicID", id),
            };

            var result = bFCircle.Delete(sql, param);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}