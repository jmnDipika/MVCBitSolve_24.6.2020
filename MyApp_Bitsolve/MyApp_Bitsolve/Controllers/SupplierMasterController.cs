using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessEntities;


namespace MyApp_Bitsolve.Controllers
{
    public class SupplierMasterController : Controller
    {
        private SupplierMaster _SupplierSerivce;
        public SupplierMasterController()
        {
            _SupplierSerivce = new SupplierMaster();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SupplierIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllSupplier()
        {
            var supplierList = _SupplierSerivce.GetAllSupplier();
            return PartialView(supplierList);
        }

        [HttpGet]
        public ActionResult AddOrEditSupplier(int id = 0)
        {
            try
            {
                SupplierVM _supplierVM = new SupplierVM();
                if (id == 0)
                {
                    return PartialView(_supplierVM);
                }
                else
                {
                    _supplierVM = _SupplierSerivce.GetSupplierById(id);
                    return PartialView(_supplierVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        [HttpPost]
        public ActionResult AddOrEditSupplier(SupplierVM _SupplierVM)
        {
            try
            {
                bool status = false;
                if (ModelState.IsValid)
                {
                    if (_SupplierVM.SupplierId == 0)
                    {
                        status = _SupplierSerivce.AddSupplier(_SupplierVM);
                        if (status) { return Json(new { success = true, message = "Saved Successfully...." }, JsonRequestBehavior.AllowGet); }
                        else { return Json(new { success = false, message = "Error...." }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status = _SupplierSerivce.UpdateSupplier(_SupplierVM);
                        if (status) { return Json(new { success = true, message = "Updated Successfully...." }, JsonRequestBehavior.AllowGet); }
                        else { return Json(new { success = false, message = "Error...." }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else
                {
                    return PartialView(_SupplierVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        public ActionResult DeleteSupplier(int id)
        {
            try
            {
                bool status = false;
                status = _SupplierSerivce.DeleteSupplier(id);
                if (status)
                {
                    return Json(new { success = true, message = "Deleted Successfully...." }, JsonRequestBehavior.AllowGet);
                }
                else { return Json(new { success = true, message = "Error..." }, JsonRequestBehavior.AllowGet); }

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}