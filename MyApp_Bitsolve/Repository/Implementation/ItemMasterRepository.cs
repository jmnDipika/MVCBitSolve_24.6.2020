using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class ItemMasterRepository: BaseRepository<tblItemMaster>,IItemMasterRepository
    {
       public ItemMasterRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
