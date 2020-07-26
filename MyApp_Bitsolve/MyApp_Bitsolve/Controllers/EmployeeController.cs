using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

         private IEmployeeService _EmployeeSerivce;
         private BusinessDropDownList dropDown;
         public EmployeeController()
        {
            _EmployeeSerivce = new EmployeeService();
            dropDown = new BusinessDropDownList();
        }

        public ActionResult EmployeeIndex()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult EmployeeList()
        {
            
                var p = Pager.pager();
                var data = _EmployeeSerivce.GetAllEmployee(p.pageSize, p.pageNum, p.colSort, p.colDir, p.search);
           
            return Json(new { draw = p.draw, data = data.Item1, recordsFiltered = data.Item2, recordsTotal = data.Item2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEditEmployee(int id=0)
        {
            EmployeeVM empVM = new EmployeeVM();
            ViewBag.designation = dropDown.DDLGetDesignation();
            ViewBag.dept = dropDown.DDLGetDept();
            if (id == 0)
            {
                return PartialView(empVM);
            }
            else {
                empVM = _EmployeeSerivce.GetByIdEmployee(id);
                Session["ImageName"] = empVM.ImageName;
                return PartialView(empVM);
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEditEmployee(EmployeeVM _empVM)
        {
            try
            {

                ViewBag.designation = dropDown.DDLGetDesignation();
                ViewBag.dept = dropDown.DDLGetDept();

                if (_empVM.file != null)
                {
                    string fileName = null, filePath = null;
                    fileName = System.IO.Path.GetFileName(_empVM.file.FileName);
                    filePath = System.IO.Path.Combine(Server.MapPath("~/ImagesData/EmployeeImages/"), fileName);
                    _empVM.file.SaveAs(filePath);
                    _empVM.ImageName = fileName;
                    Session["ImageName"] = fileName;
                }
                if (Session["ImageName"] != null)
                {
                    _empVM.ImageName = Session["ImageName"].ToString();
                }
                if (ModelState.IsValid)
                {
                    bool status = false;
                    if (_empVM.EmpId == 0)
                    {
                        status = _EmployeeSerivce.AddEmployee(_empVM);
                        if (status)
                        {
                            Session.Clear();
                            Session.Abandon();
                            return Json(new { success = true, message = "Saved Successfully...!" }, JsonRequestBehavior.AllowGet);
                           
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status = _EmployeeSerivce.UpdateEmployee(_empVM);
                        if (status)
                        {
                            Session.Clear();
                            Session.Abandon();
                            return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet);
                            
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else {
                    
                    return PartialView(_empVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }


        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                bool status = false;

                status = _EmployeeSerivce.DeteleEmplyee(id);
                if (status)
                {
                    return Json(new { success = true, message = "Deleted Successfully...!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error...!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { throw e; }
            
        }
	}
}