using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class RFQRepository:BaseRepository<tblRFQ>,IRFQRepository
    {
       public RFQRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
        {}
    }
}
