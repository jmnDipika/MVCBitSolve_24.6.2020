using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BusinessEntities;
using Repository;
using System.Web.Mvc;

namespace BusinessLogic
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _companyRepository = new CompanyRepository(_unitOfWork);
        }


        public bool CreateCompany(CompanyVM _CompanyVM)
        {
            try
            {
                tblCompany company = new tblCompany();
                company.Address = _CompanyVM.Address;
                company.BankAccountNo = _CompanyVM.BankAccountNo;
                company.BankIFSCNo = _CompanyVM.BankIFSCNo;
                company.BankName = _CompanyVM.BankName;
                company.City = _CompanyVM.City;
                company.CompanyName = _CompanyVM.CompanyName;
                company.CountryId = _CompanyVM.CountryId;
                company.Email = _CompanyVM.Email;
                company.FaxNo = _CompanyVM.FaxNo;
                company.GSTIN = _CompanyVM.GSTIN;
                company.IsActive = _CompanyVM.IsActive;
                company.Logo = _CompanyVM.Logo;
                company.LogoPath = _CompanyVM.LogoPath;
                company.MobileNo = _CompanyVM.MobileNo;
                company.Password = _CompanyVM.Password;
                company.PinCode = _CompanyVM.PinCode;
                company.State = _CompanyVM.State;
                company.TelephoneNo = _CompanyVM.TelephoneNo;
                company.Website = _CompanyVM.Website;
                _companyRepository.Add(company);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e) { throw e; }
        }

        public bool UpdateCompany(CompanyVM _CompanyVM)
        {
            try
            {
                tblCompany company = _companyRepository.GetById(_CompanyVM.CompanyId);

                company.Address = _CompanyVM.Address;
                company.BankAccountNo = _CompanyVM.BankAccountNo;
                company.BankIFSCNo = _CompanyVM.BankIFSCNo;
                company.BankName = _CompanyVM.BankName;
                company.City = _CompanyVM.City;
                company.CompanyName = _CompanyVM.CompanyName;
                company.CountryId = _CompanyVM.CountryId;
                company.Email = _CompanyVM.Email;
                company.FaxNo = _CompanyVM.FaxNo;
                company.GSTIN = _CompanyVM.GSTIN;
                company.IsActive = _CompanyVM.IsActive;
                company.Logo = _CompanyVM.Logo;
                company.LogoPath = _CompanyVM.LogoPath;
                company.MobileNo = _CompanyVM.MobileNo;
                company.Password = _CompanyVM.Password;
                company.PinCode = _CompanyVM.PinCode;
                company.State = _CompanyVM.State;
                company.TelephoneNo = _CompanyVM.TelephoneNo;
                company.Website = _CompanyVM.Website;

                _companyRepository.Update(company);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e) { throw e; }
        }

        public CompanyVM GetByIdCompany(int id)
        {
            try
            {
                tblCompany company = _companyRepository.GetById(id);
                CompanyVM _CompanyVM = new CompanyVM();
                _CompanyVM.Address = company.Address;
                _CompanyVM.BankAccountNo = company.BankAccountNo;
                _CompanyVM.BankIFSCNo = company.BankIFSCNo;
                _CompanyVM.BankName = company.BankName;
                _CompanyVM.City = company.City;
                _CompanyVM.CompanyName = company.CompanyName;
                _CompanyVM.CountryId = company.CountryId;
                _CompanyVM.Email = company.Email;
                _CompanyVM.FaxNo = company.FaxNo;
                _CompanyVM.GSTIN = company.GSTIN;
                _CompanyVM.IsActive = company.IsActive;
                _CompanyVM.Logo = company.Logo;
                _CompanyVM.MobileNo = company.MobileNo;
                _CompanyVM.Password = company.Password;
                _CompanyVM.PinCode = company.PinCode;
                _CompanyVM.State = company.State;
                _CompanyVM.TelephoneNo = company.TelephoneNo;
                _CompanyVM.Website = company.Website;

                if (company.Logo != null)
                {
                    _CompanyVM.LogoPath = string.Format("data:image/jpg;base64,{0}",
                        Convert.ToBase64String(company.Logo, 0, company.Logo.Length));
                }

                return _CompanyVM;
            }
            catch (Exception e) { throw e; }
        }

        public int IsExist()
        {
            var comp = _companyRepository.GetAll();
            if ((from c in comp select c.CompanyId).Any())
            {
                var id = comp.Select(x => x.CompanyId).FirstOrDefault();
                return id;
            }
            else { return 0; }
        }


        public List<System.Web.Mvc.SelectListItem> CountryList()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                List<SelectListItem> ddlCountry = new List<SelectListItem>();
                var countryList = db.tblCountries.ToList();
                foreach (var c in countryList)
                {
                    ddlCountry.Add(new SelectListItem()
                    {
                        Value = c.CountryId.ToString(),
                        Text = c.CountryName
                    });
                }
                return ddlCountry;
            }
            
        }
    }
}
