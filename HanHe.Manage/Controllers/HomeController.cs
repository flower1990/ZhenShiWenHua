﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string userName = User.Identity.Name;

            return View();
        }
    }
}