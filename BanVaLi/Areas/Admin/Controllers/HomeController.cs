﻿using BanVaLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BanVaLi.Areas.Admin.Controllers
{

    public class HomeController : BaseController
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}