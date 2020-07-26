using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class ManageRoleController : Controller
    {
        private IUserRoleMasterService _UserRoleMasterService;
        private BusinessDropDownList dropDown;
        public ManageRoleController()
        {
            _UserRoleMasterService = new UserRoleMasterService();
            dropDown = new BusinessDropDownList();
        }

        public ActionResult ManageRole()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserRoleList(int id = 0)
        {
            var userRoleList = _UserRoleMasterService.GetAllUserRole();
            return PartialView(userRoleList);
        }

        [HttpGet]
        public ActionResult AddOrEditUserRole(int id = 0)
        {
            UserRoleMasterVM userRoleVM = new UserRoleMasterVM();

            ViewBag.Role = dropDown.DDLGetRoles();
            if (id == 0)
            {
                //add
                ViewBag.User = dropDown.DDLGetUsers(id);
                return PartialView(userRoleVM);
            }
            else
            {
                //update
                ViewBag.User = dropDown.DDLGetUsers(id);
                userRoleVM = _UserRoleMasterService.GetByIdUserRole(id);
                return PartialView(userRoleVM);
            }
        }


        [HttpPost]
        public ActionResult AddOrEditUserRole(UserRoleMasterVM userRoleVM)
        {
            ViewBag.User = dropDown.DDLGetUsers((int)userRoleVM.UserRoleId);
            ViewBag.Role = dropDown.DDLGetRoles();
            try
            {
                if (ModelState.IsValid)
                {
                    bool status = false;
                    if (userRoleVM.UserRoleId == 0)
                    {
                        status = _UserRoleMasterService.AddUserRole(userRoleVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Role Assign Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status = _UserRoleMasterService.UpdateUserRole(userRoleVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else
                {
                    return PartialView(userRoleVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            


        }

    }
}