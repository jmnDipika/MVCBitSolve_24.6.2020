using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public interface ITypeService
    {
        //List<TypeMasterVM> GetAllTypes();
        TypeMasterVM GetByIdType(int id);
        bool AddType(TypeMasterVM _TypeVM);
        bool UpdateType(TypeMasterVM _TypeVM);
        bool DeteleType(int id);
        List<TypeMasterVM> GetAllTypes(PagingVM pageparam);
    }
}
