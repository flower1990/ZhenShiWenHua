using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Member;
using HanHe.Manage.Models.Repositories;
using HanHe.Model;
using HanHe.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class MemberController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_Member bMember = new BZs_Member();

        /// <summary>
        /// 会员列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberList()
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
            var query = bMember.Entities;

            //filtring
            query = GridFilter.Filtring<Zs_Member>(grid, query);

            //sorting
            query = query.OrderBy<Zs_Member>(grid.SortColumn, grid.SortOrder);

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
                            MID = item.MID,
                            MCode = item.MCode,
                            MName = item.MName,
                            NickName = item.NickName,
                            Pwd = item.Pwd,
                            Sex = item.Sex,
                            IDType = item.IDType,
                            IDCode = item.IDCode,
                            BirthdayCn = item.BirthdayCn,
                            BirthdayEn = item.BirthdayEn,
                            CalendarType = item.CalendarType,
                            MyLife = item.MyLife,
                            Mobile = item.Mobile,
                            Email = item.Email,
                            QQ = item.QQ,
                            WeiXin = item.WeiXin,
                            Sina = item.Sina,
                            Address = item.Address,
                            PostCode = item.PostCode,
                            CountryID = item.CountryID,
                            ProvinceID = item.ProvinceID,
                            CityID = item.CityID,
                            AreaID = item.AreaID,
                            IconUrl = item.IconUrl,
                            MySign = item.MySign,
                            Remark = item.Remark,
                            CreateDate = item.CreateDate,
                            UpdateDate = item.UpdateDate,
                            MStatus = item.MStatus,
                            ActDate = item.ActDate,
                            DelStatus = item.DelStatus,
                            DelDate = item.DelDate

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
        public string Create(MemberCreate model)
        {
            string msg;

            if (ModelState.IsValid)
            {
                Zs_Member item = new Zs_Member();
                item = sysFun.InitialEntity<MemberCreate, Zs_Member>(model, item);
                item.MChar = StringUtil.GetGUID();
                item.Pwd = StringUtil.EncodeString(model.Pwd, StringUtil.GetPwdKey(item.MChar.ToString()));

                bMember.Add(item);

                msg = "添加成功";
            }
            else
            {
                msg = "Validation data not successfull";
            }
            return msg;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(MemberEdit model)
        {
            string msg;

            if (ModelState.IsValid)
            {
                Zs_Member item = bMember.Find(model.MID);

                item = sysFun.InitialEntity<MemberEdit, Zs_Member>(model, item);
                bMember.Update(item);
                msg = "Saved Successfully";
            }
            else
            {
                msg = "Validation data not successfull";
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
            Zs_Member user = bMember.Find(id);
            bMember.Delete(user);
            return "Deleted successfully";
        }
    }
}