using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
    public class MainMenuRepository : BaseRepository<tblMainMenu>, IMainMenuRepository
    {
        public MainMenuRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork) { }
    }
}
