using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessEntities;
using System.ComponentModel;

namespace MyApp_Bitsolve.Controllers
{
    public class SubMenuController : BaseController
    {
        //
        // GET: /SubMenu/
        private readonly ISubMenuService _SMService;
        private BusinessDropDownList dropDown;
        public SubMenuController()//ISubMenuService _ISMService)
        {
           // _SMService = _ISMService;
            _SMService = new SubMenuService();
            dropDown = new BusinessDropDownList();
        }
      
        public ActionResult SubMenu()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SubMenuList()
        {
            var p=  Pager.pager();
            var data = _SMService.GetAllSubMenu(p.pageNum, p.pageSize, p.search, p.colSort, p.colDir);
            return Json(new { draw = p.draw, recordsFiltered = data.Item2, recordsTotal = data.Item2,
                data = data.Item1 }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEditSubMenu(int id=0)
        {
            SubMenuVM sm = new SubMenuVM();
            ViewBag.mainMenuList = dropDown.DDLGetMainMenus();
            if (id == 0)
            {
                return PartialView(sm);
            }
            else {
                sm = _SMService.GetSubMenuById(id);
                return PartialView(sm);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditSubMenu(SubMenuVM _smVM)
        {
            ViewBag.mainMenuList = dropDown.DDLGetMainMenus();
             if (ModelState.IsValid)
             {
                 if (_smVM.SubMenuId == 0)
                 {
                     bool status = _SMService.AddSubMenu(_smVM);
                    if (status)
                    {
                        return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
         
                 }
                 else {
                     bool status = _SMService.UpdateSubMenu(_smVM);
                     if (status)
                     {
                         return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                     }
                     else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
         
                 }
             }
             else {
                 return PartialView(_smVM); 
             }
            
        }
    }
}