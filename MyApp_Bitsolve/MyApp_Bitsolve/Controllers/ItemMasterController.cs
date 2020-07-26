using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;

namespace MyApp_Bitsolve.Controllers
{
    public class ItemMasterController : Controller
    {
        private IItemMasterService _ItemSerivce;
        private BusinessDropDownList dropDown;
        public ItemMasterController()
        {
            _ItemSerivce = new ItemMasterSerivce();
            dropDown = new BusinessDropDownList();
        }
        public ActionResult ItemIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ItemList()
        {
            List<ItemMasterVM> ItemListVM = _ItemSerivce.GetAllItems().ToList();
            return PartialView(ItemListVM);
        }


        [HttpGet]
        public ActionResult AddOrEditItem(int id = 0)
        {
            ItemMasterVM ItemVM = new ItemMasterVM();
            ViewBag.Types = dropDown.DDLGetTypes();
            ViewBag.Units = dropDown.DDLGetUnits();
            if (id == 0)
            {
                //add
                return PartialView (ItemVM);
            }
            else
            {
                //update
                ItemVM = _ItemSerivce.GetItemById(id);
                return PartialView (ItemVM);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditItem(ItemMasterVM _ItemVM)
        {
            ViewBag.Types = dropDown.DDLGetTypes();
            ViewBag.Units = dropDown.DDLGetUnits();
            try
            {
                bool status = false;
                if (ModelState.IsValid)
                {
                    if (_ItemVM.ItemId == 0)
                    {
                        //add
                        status = _ItemSerivce.AddItem(_ItemVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        //update
                        status = _ItemSerivce.UpdateItem(_ItemVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else
                {
                    return PartialView(_ItemVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult DeleteItem(int id)
        {
            try
            {
                bool status = false;
                status = _ItemSerivce.DeleteItem(id);
                if (status)
                {
                    return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else { return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet); }
            }
            catch (Exception e) {
                throw e;
            }
        }




    }
}