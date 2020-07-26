using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using DataModel;
using BusinessEntities;
using System.Linq.Dynamic;

namespace BusinessLogic
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITypeRepository _TypeRepository;

        public TypeService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _TypeRepository = new TypeRepository(_unitOfWork);
        }


        //public List<TypeMasterVM> GetAllTypes()
        //{
        //    var typeList = _TypeRepository.GetAll(x => x.IsDeleted == false);
        //    List<TypeMasterVM> typeVMList = new List<TypeMasterVM>();
        //    foreach (var item in typeList)
        //    {
        //        TypeMasterVM typeVM = new TypeMasterVM();
        //        typeVM.Type = item.Type;
        //        typeVM.TypeId = item.TypeId;
        //        typeVMList.Add(typeVM);
        //    }
        //    return typeVMList;
        //}

        //public List<TypeMasterVM> GetAllTypes(PagingVM pageparam)
        //{
        //    PagingVM1 param = new PagingVM1();
        //    param.page = pageparam.page;
        //    param.PageSize = pageparam.pageSize;
        //    var typeList = _TypeRepository.GetAll(param, x => x.TypeId,x=>x.IsDeleted==false);

        //    List<TypeMasterVM> typeVMList = new List<TypeMasterVM>();
        //    if (typeList != null)
        //    {
        //        foreach (var item in typeList.ToList())
        //        {
        //            TypeMasterVM typeVM = new TypeMasterVM();
        //            typeVM.Type = item.Type;
        //            typeVM.TypeId = item.TypeId;
        //            typeVMList.Add(typeVM);
        //        }
        //    }
        //    return typeVMList;
        //}

        public TypeMasterVM GetByIdType(int id)
        {
            var type = _TypeRepository.GetById(id);
            TypeMasterVM typeVM = new TypeMasterVM();
            typeVM.Type = type.Type;
            typeVM.TypeId = type.TypeId;
            return typeVM;
        }

        public bool AddType(TypeMasterVM _TypeVM)
        {
            try
            {
                if (_TypeVM != null)
                {
                    tblTypeMaster _type = new tblTypeMaster();
                    _type.Type = _TypeVM.Type;
                    _type.TypeId = _TypeVM.TypeId;
                    _type.IsDeleted = false;
                    _TypeRepository.Add(_type);
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

        public bool UpdateType(TypeMasterVM _TypeVM)
        {
            try
            {
                if (_TypeVM != null)
                {
                    tblTypeMaster _type = _TypeRepository.GetById(_TypeVM.TypeId);
                    _type.Type = _TypeVM.Type;
                    _type.TypeId = _TypeVM.TypeId;
                    _type.IsDeleted = false;
                    _TypeRepository.Update(_type);
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

        public bool DeteleType(int id)
        {
            try
            {
                var type = _TypeRepository.GetById(id);
                type.IsDeleted = true;
                _TypeRepository.Update(type);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<TypeMasterVM> GetAllTypes()
        {
            throw new NotImplementedException();
        }



        public List<TypeMasterVM> GetAllTypes(PagingVM pageparam)
        {
            throw new NotImplementedException();
        }
    }
}
