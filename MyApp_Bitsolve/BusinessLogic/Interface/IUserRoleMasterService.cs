using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public interface IUserRoleMasterService
    {
        List<UserRoleMasterVM> GetAllUserRole();
        UserRoleMasterVM GetByIdUserRole(int id);
        bool AddUserRole(UserRoleMasterVM UserRoleVM);
        bool UpdateUserRole(UserRoleMasterVM UserRoleVM);
        bool DeleteUserRole(int id);
    }
}
