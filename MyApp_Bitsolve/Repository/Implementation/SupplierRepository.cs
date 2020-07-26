using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public  class SupplierRepository:BaseRepository<tblSupplier>,ISupplierRepository
    {

        public SupplierRepository(IUnitOfWork _unitOfWork)
            : base(_unitOfWork)
        {}
    }
}
