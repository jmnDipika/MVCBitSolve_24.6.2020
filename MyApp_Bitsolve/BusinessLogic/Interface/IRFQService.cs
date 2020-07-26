using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public interface IRFQService
    {
        IEnumerable<RFQVM> GetAllRFQ();
        RFQVM GetRFQById(int id);
        bool AddRFQ(RFQVM _RFQVM);
        bool UpdateRFQ(RFQVM _RFQVM);
        bool DeleteRFQ(int id);
        SupplierVM GetSupplier(int id);
        bool SetMailSend(int rfqId);
        Decimal GetTaxValue(int taxid);
    }
}
