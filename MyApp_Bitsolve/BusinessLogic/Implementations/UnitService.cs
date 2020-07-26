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
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _UnitRepository;
        public UnitService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _UnitRepository = new UnitRepository(_unitOfWork);
        }



        public List<UnitMasterVM> GetAllUnitsVM()
        {
            var unitList = _UnitRepository.GetAll(x => x.IsDeleted == false);
            List<UnitMasterVM> _unitVMList = new List<UnitMasterVM>();
            foreach (var item in unitList)
            {
                UnitMasterVM _unitVM = new UnitMasterVM();
                _unitVM.Unit = item.Unit;
                _unitVM.abbreviation = item.abbreviation;
                _unitVM.UnitId = item.UnitId;
                _unitVMList.Add(_unitVM);
            }
            return _unitVMList;
        }

        public UnitMasterVM GetByIdUnit(int id)
        {
            var item = _UnitRepository.GetById(id);
            UnitMasterVM _unitVM = new UnitMasterVM();
            _unitVM.Unit = item.Unit;
            _unitVM.abbreviation = item.abbreviation;
            _unitVM.UnitId = item.UnitId;
            return _unitVM;
        }

        public bool AddUnit(UnitMasterVM unitVM)
        {
            try
            {
                if (unitVM != null)
                {
                    tblUnitMaster unit = new tblUnitMaster();
                    unit.Unit = unitVM.Unit;
                    unit.UnitId = unitVM.UnitId;
                    unit.abbreviation = unitVM.abbreviation;
                    unit.IsDeleted = false;
                    _UnitRepository.Add(unit);
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

        public bool UpdateUnit(UnitMasterVM unitVM)
        {
            try
            {
                if (unitVM != null)
                {
                    tblUnitMaster unit = _UnitRepository.GetById(unitVM.UnitId);
                    unit.Unit = unitVM.Unit;
                    unit.abbreviation = unitVM.abbreviation;
                    unit.UnitId = unitVM.UnitId;
                    unit.IsDeleted = false;
                    _UnitRepository.Update(unit);
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

        public bool DeleteUnit(int id)
        {
            try
            {
                tblUnitMaster unit = _UnitRepository.GetById(id);
                unit.IsDeleted = true;
                _UnitRepository.Update(unit);
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
