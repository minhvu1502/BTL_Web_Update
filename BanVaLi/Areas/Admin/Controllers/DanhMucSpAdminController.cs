using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using BanVaLi.Areas.Models.SanPham;
using BanVaLi.Common;
using BanVaLi.Models;
using Newtonsoft.Json;
using PagedList;

namespace BanVaLi.Areas.Admin.Controllers
{
    public class DanhMucSpAdminController : BaseController
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        // GET: Admin/DanhMucSpAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachSanPham(string MaLoai = "All")
        {
            if (MaLoai == "All")
            {
                return View(db.tDanhMucSP.OrderBy(n => n.TenSP).ToList());
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
                return View(db.tDanhMucSP.Where(n => n.MaLoai == MaLoai).OrderBy(n => n.TenSP).ToList());
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
        public ActionResult CreateProduct([Bind(Include = " MaSP ,TenSP ,MaChatLieu ,NganLapTop ,Model ,MauSac ,MaKichThuoc , CanNang ,MaHangSX ,MaNuocSX ,MaDacTinh ,Website ,ThoiGianBaoHanh ,GioiThieuSP , Gia , hietKhau ,MaLoai ,MaDT ,Anh , Status")] tDanhMucSP sanpham)
        {
            if (ModelState.IsValid)
            {
                var x = db.tDanhMucSP.Find(sanpham.MaSP);
                if (x != null)
                {
                    ModelState.AddModelError("", "Đã có sản phẩm này");
                }
                else
                {
                    db.tDanhMucSP.Add(sanpham);
                    db.SaveChanges();
                    return RedirectToActionPermanent("DanhSachSanPham", new { @MaLoai = sanpham.MaLoai.Trim() });
                }
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
            return View();
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
                return RedirectToAction("ProductDetail", new { @MaSP = sanpham.MaSP });
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

        [HttpGet]
        public string ConfirmDelete(SanPhamDelete model)
        {
            Result result;
            var sanpham = db.tDanhMucSP.SingleOrDefault(n => n.MaSP == model.MaSP);
            var anhsp = from p in db.tAnhSP where p.MaSP == sanpham.MaSP select p;
            if (sanpham == null)
            {
                result = new Result()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Không Tồn Tại Sản Phẩm"
                };
                return JsonConvert.SerializeObject(result);
            }
            db.tAnhSP.RemoveRange(anhsp); //Remove items in table
            db.tDanhMucSP.Remove(sanpham);
            db.SaveChanges();
            result = new Result()
            {
                ErrorCode = "0",
                ErrorMessage = "deleted"
            };
            return JsonConvert.SerializeObject(result);
        }
        [HttpGet]
        public ActionResult PartialViewModal(string MaSP)
        {
            var sanpham = db.tDanhMucSP.FirstOrDefault(x => x.MaSP == MaSP);
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
            return PartialView(sanpham);
        }

        [HttpPost]
        public ActionResult PartialViewModal(tDanhMucSP sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachSanPham", new { @MaLoai = sanpham.MaLoai.Trim() });
        }

        public string EditStatus(StatusEdit edit)
        {
            Result result = new Result();
            var model = db.tDanhMucSP.First(x => x.MaSP == edit.MaSP);
            if (edit.Status == "1")
            {
                model.Status = false;
                db.SaveChanges();
                result = new Result()
                {
                    ErrorCode = "0",
                    ErrorMessage = "edit success"
                };
            }

            if (edit.Status == "0")
            {
                model.Status = true;
                db.SaveChanges();
                result = new Result()
                {
                    ErrorCode = "0",
                    ErrorMessage = "edit success"
                };
            }
            return JsonConvert.SerializeObject(result);
        }
    }

    internal class WebBanVaLiEntities
    {
    }
}