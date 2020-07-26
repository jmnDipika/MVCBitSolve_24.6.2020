using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessEntities;
using PagedList;

namespace MyApp_Bitsolve.Controllers
{
    public class TypeMasterController : Controller
    {
        private ITypeService _TypeSerivce;
        public TypeMasterController()
        {
            _TypeSerivce = new TypeService();
        }
        //
        // GET: /TypeMaster/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TypeMaster()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult TypeList(int id = 0)
        //{
        //    var typeList = _TypeSerivce.GetAllTypes();
        //    return PartialView(typeList);
        //}

        // [HttpPost]
        //public ActionResult TypeList()
        //{
        //    PagingVM pageparam = new PagingVM();
        //    pageparam.start = Convert.ToInt32(Request["start"]);
        //    pageparam.length = Convert.ToInt32(Request["length"]);
        //    pageparam.SearchValue = Request["search[value]"];

        //    pageparam.sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
        //    pageparam.sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
        //    var source = _TypeSerivce.GetAllTypes(pageparam);

        //    return PartialView(source);

        //}


        [HttpGet]
        public ActionResult TypeList(int page = 1)
        {
            PagingVM pageparam = new PagingVM();
            pageparam.page = page;
            pageparam.pageSize = 10;
            var source = _TypeSerivce.GetAllTypes(pageparam);
           // ViewBag.count = _TypeSerivce.GetAllTypes().Count();
            var resultAsPagedList = new StaticPagedList<TypeMasterVM>(source, page, pageparam.pageSize, 25);

            return PartialView(resultAsPagedList);
        }
        [HttpGet]
        public ActionResult AddOrEditType(int id = 0)
        {
            if (Session["User"] != null)
            {
                TypeMasterVM typeVM = new TypeMasterVM();
                
                if (id == 0)
                {
                    //add
                    return PartialView(typeVM);
                }
                else
                {
                    //update
                    typeVM = _TypeSerivce.GetByIdType(id);
                    return PartialView(typeVM);
                }
            }
            else { return RedirectToAction("Login", "LoginForm"); }
        }


        [HttpPost]
        public ActionResult AddOrEditType(TypeMasterVM typeVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool status = false;
                    if (typeVM.TypeId == 0)
                    {
                        status = _TypeSerivce.AddType(typeVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Saved Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                    else
                    {
                        status = _TypeSerivce.UpdateType(typeVM);
                        if (status)
                        {
                            return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet);
                        }
                        else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }
                    }
                }
                else
                {
                    return PartialView(typeVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }

        [HttpPost]
        public ActionResult DeleteType(int id)
        {
            try
            {
                bool status = false;

                status = _TypeSerivce.DeteleType(id);
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