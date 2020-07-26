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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _custRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _custRepository = new CustomerRepository(_unitOfWork);
        }

        public IEnumerable<CustomerVM> GetAllCustomer()
        {
            var customerList = _custRepository.GetAll();
            List<CustomerVM> custVMList = new List<CustomerVM>();
            foreach (var cust in customerList)
            {
                CustomerVM _custVM = new CustomerVM();
                _custVM.Address = cust.Address;
                _custVM.CST = cust.CST;
                _custVM.CustomerCode = cust.CustomerCode;
                _custVM.CustomerId = cust.CustomerId;
                _custVM.CustomerName = cust.CustomerName;
                _custVM.District = cust.District;
                _custVM.Email = cust.Email;
                _custVM.IsActive =(bool) cust.IsActive;
                _custVM.MobileNo1 = cust.MobileNo1;
                _custVM.MobileNo2 = cust.MobileNo2;
                _custVM.Owner = cust.Owner;
                _custVM.PinCode = cust.PinCode;
                _custVM.State = cust.State;
                _custVM.TelePhone1 = cust.TelePhone1;
                _custVM.TelePhone2 = cust.TelePhone2;
                _custVM.VAT = cust.VAT;
                custVMList.Add(_custVM);
            }
            return custVMList;

        }

        public CustomerVM GetCustomerById(int id)
        {
            var cust = _custRepository.GetById(id);
            CustomerVM _custVM = new CustomerVM();
            _custVM.Address = cust.Address;
            _custVM.CST = cust.CST;
            _custVM.CustomerCode = cust.CustomerCode;
            _custVM.CustomerId = cust.CustomerId;
            _custVM.CustomerName = cust.CustomerName;
            _custVM.District = cust.District;
            _custVM.Email = cust.Email;
            _custVM.IsActive = (bool)cust.IsActive;
            _custVM.MobileNo1 = cust.MobileNo1;
            _custVM.MobileNo2 = cust.MobileNo2;
            _custVM.Owner = cust.Owner;
            _custVM.PinCode = cust.PinCode;
            _custVM.State = cust.State;
            _custVM.TelePhone1 = cust.TelePhone1;
            _custVM.TelePhone2 = cust.TelePhone2;
            _custVM.VAT = cust.VAT;
            return _custVM;
        }

        public bool AddCustomer(CustomerVM _CustomerVM)
        {
            try
            {

                tblCustomer cust = new tblCustomer();
                cust.Address = _CustomerVM.Address;
                cust.CST = _CustomerVM.CST;
                cust.CustomerCode = _CustomerVM.CustomerCode;
                cust.CustomerName = _CustomerVM.CustomerName;
                cust.District = _CustomerVM.District;
                cust.Email = _CustomerVM.Email;
                cust.IsActive = _CustomerVM.IsActive;
                cust.MobileNo1 = _CustomerVM.MobileNo1;
                cust.MobileNo2 = _CustomerVM.MobileNo2;
                cust.Owner = _CustomerVM.Owner;
                cust.PinCode = _CustomerVM.PinCode;
                cust.State = _CustomerVM.State;
                cust.TelePhone1 = _CustomerVM.TelePhone1;
                cust.TelePhone2 = _CustomerVM.TelePhone2;
                cust.VAT = _CustomerVM.VAT;
                cust.IsDeleted = false;
                _custRepository.Add(cust);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateCustomer(CustomerVM _CustomerVM)
        {
            try
            {
                tblCustomer cust = _custRepository.GetById(_CustomerVM.CustomerId);
                cust.Address = _CustomerVM.Address;
                cust.CST = _CustomerVM.CST;
                cust.CustomerCode = _CustomerVM.CustomerCode;
                cust.CustomerName = _CustomerVM.CustomerName;
                cust.District = _CustomerVM.District;
                cust.Email = _CustomerVM.Email;
                cust.IsActive = _CustomerVM.IsActive;
                cust.MobileNo1 = _CustomerVM.MobileNo1;
                cust.MobileNo2 = _CustomerVM.MobileNo2;
                cust.Owner = _CustomerVM.Owner;
                cust.PinCode = _CustomerVM.PinCode;
                cust.State = _CustomerVM.State;
                cust.TelePhone1 = _CustomerVM.TelePhone1;
                cust.TelePhone2 = _CustomerVM.TelePhone2;
                cust.VAT = _CustomerVM.VAT;
                cust.IsDeleted = false;
                _custRepository.Update(cust);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var cust = _custRepository.GetById(id);
                cust.IsDeleted = true;
                _custRepository.Update(cust);
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
