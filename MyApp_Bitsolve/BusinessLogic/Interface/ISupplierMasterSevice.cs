using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public  interface ISupplierMasterSevice 
    {
        IEnumerable<SupplierVM> GetAllSupplier();
        SupplierVM GetSupplierById(int id);
        bool AddSupplier(SupplierVM _SupplierVM);
        bool UpdateSupplier(SupplierVM _SupplierVM);
        bool DeleteSupplier(int id);
    }
}
