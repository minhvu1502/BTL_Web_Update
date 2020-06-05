using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Models;
using PagedList;

namespace BanVaLi.Areas.Admin.Controllers
{
    public class DanhMucSpAdminController : BaseController
    {
        WebBanVaLiEntities db = new WebBanVaLiEntities();
        // GET: Admin/DanhMucSpAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachSanPham(int? page, string MaLoai ="All")
        {
            int pageSize = 8; // số sản phẩm trên 1 trang
            int pageNumber = (page ?? 1); // số trang
            if (MaLoai == "All")
            {
                return View(db.tDanhMucSP.OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
            }
            else
            {
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
                ViewBag.MaLoai = tLoaiSp.MaLoai;
                ViewBag.Page = page;
                return View(db.tDanhMucSP.Where(n => n.MaLoai == MaLoai).OrderBy(n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
            }
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

        [HttpGet]
        public ActionResult CreateProduct()
        {
            ViewBag.MaChatLieu =
                new SelectList(db.tChatLieu.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");

            ViewBag.MaKichThuoc =
                new SelectList(db.tKichThuoc.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");

            ViewBag.MaHangSX =
                new SelectList(db.tHangSX.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");

            ViewBag.MaNuocSX =
                new SelectList(db.tQuocGia.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai =
                new SelectList(db.tLoaiSP.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");

            ViewBag.MaDT =
                new SelectList(db.tLoaiDT.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");

            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct([Bind(Include = " MaSP ,TenSP ,MaChatLieu ,NganLapTop ,Model ,MauSac ,MaKichThuoc , CanNang ,MaHangSX ,MaNuocSX ,MaDacTinh ,Website ,ThoiGianBaoHanh ,GioiThieuSP , Gia , hietKhau ,MaLoai ,MaDT ,Anh ,")] tDanhMucSP sanpham)
        {
            if (ModelState.IsValid)
            {
                db.tDanhMucSP.Add(sanpham);
                db.SaveChanges();
                return RedirectToActionPermanent("DanhSachSanPham", new {@MaLoai = sanpham.MaLoai});
            }
            return View(sanpham);
        }

        [HttpGet]
        public ActionResult EditProduct(string MaSP)
        {
            if (MaSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tDanhMucSP sanpham = db.tDanhMucSP.Find(MaSP);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChatLieu =
                new SelectList(db.tChatLieu.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");

            ViewBag.MaKichThuoc =
                new SelectList(db.tKichThuoc.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");

            ViewBag.MaHangSX =
                new SelectList(db.tHangSX.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");

            ViewBag.MaNuocSX =
                new SelectList(db.tQuocGia.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai =
                new SelectList(db.tLoaiSP.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");

            ViewBag.MaDT =
                new SelectList(db.tLoaiDT.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");
            return View(sanpham);
        }

        [HttpPost]
        public ActionResult EditProduct(tDanhMucSP sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductDetail", new {@MaSP=sanpham.MaSP});
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSP.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult ConfirmDelete(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSP.SingleOrDefault(n => n.MaSP == MaSP);
            var maloai = sanpham.MaLoai;
            var anhsp = from p in db.tAnhSP where p.MaSP == sanpham.MaSP select p;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tAnhSP.RemoveRange(anhsp); //Remove items in table
            db.tDanhMucSP.Remove(sanpham);
            db.SaveChanges();
            TempData["check"] = "Xoa";
            return RedirectToAction("DanhSachSanPham", new { @MaLoai = maloai});
        }
    }
}