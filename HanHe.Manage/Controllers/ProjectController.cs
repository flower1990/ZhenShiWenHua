﻿using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Project;
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
    public class ProjectController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_Project bProject = new BZs_Project();

        /// <summary>
        /// 行事历列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectList()
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
            var query = bProject.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_Project>(grid, query);

            //sorting
            query = query.OrderBy<Zs_Project>(grid.SortColumn, grid.SortOrder);

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
                            ProjectID = item.ProjectID,
                            MID = item.MID,
                            ProTitle = item.ProTitle,
                            ProTitleShort = item.ProTitleShort,
                            ProInfo = item.ProInfo,
                            ImpropantWeight = item.ImpropantWeight,
                            UrgentWeight = item.UrgentWeight,
                            SortID = item.SortID,
                            StartDate = item.StartDate,
                            ExpectDate = item.ExpectDate,
                            ProStatus = item.ProStatus,
                            FinishedDate = item.FinishedDate,
                            ProgressNum = item.ProgressNum,
                            OpenStatus = item.OpenStatus,
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
        public ActionResult ProjectCreate()
        {
            ProjectCreate model = new ProjectCreate();
            model.SortID = 0;
            model.ProgressNum = 0;
            model.StartDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            model.ExpectDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            @ViewBag.ImpropantWeight = DicUtil.Instance.DicImpropantWeight(0);
            @ViewBag.UrgentWeight = DicUtil.Instance.DicUrgentWeight(0);
            @ViewBag.OpenStatus = DicUtil.Instance.DicOpenStatus(0);
            @ViewBag.ProStatus = DicUtil.Instance.DicProStatus(0);

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
        public ActionResult ProjectCreate(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var item = new Zs_Project();
            item = sysFun.InitialEntity<ProjectCreate, Zs_Project>(model, item);
            item.UpdateDate = DateTime.Now;
            item.FinishedDate = DateTime.Now;
            item = bProject.Add(item);

            if (item.ProjectID > 0) return RedirectToAction("ProjectList");

            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectEdit(int id = 0)
        {
            var item = bProject.Find(id);
            var model = new ProjectEdit();
            model = sysFun.InitialEntity<Zs_Project, ProjectEdit>(item, model);

            @ViewBag.ImpropantWeight = DicUtil.Instance.DicImpropantWeight(model.ImpropantWeight);
            @ViewBag.UrgentWeight = DicUtil.Instance.DicUrgentWeight(model.UrgentWeight);
            @ViewBag.OpenStatus = DicUtil.Instance.DicOpenStatus(model.OpenStatus);
            @ViewBag.ProStatus = DicUtil.Instance.DicProStatus(model.ProStatus);

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
        public ActionResult ProjectEdit(ProjectEdit model)
        {
            if (!ModelState.IsValid) { return View(model); }

            Zs_Project item = bProject.Find(model.ProjectID);
            item = sysFun.InitialEntity<ProjectEdit, Zs_Project>(model, item);
            item.UpdateDate = DateTime.Now;
            var result = bProject.Update(item);

            if (result) return RedirectToAction("ProjectList");
            else return View(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult ProjectDelete(string id)
        {
            string[] arrId = id.Split(',');
            var result = bProject.Delete(f => arrId.Contains(f.ProjectID.ToString()));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}