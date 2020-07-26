using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class UnitMasterController : Controller
    {
        private IUnitService _UnitService;
        public UnitMasterController()
        {
            _UnitService = new UnitService();
        }
        //
        // GET: /UnitMaster/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnitMaster()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UnitList()
        {
            var unitList = _UnitService.GetAllUnitsVM();
            return PartialView(unitList);
        }

       

        [HttpGet]
        public ActionResult AddOrEditUnit(int id = 0)
        {
            UnitMasterVM unitVM = new UnitMasterVM();

            if (id == 0)
            {
                //add
                return PartialView(unitVM);
            }
            else
            {
                //update
                unitVM = _UnitService.GetByIdUnit(id);
                return PartialView(unitVM);
            }
        }


        [HttpPost]
        public ActionResult AddOrEditUnit(UnitMasterVM unitVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool status = false;
                    if (unitVM.UnitId == 0)
                    {
                        status = _UnitService.AddUnit(unitVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Saved Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status = _UnitService.UpdateUnit(unitVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else
                {
                    return PartialView(unitVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }

        [HttpPost]
        public ActionResult DeleteUnit(int id)
        {
            try
            {
                bool status = false;

                status = _UnitService.DeleteUnit(id);
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