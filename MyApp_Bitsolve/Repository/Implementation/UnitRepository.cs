using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public class UnitRepository : BaseRepository<tblUnitMaster>, IUnitRepository
    {
        public UnitRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork) { }
    }
}
