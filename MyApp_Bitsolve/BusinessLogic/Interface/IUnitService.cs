using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public interface IUnitService
    {
         List<UnitMasterVM> GetAllUnitsVM();
         UnitMasterVM GetByIdUnit(int id);
         bool AddUnit(UnitMasterVM unitVM);
         bool UpdateUnit(UnitMasterVM unitVM);
         bool DeleteUnit(int id);
    }
}
