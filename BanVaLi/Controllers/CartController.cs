using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Areas.Admin.Controllers;
using BanVaLi.Common;
using BanVaLi.Models;

namespace BanVaLi.Controllers
{
    public class CartController : Controller
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        // GET: Cart
        public ActionResult Index(string MaSP)
        {
            if (Session[SessionConstant.SESSION_CART] == null)
            {
                Session[SessionConstant.SESSION_CART] = new List<Cart>();
            }

            List<Cart> listCarts = HttpContext.Session[SessionConstant.SESSION_CART] as List<Cart>;
            if (MaSP !=null)
            {
                var sp = listCarts.FirstOrDefault(x => x.SanPhamID == MaSP);
                if (sp == null)
                {
                    var model = db.tDanhMucSP.SingleOrDefault(x => x.MaSP == MaSP);
                    Cart cart = new Cart()
                    {
                        DonGia = model.Gia,
                        Hinh = model.Anh,
                        SanPhamID = model.MaSP,
                        SoLuong = 1,
                        TenSanPham = model.TenSP
                    };
                    listCarts.Add(cart);
                }
                else
                {
                    sp.SoLuong++;
                }
                return View(listCarts);
            }
            else
            {
                return View(listCarts);
            }
        }

        public ActionResult DeleteCartItem(string MaSP)
        {
            if (MaSP != null)
            {
                List<Cart> giohang = Session[SessionConstant.SESSION_CART] as List<Cart>;
                Cart itemXoa = giohang.FirstOrDefault(m => m.SanPhamID == MaSP);
                if (itemXoa != null)
                {
                    giohang.Remove(itemXoa);
                }

                return RedirectToAction("Index");
            }
            else
            {
                Session[SessionConstant.SESSION_CART] = null;
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditCount(string MaSP, int soluongmoi)
        {
            List<Cart> giohang = Session[SessionConstant.SESSION_CART] as List<Cart>;
            var model = giohang.FirstOrDefault(x => x.SanPhamID == MaSP);
            if (model != null)
            {
                model.SoLuong = soluongmoi;
            }

            return RedirectToAction("Index");
        }
    }
}