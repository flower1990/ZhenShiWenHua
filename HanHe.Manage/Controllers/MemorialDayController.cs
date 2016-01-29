using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.MemorialDay;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class MemorialDayController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_MemorialDay bMemorialDay = new BZs_MemorialDay();
        
        /// <summary>
        /// 交友圈列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MemorialDayList()
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
            var query = bMemorialDay.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_MemorialDay>(grid, query);
            
            //sorting
            query = query.OrderBy<Zs_MemorialDay>(grid.SortColumn, grid.SortOrder);

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
                            MDayID = item.MDayID,
                            MID = item.MID,
                            FMID = item.FMID,
                            FName = item.FName,
                            MDayTitle = item.MDayTitle,
                            MDate = item.MDate,
                            CalendarType = item.CalendarType,
                            MDateEn = item.MDateEn,
                            AdvanceDay = item.AdvanceDay,
                            RouseDate = item.RouseDate,
                            RouseSms = item.RouseSms,
                            RouseMusic = item.RouseMusic,
                            MDayMsg = item.MDayMsg,
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
        public ActionResult MemorialDayEdit(int id = 0)
        {
            var item = bMemorialDay.Find(id);
            var model = new MemorialDayEdit();
            model = sysFun.InitialEntity<Zs_MemorialDay, MemorialDayEdit>(item, model);

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemorialDayEdit(MemorialDayEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_MemorialDay item = bMemorialDay.Find(model.MDayID);
            item = sysFun.InitialEntity<MemorialDayEdit, Zs_MemorialDay>(model, item);
            var result = bMemorialDay.Update(item);

            if (result) return RedirectToAction("MemorialDayList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult MemorialDayDelete(int id)
        {
            string sql = "exec SP_DicDelete @DicID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DicID", id),
            };

            var result = bMemorialDay.Delete(sql, param);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}