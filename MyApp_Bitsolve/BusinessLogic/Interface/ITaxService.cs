using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
   public  interface ITaxService
   {
       List<TaxMasterVM> GetAllTax();
       TaxMasterVM GetByIdTax(int id);
       bool AddTax(TaxMasterVM _TaxVM);
       bool UpdateTax(TaxMasterVM _TaxVM);
       bool DeteleTax(int id);

    }
}
