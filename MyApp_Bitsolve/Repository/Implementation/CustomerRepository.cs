using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public  class CustomerRepository:BaseRepository<tblCustomer>,ICustomerRepository
    {

       public CustomerRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
