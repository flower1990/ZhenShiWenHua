using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Repositories;
using HanHe.Manage.Models.Users;
using HanHe.Model;
using HanHe.Util;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class UserController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_User bUser = new BZs_User();
        IZs_Role bRole = new BZs_Role();

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        public JsonResult GetRoleList()
        {
            var list = bRole.Entities;
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="returnUrl">返回Url</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var message = string.Empty;
            var user = new Zs_User();
            var identity = new ClaimsIdentity();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            user = bUser.Login(model.Account);
            if (user == null)
            {
                message = string.Format("账号 {0} 不存在", model.Account);
                ModelState.AddModelError("Account", message);
                return View(model);
            }
            else if (user.UserStatus != 1)
            {
                message = string.Format("账号 {0} 无效", model.Account);
                ModelState.AddModelError("Account", message);
                return View(model);
            }
            else if (user.Pwd != StringUtil.EncodeString(model.Password, StringUtil.GetPwdKey(user.UserChar.ToString())))
            {
                message = string.Format("密码输入错误");
                ModelState.AddModelError("Account", message);
                return View(model);
            }

            identity = bUser.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, identity);

            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            return View();
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid)
        {
            var query = bUser.Entities;
            
            //filtring
            query = GridFilter.Filtring<Zs_User>(grid, query);

            //sorting
            query = query.OrderBy<Zs_User>(grid.SortColumn, grid.SortOrder);

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
                            ZsUserID = item.ZsUserID,
                            LoginName = item.LoginName,
                            Pwd = item.Pwd,
                            RoleID = item.RoleID,
                            Mobile = item.Mobile,
                            Email = item.Email,
                            UserStatus = item.UserStatus,
                            CreateDate = item.CreateDate,
                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string Create(UserCreate user)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Zs_User item = new Zs_User();
                    item = sysFun.InitialEntity<UserCreate, Zs_User>(user, item);
                    item.UserChar = StringUtil.GetGUID();
                    item.Pwd = StringUtil.EncodeString(user.Pwd, StringUtil.GetPwdKey(item.UserChar.ToString()));

                    bUser.Add(item);
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
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(UserEdit user)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Zs_User item = bUser.Find(user.ZsUserID);
                    item = sysFun.InitialEntity<UserEdit, Zs_User>(user, item);
                    bUser.Update(item);
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
            Zs_User user = bUser.Find(id);
            bUser.Delete(user);
            return "Deleted successfully";
        }
    }
}