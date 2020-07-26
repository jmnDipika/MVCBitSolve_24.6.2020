using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
   public  interface IBidService
    {
        IEnumerable<BidMasterVM> GetAllBid();
        BidMasterVM GetBidById(int id);
        bool AddBid(BidMasterVM _BidVM);
        bool UpdateBid(BidMasterVM _BidVM);
        bool DeleteBid(int id);
        BidMasterVM GetRFQDetailsById(int rfqId,int suppid);
        //List<BidDetailsVM> GetRFQDetailsListById(int rfqId);
        //SupplierVM GetSupplier(int id);
    }
}
