using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessEntities;

namespace MyApp_Bitsolve.Controllers
{
    public class TaxMasterController : Controller
    {
        private ITaxService _TaxSerivce;
        public TaxMasterController()
        {
            _TaxSerivce = new TaxService();
        }

        //
        // GET: /TaxMaster/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaxMaster()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TaxList(int id = 0)
        {
            var taxList = _TaxSerivce.GetAllTax();
            return PartialView(taxList);
        }

        [HttpGet]
        public ActionResult AddOrEditTax(int id = 0)
        {
            TaxMasterVM taxVM = new TaxMasterVM();

            if (id == 0)
            {
                //add
                return PartialView(taxVM);
            }
            else
            {
                //update
                taxVM = _TaxSerivce.GetByIdTax(id);
                return PartialView(taxVM);
            }
        }


        [HttpPost]
        public ActionResult AddOrEditTax(TaxMasterVM taxVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool status = false;
                    if (taxVM.TaxId==0)
                    {
                        status = _TaxSerivce.AddTax(taxVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Saved Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status = _TaxSerivce.UpdateTax(taxVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else
                {
                    return PartialView(taxVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }

        [HttpPost]
        public ActionResult DeleteTax(int id)
        {
            try
            {
                bool status = false;

                status = _TaxSerivce.DeteleTax(id);
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