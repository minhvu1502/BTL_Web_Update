using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Models;

namespace BanVaLi.Controllers
{

    public class LoaiSpController : Controller
    {
        WebBanVaLiEntities db = new WebBanVaLiEntities();
        // GET: LoaiSp
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DanhMucSanPham()
        {
            return PartialView(db.tLoaiSP.ToList());
        }
    }
}