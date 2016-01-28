using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Keyword;
using HanHe.Manage.Models.Repositories;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class KeywordsController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_Keywords bKeywords = new BZs_Keywords();

        /// <summary>
        /// 关键词列表
        /// </summary>
        /// <returns></returns>
        public ActionResult KeywordsList()
        {
            return View();
        }
        /// <summary>
        /// 关键词列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bKeywords.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_Keywords>(grid, query);

            //sorting
            query = query.OrderBy<Zs_Keywords>(grid.SortColumn, grid.SortOrder);

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
                            KwID = item.KwID,
                            ZsKeyWords = item.ZsKeyWords,
                            WeightNum = item.WeightNum,
                            KwStatus = item.KwStatus
                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string Create(KeywordCreate model)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Zs_Keywords item = new Zs_Keywords();
                    item = sysFun.InitialEntity<KeywordCreate, Zs_Keywords>(model, item);
                    bKeywords.Add(item);
                    
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(KeywordEdit model)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Zs_Keywords item = bKeywords.Find(model.KwID);

                    item = sysFun.InitialEntity<KeywordEdit, Zs_Keywords>(model, item);
                    bKeywords.Update(item);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            Zs_Keywords item = bKeywords.Find(id);
            bKeywords.Delete(item);
            return "Deleted successfully";
        }
    }
}