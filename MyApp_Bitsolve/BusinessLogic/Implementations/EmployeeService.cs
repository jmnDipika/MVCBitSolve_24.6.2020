using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using Repository;
using System.Linq.Dynamic;

namespace BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService()
        {
            _unitOfWork =new UnitOfWork(new MyApp_BitSolveEntities());
            _empRepository = new EmployeeRepository(_unitOfWork);
        }

        public Tuple< List<EmployeeVM>,int> GetAllEmployee(int pageSize,int pageNum,string sortCo,string sortDir,string search)
        {
            int recordsTotal = 0;
            var GetEmpList = _empRepository.GetAll(x=>x.IsDeleted==false).Select(x=>new EmployeeVM{
             Address = x.Address,
                DeptId = x.DeptId,
                DesignationId = x.DesignationId,
                DOB = x.DOB,
                Email = x.Email,
                EmpId = x.EmpId,
                EmployeeNo = x.EmployeeNo,
                Fax = x.Fax,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MobileNo = x.MobileNo,
                IsActive = (bool)x.IsActive,
            }).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
            GetEmpList=GetEmpList.Where(x=>x.Address!=null && x.Address.ToLower().Contains(search.ToLower())
                || x.DOB!=null && x.DOB.ToString().Contains(search)
                || x.Email!=null && x.Email.ToLower().Contains(search.ToLower())
                || x.EmployeeNo!=null && x.EmployeeNo.ToLower().Contains(search.ToLower())
                || x.Fax!=null && x.Fax.Contains(search)
                ||x.FirstName!=null && x.FirstName.ToLower().Contains(search.ToLower())
                || x.LastName !=null && x.LastName.ToLower().Contains(search.ToLower())
                || x.MobileNo != null && x.MobileNo.Contains(search)).AsQueryable();
                
            }
            recordsTotal = GetEmpList.Count();
            GetEmpList = GetEmpList.OrderBy(sortCo + " " + sortDir).Skip(pageNum).Take(pageSize).AsQueryable();

            return new Tuple<List<EmployeeVM>, int>(GetEmpList.ToList(), recordsTotal);
        }

        public EmployeeVM GetByIdEmployee(int id)
        {
            var item = _empRepository.GetById(id);
            EmployeeVM empVm = new EmployeeVM();
            empVm.Address = item.Address;
            empVm.DeptId = item.DeptId;
            empVm.DesignationId = item.DesignationId;
            empVm.DOB = item.DOB;
            empVm.Email = item.Email;
            empVm.EmpId = item.EmpId;
            empVm.EmployeeNo = item.EmployeeNo;
            empVm.Fax = item.Fax;
            empVm.FirstName = item.FirstName;
            empVm.LastName = item.LastName;
            empVm.IsActive = (bool)item.IsActive;
            empVm.MobileNo = item.MobileNo;
            empVm.ImageName = item.ImageName == null ? "~/ImagesData/EmployeeImages/user.png" : item.ImageName;
            return empVm;
        }

        public bool AddEmployee(EmployeeVM _EmployeeVM)
        {
            try
            {
                if (_EmployeeVM != null)
                {
                    tblEmployee emp = new tblEmployee();
                    emp.Address = _EmployeeVM.Address;
                    emp.DeptId = _EmployeeVM.DeptId;
                    emp.DesignationId = _EmployeeVM.DesignationId;
                    emp.DOB = _EmployeeVM.DOB;
                    emp.Email = _EmployeeVM.Email;
                    emp.EmpId = _EmployeeVM.EmpId;
                    emp.EmployeeNo = _EmployeeVM.EmployeeNo;
                    emp.Fax = _EmployeeVM.Fax;
                    emp.FirstName = _EmployeeVM.FirstName;
                    emp.LastName = _EmployeeVM.LastName;
                    emp.MobileNo = _EmployeeVM.MobileNo;
                    emp.UserName = _EmployeeVM.UserName;
                    emp.EmpPassword = _EmployeeVM.EmpPassword;
                    emp.ImageName = _EmployeeVM.ImageName;
                    emp.IsActive = _EmployeeVM.IsActive;
                    emp.IsDeleted = false;
                    _empRepository.Add(emp);
                    _unitOfWork.Complete();
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateEmployee(EmployeeVM _EmployeeVM)
        {
            try
            {
                if (_EmployeeVM != null)
                {
                    tblEmployee emp = _empRepository.GetById(_EmployeeVM.EmpId);
                    emp.Address = _EmployeeVM.Address;
                    emp.DeptId = _EmployeeVM.DeptId;
                    emp.DesignationId = _EmployeeVM.DesignationId;
                    emp.DOB = _EmployeeVM.DOB;
                    emp.Email = _EmployeeVM.Email;
                    emp.EmpId = _EmployeeVM.EmpId;
                    emp.EmployeeNo = _EmployeeVM.EmployeeNo;
                    emp.Fax = _EmployeeVM.Fax;
                    emp.FirstName = _EmployeeVM.FirstName;
                    emp.LastName = _EmployeeVM.LastName;
                    emp.MobileNo = _EmployeeVM.MobileNo;
                    emp.ImageName = _EmployeeVM.ImageName==null ? "~/ImagesData/Koala.jpg":_EmployeeVM.ImageName;
                    emp.IsActive = _EmployeeVM.IsActive;
                    emp.IsDeleted = false;
                    _empRepository.Update(emp);
                    _unitOfWork.Complete();
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeteleEmplyee(int id)
        {
            try
            {
               
                    var emp = _empRepository.GetById(id);
                    emp.IsDeleted = true;
                    _empRepository.Update(emp);
                    _unitOfWork.Complete();
                    return true;
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
