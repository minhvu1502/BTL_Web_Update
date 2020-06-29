using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BanVaLi.Common;
using BanVaLi.Models.DAO;

namespace BanVaLi.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[SessionConstant.SESSION_USER];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    { controller = "Login", action = "Login", Area = "Admin" }));
            }
            else
            {
                UserDao dao = new UserDao();
                var check = dao.GetRoleUser(session.Username);
                if (check == false)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    { controller = "Home", action = "Index", Area = "" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}