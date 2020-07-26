using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using Repository;

namespace BusinessLogic
{
    public class UserRoleMasterService : IUserRoleMasterService
    {

        private readonly IUserRoleMasterRepository _UserRoleRepository;
        private readonly IEmployeeRepository _empRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserRoleMasterService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _UserRoleRepository = new UserRoleMasterRepository(_unitOfWork);
            _empRepository = new EmployeeRepository(_unitOfWork);
        }


        public List<UserRoleMasterVM> GetAllUserRole()
        {

            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {

                var userRoleList = (from ur in _UserRoleRepository.GetAll()
                                    join u in _empRepository.GetAll(x => x.IsActive == true && x.IsDeleted == false)
                                    on ur.UserId equals u.EmpId
                                    select new
                                   UserRoleMasterVM
                                   {
                                       RoleId = ur.RoleId,
                                       UserId = ur.UserId,
                                       UserRoleId = ur.UserRoleId,
                                       UserName = u.UserName,
                                       RoleName = db.tblRoleMasters.Where(x => x.RoleId == ur.RoleId).Select(x => x.RoleName).FirstOrDefault()
                                   }).ToList();

                return userRoleList;
            }
        }

        public UserRoleMasterVM GetByIdUserRole(int id)
        {
            var item = _UserRoleRepository.GetById(id);
            UserRoleMasterVM user = new UserRoleMasterVM();
            if (item != null)
            {
                user.RoleId = item.RoleId;
                user.UserId = item.UserId;
                user.UserRoleId = item.UserRoleId;
            }
            return user;
        }

        public bool AddUserRole(UserRoleMasterVM UserRoleVM)
        {
            try
            {
                if (UserRoleVM != null)
                {
                    UserRoleMaster user = new UserRoleMaster();
                    if (UserRoleVM != null)
                    {
                        user.RoleId = UserRoleVM.RoleId;
                        user.UserId = UserRoleVM.UserId;
                        user.UserRoleId = UserRoleVM.UserRoleId;
                    }
                    _UserRoleRepository.Add(user);
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool UpdateUserRole(UserRoleMasterVM UserRoleVM)
        {
            try
            {
                if (UserRoleVM != null)
                {
                    UserRoleMaster user = _UserRoleRepository.GetById(UserRoleVM.UserRoleId);
                    if (UserRoleVM != null)
                    {
                        user.RoleId = UserRoleVM.RoleId;
                        user.UserRoleId = UserRoleVM.UserRoleId;
                    }
                    _UserRoleRepository.Update(user);
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool DeleteUserRole(int id)
        {
            throw new NotImplementedException();
        }
    }
}
