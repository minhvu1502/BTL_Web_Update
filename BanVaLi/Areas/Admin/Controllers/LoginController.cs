using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Common;
using BanVaLi.Models;
using BanVaLi.Models.DAO;

namespace BanVaLi.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDao userDao = new UserDao();
                var result = userDao.Login(model.Username, model.Password);
                if (result)
                {
                    var user = userDao.GetByName(model.Username);
                    UserLogin userLogin = new UserLogin();
                    userLogin.UserID = user.ID;
                    userLogin.Username = user.Username;
                    Session.Add(SessionConstant.SESSION_USER, userLogin);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Đăng nhập thất bại");
                }
            }
            return View();
        }
    }
}