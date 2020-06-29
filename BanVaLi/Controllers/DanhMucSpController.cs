using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Common;
using BanVaLi.Models;
using PagedList;
using PagedList.Mvc;

namespace BanVaLi.Controllers
{
    public class DanhMucSpController : Controller
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        // GET: DanhMucSp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChuDeSanPham(int? page, string MaLoai = "vali")
        {
            int pageSize = 8; // số sản phẩm trên 1 trang
            int pageNumber = (page ?? 1); // số trang
            tLoaiSP tLoaiSp = db.tLoaiSP.SingleOrDefault(n => n.MaLoai == MaLoai);
            if (tLoaiSp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<tDanhMucSP> list = db.tDanhMucSP.Where(n => n.MaLoai == MaLoai).OrderBy(n => n.MaLoai).ToList();
            if (list.Count == 0)
            {
                
                ViewBag.Error = "Không có sản phẩm nào thuộc loại này";
            }
            ViewBag.Name = tLoaiSp.Loai;
            return View(db.tDanhMucSP.Where(n=>n.MaLoai == MaLoai).OrderBy(n=>n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetProductByCountry(int? page, string MaNuoc = "vn")
        {
            int pageSize = 8; // số sản phẩm trên 1 trang
            int pageNumber = (page ?? 1); // số trang
            tQuocGia tQuocGia = db.tQuocGia.SingleOrDefault(n => n.MaNuoc == MaNuoc);
            if (tQuocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<tDanhMucSP> list = db.tDanhMucSP.Where(n => n.MaNuocSX == MaNuoc).OrderBy(n => n.MaNuocSX).ToList();
            if (list.Count == 0)
            {

                ViewBag.Error = "Không có sản phẩm nào do quốc gia này sản xuất";
            }
            ViewBag.Name = tQuocGia.TenNuoc;
            return View(db.tDanhMucSP.Where(n => n.MaNuocSX == MaNuoc).OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProductDetail(string MaSP = "bacakeroirbl")
        {
            tDanhMucSP sanpham = db.tDanhMucSP.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

        public ActionResult CheckLogin()
        {
            var x = HttpContext.Session[SessionConstant.SESSION_USER];
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}