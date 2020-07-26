using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using BusinessEntities;

namespace BusinessLogic
{
    public interface IMainMenuService
    {
        //List<MainMenuVM> GetAllMainMenu();
        Tuple<List<MainMenuVM>, int> GetAllMainMenu(int pageSize, int pageNum, string colSrt, string colDir, string search);
        MainMenuVM GetMainMenuById(int id);
        bool AddMainMenu(MainMenuVM _mainMenu);
        bool UpdateMainMenu(MainMenuVM _mainMenu);
        bool DeleteMainMenu(int id);
    }
}
