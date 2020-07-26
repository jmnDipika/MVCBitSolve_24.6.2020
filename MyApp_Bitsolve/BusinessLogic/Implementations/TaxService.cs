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
    public class TaxService:ITaxService
    {
         private readonly IUnitOfWork _unitOfWork;
        private readonly ITaxRepsitory _TaxRepository;

        public TaxService()
        {
            _unitOfWork = new UnitOfWork(new MyApp_BitSolveEntities());
            _TaxRepository = new TaxRepository(_unitOfWork);
        }



        public List<TaxMasterVM> GetAllTax()
        {
            var taxList = _TaxRepository.GetAll(x => x.IsDeleted == false);
            List<TaxMasterVM> taxVMList = new List<TaxMasterVM>();
            foreach (var item in taxList)
            {
                TaxMasterVM taxVM = new TaxMasterVM();
                taxVM.TaxId = item.TaxId;
                taxVM.TaxName = item.TaxName;
                taxVM.TaxValue = item.TaxValue;
                taxVM.IsActive =(bool) item.IsActive;
                taxVMList.Add(taxVM);
            }
            return taxVMList;
        }

        public TaxMasterVM GetByIdTax(int id)
        {
            var item = _TaxRepository.GetById(id);
            TaxMasterVM taxVM = new TaxMasterVM();
            taxVM.TaxId = item.TaxId;
            taxVM.TaxName = item.TaxName;
            taxVM.TaxValue = item.TaxValue;
            taxVM.IsActive = (bool)item.IsActive;
            return taxVM;
        }

        public bool AddTax(TaxMasterVM _TaxVM)
        {
            try
            {
                if (_TaxVM != null)
                {
                    tblTaxMaster _tax = new tblTaxMaster();
                    _tax.TaxId = _TaxVM.TaxId;
                    _tax.TaxName = _TaxVM.TaxName;
                    _tax.TaxValue = _TaxVM.TaxValue;
                    _tax.IsActive = (bool)_TaxVM.IsActive;
                    _tax.IsDeleted = false;
                    _TaxRepository.Add(_tax);
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool UpdateTax(TaxMasterVM _TaxVM)
        {
            try
            {
                if (_TaxVM != null)
                {
                    tblTaxMaster _tax = _TaxRepository.GetById(_TaxVM.TaxId);
                    _tax.TaxId = _TaxVM.TaxId;
                    _tax.TaxName = _TaxVM.TaxName;
                    _tax.TaxValue = _TaxVM.TaxValue;
                    _tax.IsActive = (bool)_TaxVM.IsActive;
                    _tax.IsDeleted = false;
                    _TaxRepository.Update(_tax);
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool DeteleTax(int id)
        {
            try
            {
                var tax = _TaxRepository.GetById(id);
                tax.IsDeleted = true;
                _TaxRepository.Update(tax);
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
