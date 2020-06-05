using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Models;
using PagedList;

namespace BanVaLi.Controllers
{
    public class HomeController : Controller
    {
        WebBanVaLiEntities db = new WebBanVaLiEntities();
        public ActionResult Index(int? page)
        {
            int pageSize = 8; // số sản phẩm trên 1 trang
            int pageNumber = (page ?? 1); // số trang
            return View(db.tDanhMucSP.OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}