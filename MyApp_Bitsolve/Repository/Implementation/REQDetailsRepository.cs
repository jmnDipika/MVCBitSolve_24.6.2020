using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public class REQDetailsRepository : BaseRepository<tblRFQDetail>, IRFQDetailsRepository
    {
        public REQDetailsRepository(IUnitOfWork _unitOfWork)
            : base(_unitOfWork)
        { }
    }
}
