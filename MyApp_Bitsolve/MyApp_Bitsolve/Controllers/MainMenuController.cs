using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessEntities;

namespace MyApp_Bitsolve.Controllers
{
    public class MainMenuController : Controller
    {
        //
        // GET: /MainMenu/

        private readonly IMainMenuService _MMService;
        public MainMenuController()
        {
            _MMService = new MainMenuService();
        }

        public ActionResult MainMenu()
        {
            return View();
        }

         [HttpPost]
        public ActionResult MainMenuList()
        {
            var p = Pager.pager();
            var data=_MMService.GetAllMainMenu(p.pageSize,p.pageNum,p.colSort,p.colDir,p.search) ;
            return Json(new {draw=p.draw, data = data.Item1, recordsFiltered=data.Item2, recordsTotal=data.Item1 }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEditMainMenu(int id = 0)
        {
            MainMenuVM mm = new MainMenuVM();
            if (id == 0)
            {
                return PartialView(mm);
            }
            else
            {
                mm = _MMService.GetMainMenuById(id);
                return PartialView(mm);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditMainMenu(MainMenuVM _MainMenu)
        {
            if (ModelState.IsValid)
            {
                if (_MainMenu.MenuId == 0)
                {
                    bool status = _MMService.AddMainMenu(_MainMenu);
                    if (status)
                    {
                        return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
                }
                else {
                    bool status = _MMService.UpdateMainMenu(_MainMenu);
                    if (status)
                    {
                        return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
                }

            }
            else { return PartialView(_MainMenu); }
        }

        public ActionResult DeleteMainMenu(int id)
        {
            try {
                bool isDelete = _MMService.DeleteMainMenu(id);
                if (isDelete)
                { return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet); }
                else { return Json(new { success = false, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet); }
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}