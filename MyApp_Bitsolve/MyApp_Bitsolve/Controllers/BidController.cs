using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class BidController : Controller
    {

        private IBidService _BidSerivce;
        private BusinessDropDownList dropDown;
        public BidController()
        {
            _BidSerivce = new BidService();
            dropDown = new BusinessDropDownList();
        }

        [HttpGet]
        public ActionResult Bid(int id = 0)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTaxList()
        {
            return Json(dropDown.DDLGetTax(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AutocompleteSupplierList(string supp)
        {
            return Json(dropDown.DDLGetSuppliers(supp), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BidList()
        {
            var bidList = _BidSerivce.GetAllBid();
            return PartialView(bidList);
        }

        [HttpGet]
        public ActionResult GetRFQNosBySupp(int suppId)
        {
            return Json(dropDown.DDLGetRFQNOs(suppId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRFQDetById(int id, int suppid)
        {
            // ViewBag.BidDetailsList = _BidSerivce.GetRFQDetailsListById(id);
            return Json(_BidSerivce.GetRFQDetailsById(id, suppid), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEditBid(int id = 0)
        {
           
            BidMasterVM bidVM = new BidMasterVM();
            ViewBag.RFQNOs = dropDown.DDLGetRFQNOs();
            if (id == 0)
            {
                return PartialView(bidVM);
            }
            else {
                bidVM = _BidSerivce.GetBidById(id);    
                return PartialView(bidVM);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditBid(BidMasterVM _BidVM)
        {
            ViewBag.RFQNOs = dropDown.DDLGetRFQNOs();
            if (ModelState.IsValid)
            {
                try
                {
                    bool status = _BidSerivce.AddBid(_BidVM);
                    if (status)
                    {
                        return Json(new { success = true, message = "Bid Saved Successfully.....!" }, JsonRequestBehavior.AllowGet);
                    }
                    else { return Json(new { success = false, message = "Error.....!" }, JsonRequestBehavior.AllowGet); }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return PartialView(_BidVM);
            }
        }

        [HttpPost]
        public ActionResult DeleteBid(int id)
        {
            var status = _BidSerivce.DeleteBid(id);
            if (status)
            {
                return Json(new { success = true, message = "Deleted Successfully..!" }, JsonRequestBehavior.AllowGet);
            }
            else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
        }





    }
}