using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;
using System.IO;

namespace MyApp_Bitsolve.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _CompanySerivce;
        public CompanyController()
        {
            _CompanySerivce = new CompanyService();
        }


        //
        // GET: /Company/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEditCompany()
        {
            ViewBag.Country = _CompanySerivce.CountryList();
            CompanyVM _CompanyVM = new CompanyVM();
           var id=_CompanySerivce.IsExist();
            if (id==0)
            {
                return PartialView(_CompanyVM);
            }
            else
            {
                _CompanyVM = _CompanySerivce.GetByIdCompany(id);
                return PartialView(_CompanyVM);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditCompany(CompanyVM _companyVM, HttpPostedFileBase file)
        {
            ViewBag.Country = _CompanySerivce.CountryList();
            if (ModelState.IsValid)
            {
                bool status = false;
                var id=_CompanySerivce.IsExist();
                if (file != null)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(file.InputStream))
                    {
                        bytes = br.ReadBytes((Int32)file.InputStream.Length);
                    }
                    _companyVM.Logo = bytes;
                    string FileName = string.Empty, FilePath = string.Empty;
                    FileName = System.IO.Path.GetFileName(file.FileName);
                    FilePath = System.IO.Path.Combine(Server.MapPath("~/ImagesData/"), FileName);
                    file.SaveAs(FilePath);
                    _companyVM.LogoPath = "~/ImagesData/" + FileName;
                }
                if (id==0)
                {
                    status = _CompanySerivce.CreateCompany(_companyVM);
                    if (status) { return Json(new { success = true, message = "Created Successfully...!" }, JsonRequestBehavior.AllowGet); }
                    else { return Json(new { success = false, message = "Error...!" }, JsonRequestBehavior.AllowGet); }

                }
                else
                {
                    _companyVM.CompanyId = id;
                    status = _CompanySerivce.UpdateCompany(_companyVM);
                    if (status) { return Json(new { success = true, message = "Updated Successfully...!" }, JsonRequestBehavior.AllowGet); }
                    else { return Json(new { success = false, message = "Error...!" }, JsonRequestBehavior.AllowGet); }
                }
            }
            else
            {
                return View(_companyVM);
            }
        }

    }
}