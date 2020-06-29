using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Models;
using PagedList;
using PagedList.Mvc;

namespace BanVaLi.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        // GET: Admin/SearchController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchResult(FormCollection f, int? page)
        {
            string searchKey = f["txt_search"].ToString();
            ViewBag.keyword = searchKey;
            List<tDanhMucSP> lstKQTK = db.tDanhMucSP.Where(n => n.TenSP.Contains(searchKey)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.Error = "Không có sản phẩm bạn tìm kiếm";
                return View(db.tDanhMucSP.OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " sản phẩm";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult SearchResult(int? page, string searchKey)
        {
            ViewBag.keyword = searchKey;
            List<tDanhMucSP> lstKQTK = db.tDanhMucSP.Where(n => n.TenSP.Contains(searchKey)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không có sản phẩm bạn tìm kiếm";
                return View(db.tDanhMucSP.OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstKQTK.Count + "sản phẩm";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}