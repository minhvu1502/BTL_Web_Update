﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Models;

namespace BanVaLi.Areas.Admin.Controllers
{

    public class HomeAdminController : BaseController
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {

            return View(db.tDanhMucSP.ToList());
        }
    }
}