using HanHe.Model;
using HanHe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HanHe.BLL;
using HanHe.IBLL;

namespace HanHe.Web.Controllers
{
    public class HomeController : Controller
    {
        IZs_Member bMember = new BZs_Member();
        IZs_ChuanJia bChuanJia = new BZs_ChuanJia();
        IZs_Project bProject = new BZs_Project();
        IZs_GanWu bGanWu = new BZs_GanWu();

        public ActionResult Index()
        {
            ViewBag.Title = "珍视文化";

            return Redirect("~/help");
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 完善信息
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberDetail()
        {
            Zs_Member entity = bMember.Find(100000);
            return View(entity);
        }
        public ActionResult ChuanJia()
        {
            return View();
        }
        public ActionResult AddChuanJia()
        {
            return View();
        }
        public ActionResult UpdateChuanJia()
        {
            Zs_ChuanJia entity = bChuanJia.Find(6);
            return View(entity);
        }
        public ActionResult Project()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }
        public ActionResult UpdateProject()
        {
            return View();
        }
    }
}
