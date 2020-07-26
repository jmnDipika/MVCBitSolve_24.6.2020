using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class CompanyRepository:BaseRepository<tblCompany>,ICompanyRepository
    {
       public CompanyRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
