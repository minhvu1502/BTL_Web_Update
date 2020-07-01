using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVaLi.Common;
using BanVaLi.Models;
using BanVaLi.Models.UserModel;
using Newtonsoft.Json;

namespace BanVaLi.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UserDetail(string username)
        {
            if (username == null && Session[SessionConstant.SESSION_USERNAME] != null)
            {
                username = (string)Session[SessionConstant.SESSION_USERNAME];
            }

            if (username == null && Session[SessionConstant.SESSION_USERNAME] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var user = db.User.FirstOrDefault(x => x.Username == username);
            return View(user);
        }
        [HttpPost]
        public string EditUser(UserEdit user)
        {
            var model = db.User.FirstOrDefault(x => x.Username == user.Username);
            model.Name = user.Name;
            model.Email = user.Email;
            model.Phone = user.Phone;
            model.Password = user.NewPassword;
            db.SaveChanges();
            Result result = new Result()
            {
                ErrorCode = "0",
                ErrorMessage = "Edit success"
            };
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public ActionResult Register(UserRegister model)
        {
            var user = db.User.FirstOrDefault(x => x.Username == model.Username);
            if (user != null)
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại.");
            }
            else if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Mật khẩu phải giống nhau");
            }
            else
            {
                User result = new User()
                {
                    Email = model.Email,
                    Name = model.Fullname,
                    Password = model.Password,
                    Phone = model.Phone,
                    Username = model.Username,
                    UserGroup_ID = 2
                };
                db.User.Add(result);
                db.SaveChanges();
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}