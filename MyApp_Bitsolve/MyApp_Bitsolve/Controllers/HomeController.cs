using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubMenuService _SMService;
        public HomeController()
        {
            _SMService =  new SubMenuService();
        }

        public ActionResult Index()
        {
            if (Session["User"] != null && User.Identity.IsAuthenticated == true)
            {
                Session["SMList"] = _SMService.GetAllSubMenu();
                return View();
            }
            else
            {
                return RedirectToAction("LoginForm", "Login");
            }
        }
    }
}
