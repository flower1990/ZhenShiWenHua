using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.ChuanJia;
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
    public class ChuanJiaController : Controller
    {
        IZs_ChuanJia bChuanJia = new BZs_ChuanJia();

        /// <summary>
        /// 行事历列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ChuanJiaList()
        {
            return View();
        }
        /// <summary>
        /// 行事历列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bChuanJia.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_ChuanJia>(grid, query);

            //sorting
            query = query.OrderBy<Zs_ChuanJia>(grid.SortColumn, grid.SortOrder);

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
                            CJID = item.CJID,
                            MID = item.MID,
                            TypeID = item.TypeID,
                            CJTitle = item.CJTitle,
                            CJTitleShort = item.CJTitleShort,
                            CJInfo = item.CJInfo,
                            OpenStatus = item.OpenStatus,
                            SortID = item.SortID,
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
        public ActionResult ChuanJiaCreate()
        {
            @ViewBag.TypeID = DicUtil.Instance.DicCJType(0);
            @ViewBag.OpenStatus = DicUtil.Instance.DicOpenStatus(0);

            var model = new ChuanJiaCreate() 
            {
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
        public ActionResult ChuanJiaCreate(ChuanJiaCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var item = new Zs_ChuanJia();
            item = SysFun.Instance.InitialEntity<ChuanJiaCreate, Zs_ChuanJia>(model, item);
            item.UpdateDate = DateTime.Now;
            item = bChuanJia.Add(item);

            if (item.CJID > 0) return RedirectToAction("ChuanJiaList");

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult ChuanJiaEdit(int id = 0)
        {
            var item = bChuanJia.Find(id);
            var model = new ChuanJiaEdit();
            model = SysFun.Instance.InitialEntity<Zs_ChuanJia, ChuanJiaEdit>(item, model);

            @ViewBag.TypeID = DicUtil.Instance.DicCJType(model.TypeID);
            @ViewBag.OpenStatus = DicUtil.Instance.DicOpenStatus(model.OpenStatus);

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
        public ActionResult ChuanJiaEdit(ChuanJiaEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_ChuanJia item = bChuanJia.Find(model.CJID);
            item = SysFun.Instance.InitialEntity<ChuanJiaEdit, Zs_ChuanJia>(model, item);
            item.UpdateDate = DateTime.Now;
            var result = bChuanJia.Update(item);

            if (result) return RedirectToAction("ChuanJiaList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult ChuanJiaDelete(string id)
        {
            string[] arrId = id.Split(',');
            var result = bChuanJia.Delete(f => arrId.Contains(f.CJID.ToString()));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}