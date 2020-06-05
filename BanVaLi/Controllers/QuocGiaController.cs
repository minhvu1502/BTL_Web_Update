using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Models;

namespace BanVaLi.Controllers
{
    public class QuocGiaController : Controller
    {
        WebBanVaLiEntities db = new WebBanVaLiEntities();
        // GET: QuocGia
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetAll()
        {
            return PartialView(db.tQuocGia.ToList());
        }
    }
}