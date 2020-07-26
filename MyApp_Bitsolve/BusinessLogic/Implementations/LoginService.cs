using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Repository;
using DataModel;


namespace BusinessLogic
{
    public class LoginService : ILoginService
    {
        private readonly IEmployeeRepository _empRes;
        private readonly IUnitOfWork _unitOfWork;
        public LoginService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _empRes = new EmployeeRepository(_unitOfWork);
        }

        public LoginVM Login(LoginVM _login)
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var user = (from role in db.UserRoleMasters
                            join emp in
                                db.tblEmployees on role.UserId equals emp.EmpId
                            where role.RoleId == 1 && emp.UserName ==_login.UserName
                            && emp.EmpPassword == _login.Password
                            select new { emp.UserName,emp.ImageName,emp.EmpId }).FirstOrDefault();

                if (user != null)
                {
                    _login.UserName = user.UserName;
                    _login.ImageName = user.ImageName;
                    _login.RoleId = (int)user.EmpId;
                    return _login;
                }
                else
                {
                    return _login = null;
                }

            }
        }
    }
}
