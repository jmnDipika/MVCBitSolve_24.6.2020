using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BusinessEntities;

namespace BusinessLogic
{
    public  interface ICustomerService
    {
        IEnumerable<CustomerVM> GetAllCustomer();
        CustomerVM GetCustomerById(int id);
        bool AddCustomer(CustomerVM _Customer);
        bool UpdateCustomer(CustomerVM _Customer);
        bool DeleteCustomer(int id);
    }
}
