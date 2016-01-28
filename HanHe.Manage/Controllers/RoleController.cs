using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Repositories;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class RoleController : Controller
    {
        IZs_Role bRole = new BZs_Role();

        public JsonResult GetRoleProperties()
        {
            var list = new RolePropertyRepository().RoleProperties();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList()
        {
            return View();
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bRole.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_Role>(grid, query);

            //sorting
            query = query.OrderBy<Zs_Role>(grid.SortColumn, grid.SortOrder);

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
                            RoleID = item.RoleID,
                            RoleCode = item.RoleCode,
                            RoleName = item.RoleName,
                            RoleProperty = item.RoleProperty,
                            Remark = item.Remark,
                            CreateDate = item.CreateDate
                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public string Create([Bind(Exclude = "RoleID")] Zs_Role role)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    bRole.Add(role);
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
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(Zs_Role role)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    //role.RoleProperty = role.RolePropertyName;

                    bRole.Update(role);
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
        [HttpPost]
        public string Delete(int id)
        {
            Zs_Role user = bRole.Find(id);
            bRole.Delete(user);
            return "Deleted successfully";
        }
    }
}