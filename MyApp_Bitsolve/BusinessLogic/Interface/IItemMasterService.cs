using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Web.Mvc;

namespace BusinessLogic
{
   public   interface IItemMasterService
    {
       IEnumerable<ItemMasterVM> GetAllItems();
       ItemMasterVM GetItemById(int id);
       bool AddItem(ItemMasterVM _ItemVM);
       bool UpdateItem(ItemMasterVM _ItemVM);
       bool DeleteItem(int id);
       
    }
}
