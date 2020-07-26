using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;
using System.Web.Security;

namespace MyApp_Bitsolve.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private ILoginService _LoginSer;
        public LoginController()
        {
            _LoginSer = new LoginService();
        }

        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid Username or Password" }, JsonRequestBehavior.AllowGet);
            }
            var user = _LoginSer.Login(loginVM);
            if (user == null)
            {
                return Json(new { success = false, message = "Invalid Username or Password"  }, JsonRequestBehavior.AllowGet);
            }
            Session["User"] = user;
            setCookies(user.UserName, loginVM.remember);
            return Json(new { success = true, url = "/Home/Index" }, JsonRequestBehavior.AllowGet); 
        }

        //[HttpPost]
        //public ActionResult LoginForm(LoginVM loginVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _LoginSer.Login(loginVM);
        //        if (user != null)
        //        {
        //            Session["User"] = user;
        //            setCookies(user.UserName, loginVM.remember);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Incorrect User name or Password.";
        //            return View(loginVM);
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.error = "Incorrect User name or Password.";
        //        return View(loginVM);
        //    }
        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("LoginForm", "Login");
        }

        private void setCookies(string userName = "", bool remember = false)
        {
            var timeout = remember ? 525600 : 20;
            var ticket = new FormsAuthenticationTicket(userName, remember, timeout);
            var EncryptTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookies = new HttpCookie(FormsAuthentication.FormsCookieName, EncryptTicket);
            cookies.Expires = DateTime.Now.AddMinutes(timeout);
            cookies.HttpOnly = true;
            Response.Cookies.Add(cookies);
        }

    }
}