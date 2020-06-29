﻿using System;
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
            UserDao userDao = new UserDao();
            var result = userDao.Login(model.Username, model.Password);
            if (result)
            {
                var user = userDao.GetByName(model.Username);
                var CheckRole = userDao.GetRoleUser(user.Username);
                UserLogin userLogin = new UserLogin();
                userLogin.UserID = user.ID;
                userLogin.Username = user.Username;
                Session.Add(SessionConstant.SESSION_USER, userLogin);
                Session.Add(SessionConstant.SESSION_USERNAME, userLogin.Username);
                if (CheckRole == true)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin"});
                }
                else
                {

                    return RedirectToAction("Index", "Home", new {area = ""});
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session[SessionConstant.SESSION_USER] = null;
            HttpContext.Session[SessionConstant.SESSION_USERNAME] = null;
            TempData["check"] = false;
            return RedirectToAction("Login", "Login");
        }
    }
}