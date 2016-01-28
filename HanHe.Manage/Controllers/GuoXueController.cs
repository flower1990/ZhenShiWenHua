using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.GuoXue;
using HanHe.Manage.Models.Helpers;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class GuoXueController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_GuoXue bMember = new BZs_GuoXue();

        public SelectList GetCategory01List(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "冬至"},
                new SelectListItem(){ Value = "1", Text = "小寒"},
                new SelectListItem(){ Value = "1", Text = "大寒"},
                new SelectListItem(){ Value = "1", Text = "立春"},
                new SelectListItem(){ Value = "1", Text = "雨水"},
                new SelectListItem(){ Value = "1", Text = "惊蛰"},
                new SelectListItem(){ Value = "1", Text = "春分"},
                new SelectListItem(){ Value = "1", Text = "清明"},
            };
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }

        /// <summary>
        /// 国学列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GuoXueList()
        {
            return View();
        }
        /// <summary>
        /// 国学列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bMember.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_GuoXue>(grid, query);

            //sorting
            query = query.OrderBy<Zs_GuoXue>(grid.SortColumn, grid.SortOrder);

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
                            GxID = item.GxID,
                            Keywords = item.Keywords,
                            GxTitle = item.GxTitle,
                            GxTitleShort = item.GxTitleShort,
                            GxInfo = item.GxInfo,
                            Category01 = item.Category01,
                            Category02 = item.Category02,
                            Category03 = item.Category03,
                            CreateDate = item.CreateDate,
                            UpdateDate = item.UpdateDate,
                            GxStatusName = item.GxStatusName,
                            PublishDate = item.PublishDate,
                            ViewCount = item.ViewCount,
                            GoodCount = item.GoodCount,

                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加国学
        /// </summary>
        /// <returns></returns>
        public ActionResult GuoXueCreate()
        {
            @ViewBag.Category01 = GetCategory01List(0);
            @ViewBag.Category02 = GetCategory01List(0);
            @ViewBag.Category03 = GetCategory01List(0);

            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult GuoXueCreate(GuoXueCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var item = new Zs_GuoXue();
            item = sysFun.InitialEntity<GuoXueCreate, Zs_GuoXue>(model, item);
            item.UpdateDate = DateTime.Now;
            item.PublishDate = DateTime.Now;
            item = bMember.Add(item);

            if (item.GxID > 0) return RedirectToAction("GuoXueList");

            return View(model);
        }
    }
}