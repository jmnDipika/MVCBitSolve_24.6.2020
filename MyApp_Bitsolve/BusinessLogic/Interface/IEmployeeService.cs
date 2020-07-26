using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
   public  interface IEmployeeService
    {
       //List<EmployeeVM> GetAllEmployee();
       Tuple< List<EmployeeVM>,int> GetAllEmployee(int pageSize,int pageNum,string SortCo,string SortDir,string search);
        EmployeeVM GetByIdEmployee(int id);
        bool AddEmployee(EmployeeVM _EmployeeVM);
        bool UpdateEmployee(EmployeeVM _EmployeeVM);
        bool DeteleEmplyee(int id);
        
    }
}
