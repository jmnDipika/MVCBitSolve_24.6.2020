using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using BusinessEntities;


namespace BusinessLogic
{
   public interface ISubMenuService
    {
       List<SubMenuVM> GetAllSubMenu();
       Tuple<List<SubMenuVM>, int> GetAllSubMenu(int pageNum, int pageSize, string search, string colSort, string colDir);
       SubMenuVM GetSubMenuById(int id);
       bool AddSubMenu(SubMenuVM _sm);
       bool UpdateSubMenu(SubMenuVM sm);
       bool DeleteSubMenu(int id);
    }
}
