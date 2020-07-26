using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Repository;
using DataModel;
using System.Web.Mvc;

namespace BusinessLogic
{
    public class ItemMasterSerivce : IItemMasterService
    {
        private readonly IItemMasterRepository _ItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITypeRepository _ITypeRepository;
        private readonly IUnitRepository _IUnitRepository;
        public ItemMasterSerivce()
        {
            _unitOfWork = new UnitOfWork(new MyApp_BitSolveEntities());
            _ItemRepository = new ItemMasterRepository(_unitOfWork);
            _ITypeRepository = new TypeRepository(_unitOfWork);
            _IUnitRepository = new UnitRepository(_unitOfWork);
        }


        public IEnumerable<ItemMasterVM> GetAllItems()
        {
            try
            {
                var ItemListVM = _ItemRepository.GetAll().Where(x=>x.IsDeleted==false)
                   .Select(n => new ItemMasterVM
                {
                    BatchNo = n.BatchNo,
                    Description = n.Description,
                    HSN = n.HSN,
                    IsActive = (bool)n.IsActive,
                    ItemCode = n.ItemCode,
                    ItemId = n.ItemId,
                    ItemName = n.ItemName,
                    UOM = _IUnitRepository.GetById((long)n.UOMId).abbreviation,
                    TypeName = _ITypeRepository.GetById((long)n.TypeId).Type,
                    ManufacturedBy = n.ManufacturedBy,
                    Price = n.Price,
                    SerialNo = n.SerialNo,
                });

                return ItemListVM;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public ItemMasterVM GetItemById(int id)
        {
            ItemMasterVM ItemVM = new ItemMasterVM();
            try
            {
                var Item = _ItemRepository.GetById(id);
                if (Item != null)
                {
                    
                    ItemVM.ItemId = Item.ItemId;
                    ItemVM.ItemName = Item.ItemName;
                    ItemVM.BatchNo = Item.BatchNo;
                    ItemVM.Description = Item.Description;
                    ItemVM.HSN = Item.HSN;
                    ItemVM.IsActive = (bool)Item.IsActive;
                    ItemVM.ItemCode = Item.ItemCode;
                    ItemVM.ManufacturedBy = Item.ManufacturedBy;
                    ItemVM.Price = Item.Price;
                    ItemVM.SerialNo = Item.SerialNo;
                    ItemVM.TypeId = Item.TypeId;
                    ItemVM.UOMId = ItemVM.UOMId;
                }
                return ItemVM;
            }
            catch (Exception e) { throw e; }
        }

        public bool AddItem(ItemMasterVM _ItemVM)
        {
            try
            {
                tblItemMaster Item = new tblItemMaster();
                Item.ItemId = _ItemVM.ItemId;
                Item.ItemName = _ItemVM.ItemName;
                Item.BatchNo = _ItemVM.BatchNo;
                Item.Description = _ItemVM.Description;
                Item.HSN = _ItemVM.HSN;
                Item.IsActive = _ItemVM.IsActive;
                Item.ItemCode = _ItemVM.ItemCode;
                Item.ManufacturedBy = _ItemVM.ManufacturedBy;
                Item.Price = _ItemVM.Price;
                Item.SerialNo = _ItemVM.SerialNo;
                Item.TypeId = _ItemVM.TypeId;
                Item.UOMId = _ItemVM.UOMId;
                Item.IsDeleted = false;
                _ItemRepository.Add(Item);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                throw e;

            }

        }

        public bool UpdateItem(ItemMasterVM _ItemVM)
        {
            try
            {
                tblItemMaster Item = _ItemRepository.GetById(_ItemVM.ItemId);
                Item.ItemId = _ItemVM.ItemId;
                Item.ItemName = _ItemVM.ItemName;
                Item.BatchNo = _ItemVM.BatchNo;
                Item.Description = _ItemVM.Description;
                Item.HSN = _ItemVM.HSN;
                Item.IsActive = _ItemVM.IsActive;
                Item.ItemCode = _ItemVM.ItemCode;
                Item.ManufacturedBy = _ItemVM.ManufacturedBy;
                Item.Price = _ItemVM.Price;
                Item.SerialNo = _ItemVM.SerialNo;
                Item.TypeId = _ItemVM.TypeId;
                Item.UOMId = _ItemVM.UOMId;
                Item.IsDeleted = false;
                _ItemRepository.Update(Item);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public bool DeleteItem(int id)
        {
            try
            {
                var item = _ItemRepository.GetById(id);
                item.IsDeleted = true;
                _ItemRepository.Update(item);
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
