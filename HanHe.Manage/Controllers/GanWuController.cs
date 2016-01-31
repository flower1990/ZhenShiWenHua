using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.ChuanJia;
using HanHe.Manage.Models.GanWu;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Model;
using HanHe.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class GanWuController : Controller
    {
        IZs_GanWu bGanWu = new BZs_GanWu();

        /// <summary>
        /// 感悟未来列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GanWuList()
        {
            return View();
        }
        /// <summary>
        /// 感悟未来列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bGanWu.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_GanWu>(grid, query);

            //sorting
            query = query.OrderBy<Zs_GanWu>(grid.SortColumn, grid.SortOrder);

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
                            GwID = item.GwID,
                            MID = item.MID,
                            GwTitle = item.GwTitle,
                            GwTitleShort = item.GwTitleShort,
                            GwInfo = item.GwInfo,
                            GwType = item.GwType,
                            OpenStatus = item.OpenStatus,
                            GotoDate = item.GotoDate,
                            PostDate = item.PostDate,
                            GwStatus = item.GwStatus,
                            SmsStatus = item.SmsStatus,
                            //SortID = item.SortID,
                            CreateDate = item.CreateDate,
                            UpdateDate = item.UpdateDate,
                            ViewCount = item.ViewCount,
                            GoodCount = item.GoodCount,

                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult GanWuCreate()
        {
            @ViewBag.GwType = DicUtil.Instance.DicGwType(0);
            @ViewBag.OpenStatus = DicUtil.Instance.DicOpenStatus(0);
            @ViewBag.GwStatus = DicUtil.Instance.DicGwStatus(0);
            @ViewBag.SmsStatus = DicUtil.Instance.DicSmsStatus(0);

            var model = new GanWuCreate()
            {
                GotoDate = DateTime.Now,
                PostDate = DateTime.Now,
                SortID = 0,
            };

            return View(model);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult GanWuCreate(GanWuCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var item = new Zs_GanWu();
            item = SysFun.Instance.InitialEntity<GanWuCreate, Zs_GanWu>(model, item);
            item.UpdateDate = DateTime.Now;
            item = bGanWu.Add(item);

            if (item.GwID > 0) return RedirectToAction("GanWuList");

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult GanWuEdit(int id = 0)
        {
            var item = bGanWu.Find(id);
            var model = new GanWuEdit();
            model = SysFun.Instance.InitialEntity<Zs_GanWu, GanWuEdit>(item, model);

            @ViewBag.GwType = DicUtil.Instance.DicGwType(model.GwType);
            @ViewBag.OpenStatus = DicUtil.Instance.DicOpenStatus(model.OpenStatus);
            @ViewBag.GwStatus = DicUtil.Instance.DicGwStatus(model.GwStatus);
            @ViewBag.SmsStatus = DicUtil.Instance.DicSmsStatus(model.SmsStatus);

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult GanWuEdit(GanWuEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_GanWu item = bGanWu.Find(model.GwID);
            item = SysFun.Instance.InitialEntity<GanWuEdit, Zs_GanWu>(model, item);
            item.UpdateDate = DateTime.Now;
            var result = bGanWu.Update(item);

            if (result) return RedirectToAction("GanWuList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GanWuDelete(string id)
        {
            string[] arrId = id.Split(',');
            var result = bGanWu.Delete(f => arrId.Contains(f.GwID.ToString()));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}