using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Web.Mvc;


namespace BusinessLogic
{
    public  interface ICompanyService
    {
        CompanyVM GetByIdCompany(int id);
        bool CreateCompany(CompanyVM _CompanyVM);
        bool UpdateCompany(CompanyVM _CompanyVM);
        int IsExist();
        List<SelectListItem> CountryList();
    }
}
