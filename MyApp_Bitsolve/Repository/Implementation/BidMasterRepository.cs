using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class BidMasterRepository:BaseRepository<tblBidMaster>,IBidMasterRepository
    {
       public BidMasterRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
