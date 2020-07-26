using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public class SubMenuRepository : BaseRepository<tblSubMenu>, ISubMenuRepository
    {
        public SubMenuRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork) { }
    }
}
