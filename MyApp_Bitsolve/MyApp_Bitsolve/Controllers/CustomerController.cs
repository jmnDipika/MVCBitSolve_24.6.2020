using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class CustomerController : Controller
    {
         private ICustomerService _CustSerivce;
         public CustomerController()
        {
            _CustSerivce = new CustomerService();
        }
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CustomerList()
        {
            var custList = _CustSerivce.GetAllCustomer();
            return PartialView (custList);
        }

        [HttpGet]
        public ActionResult AddOrEditCustomer(int id=0)
        {
            CustomerVM custVM= new CustomerVM ();
            if (id == 0)
            {
                return PartialView(custVM);
            }
            else {
                custVM = _CustSerivce.GetCustomerById(id);
                return PartialView(custVM);
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEditCustomer(CustomerVM _CustVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool status = false;
                    if (_CustVM.CustomerId == 0)
                    {
                        status = _CustSerivce.AddCustomer(_CustVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Saved Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status=_CustSerivce.UpdateCustomer(_CustVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else {
                    return PartialView(_CustVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }


        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                bool status = false;

                status = _CustSerivce.DeleteCustomer(id);
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