using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class BidDetailsRepository:BaseRepository<tblBidDetail> ,IBidDetailsRepository
    {
       public BidDetailsRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
