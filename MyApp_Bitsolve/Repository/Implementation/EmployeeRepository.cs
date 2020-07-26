using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class EmployeeRepository:BaseRepository<tblEmployee>,IEmployeeRepository
    {
     public   EmployeeRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
