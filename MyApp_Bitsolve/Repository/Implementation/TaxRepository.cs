using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public class TaxRepository:BaseRepository<tblTaxMaster> ,ITaxRepsitory
    {
        public TaxRepository(IUnitOfWork _unitOfWork)
            : base(_unitOfWork)
       { }
    }
}
