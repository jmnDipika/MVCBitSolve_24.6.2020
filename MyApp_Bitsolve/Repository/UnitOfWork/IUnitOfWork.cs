using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public interface IUnitOfWork:IDisposable 
    {
        MyApp_BitSolveEntities dbContext { get; }
        void Complete();
    }
}
