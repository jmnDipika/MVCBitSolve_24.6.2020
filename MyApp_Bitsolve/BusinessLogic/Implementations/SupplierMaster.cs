using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using BusinessEntities;
using DataModel;

namespace BusinessLogic
{
   public  class SupplierMaster:ISupplierMasterSevice
   {
       private readonly ISupplierRepository _SupplierRepository;
       private readonly IUnitOfWork _unitOfWork;

       public SupplierMaster()
       {
           _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
           _SupplierRepository = new SupplierRepository(_unitOfWork);
       }


       public IEnumerable<SupplierVM> GetAllSupplier()
       {
           try
           {
               var SupplierVMList = _SupplierRepository.GetAll().Where(x=>x.IsDeleted==false).Select(
                   x=> new SupplierVM{
                    Address = x.Address,
                   CST = x.CST,
                   District = x.District,
                   Email = x.Email,
                   IsActive =(bool) x.IsActive,
                   MobileNo1 = x.MobileNo1,
                   MobileNo2 = x.MobileNo2,
                   Owner = x.Owner,
                   PinCode = x.PinCode,
                   State = x.State,
                   SupplierCode = x.SupplierCode,
                   SupplierId = x.SupplierId,
                   SupplierName = x.SupplierName,
                   TelePhone1 = x.TelePhone1,
                   TelePhone2 = x.TelePhone2,
                   VAT = x.VAT,
                   });
               return SupplierVMList;
           }
           catch (Exception e) {
               throw e;
           }
       }

       public SupplierVM GetSupplierById(int id)
       {
           try
           {
               var _supp = _SupplierRepository.GetById(id);
               SupplierVM suppVM = new SupplierVM();
               suppVM.Address = _supp.Address;
               suppVM.CST = _supp.CST;
               suppVM.District = _supp.District;
               suppVM.Email = _supp.Email;
               suppVM.IsActive = (bool)_supp.IsActive;
               suppVM.MobileNo1 = _supp.MobileNo1;
               suppVM.MobileNo2 = _supp.MobileNo2;
               suppVM.Owner = _supp.Owner;
               suppVM.PinCode = _supp.PinCode;
               suppVM.State = _supp.State;
               suppVM.SupplierCode = _supp.SupplierCode;
               suppVM.SupplierId = _supp.SupplierId;
               suppVM.SupplierName = _supp.SupplierName;
               suppVM.TelePhone1 = _supp.TelePhone1;
               suppVM.TelePhone2 = _supp.TelePhone2;
               suppVM.VAT = _supp.VAT;
               return suppVM;
           }
           catch (Exception e) {
               throw e;
           }
       }

       public bool AddSupplier(SupplierVM _SupplierVM)
       {
           try
           {
               tblSupplier supplier = new tblSupplier();
               supplier.Address = _SupplierVM.Address;
               supplier.CST = _SupplierVM.CST;
               supplier.District = _SupplierVM.District;
               supplier.Email = _SupplierVM.Email;
               supplier.IsActive = _SupplierVM.IsActive;
               supplier.MobileNo1 = _SupplierVM.MobileNo1;
               supplier.MobileNo2 = _SupplierVM.MobileNo2;
               supplier.Owner = _SupplierVM.Owner;
               supplier.PinCode = _SupplierVM.PinCode;
               supplier.State = _SupplierVM.State;
               supplier.SupplierCode = _SupplierVM.SupplierCode;
               supplier.SupplierName = _SupplierVM.SupplierName;
               supplier.TelePhone1 = _SupplierVM.TelePhone1;
               supplier.TelePhone2 = _SupplierVM.TelePhone2;
               supplier.VAT = _SupplierVM.VAT;
               supplier.IsDeleted = false;
               _SupplierRepository.Add(supplier);
               _unitOfWork.Complete();
               return true;
           }
           catch (Exception e) {
               throw e;
           }
       }

       public bool UpdateSupplier(SupplierVM _SupplierVM)
       {
           try
           {
               tblSupplier supplier = _SupplierRepository.GetById(_SupplierVM.SupplierId);
               supplier.Address = _SupplierVM.Address;
               supplier.CST = _SupplierVM.CST;
               supplier.District = _SupplierVM.District;
               supplier.Email = _SupplierVM.Email;
               supplier.IsActive = _SupplierVM.IsActive;
               supplier.MobileNo1 = _SupplierVM.MobileNo1;
               supplier.MobileNo2 = _SupplierVM.MobileNo2;
               supplier.Owner = _SupplierVM.Owner;
               supplier.PinCode = _SupplierVM.PinCode;
               supplier.State = _SupplierVM.State;
               supplier.SupplierCode = _SupplierVM.SupplierCode;
               supplier.SupplierName = _SupplierVM.SupplierName;
               supplier.TelePhone1 = _SupplierVM.TelePhone1;
               supplier.TelePhone2 = _SupplierVM.TelePhone2;
               supplier.VAT = _SupplierVM.VAT;
               supplier.IsDeleted = false;
               _SupplierRepository.Update(supplier);
               _unitOfWork.Complete();
               return true;
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public bool DeleteSupplier(int id)
       {
           try
           {
               var supp = _SupplierRepository.GetById(id);
               supp.IsDeleted = true;
               _SupplierRepository.Update(supp);
               _unitOfWork.Complete();
               return true;
           }
           catch (Exception e)
           { throw e; }
       }
   }
}
