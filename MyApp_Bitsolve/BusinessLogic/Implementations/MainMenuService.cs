using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Repository;
using DataModel;
using System.Web;
using System.Linq.Dynamic;

namespace BusinessLogic
{
    public class MainMenuService : IMainMenuService
    {
        private readonly IMainMenuRepository _mainMenuResp;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _empres;
        public MainMenuService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _mainMenuResp = new MainMenuRepository(_unitOfWork);
            _empres=new EmployeeRepository(_unitOfWork);
        }

        public Tuple< List<MainMenuVM>,int> GetAllMainMenu(int pageSize,int pageNum,string colSrt,string colDir,string search)
        {
            try
            {
                int recordsTotal = 0;
                var mainMenuList = _mainMenuResp.GetAll().Where(x=>x.isActive==true).Select(x => new MainMenuVM
                {
                    MenuId = x.MenuId,
                    MenuName = x.MenuName,
                    isActive = (bool)x.isActive,
                    IconClass=x.IconClass,
                    CreatedDate=x.CreatedDate,
                    CreatedByname=_empres.GetById((long)x.CreatedBy).FirstName,
                    ModifiedDate=x.ModifiedDate,
                    ModifiedByname=_empres.GetById((long)x.ModifiedBy).FirstName

                }).ToList();

                if (!string.IsNullOrEmpty(search))
                { 
                mainMenuList=mainMenuList.Where(x=>x.MenuName!=null && x.MenuName.ToLower().Contains(search.ToLower())
                    || x.IconClass!=null && x.IconClass.ToLower().Contains(search.ToLower())
                    || x.CreatedDate !=null && x.CreatedDate.ToString().Contains(search)
                    || x.CreatedByname!=null && x.CreatedByname.ToLower().Contains(search.ToLower())
                    || x.ModifiedDate !=null && x.ModifiedDate.ToString().Contains(search)
                    || x.ModifiedByname != null && x.ModifiedByname.ToString().Contains(search.ToLower())).ToList();
                }
                recordsTotal = mainMenuList.Count();
                mainMenuList = mainMenuList.OrderBy(colSrt + " " + colDir).Skip(pageNum).Take(pageSize).ToList();
                return new Tuple<List<MainMenuVM>, int>(mainMenuList, recordsTotal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MainMenuVM GetMainMenuById(int id)
        {
            try
            {
                var mainMenu = _mainMenuResp.GetById(id);
                MainMenuVM _mmVM = new MainMenuVM();
                if (mainMenu != null)
                {
                    _mmVM.MenuId = mainMenu.MenuId;
                    _mmVM.MenuName = mainMenu.MenuName;
                    _mmVM.isActive = mainMenu.isActive;
                    _mmVM.IconClass = mainMenu.IconClass;
                }
                return _mmVM;

            }
            catch (Exception e) { throw e; }
        }

        public bool AddMainMenu(MainMenuVM _mainMenu)
        {
            try
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    var user = (LoginVM)HttpContext.Current.Session["User"];
                    
                    var mm = new tblMainMenu();
                    mm.MenuName = _mainMenu.MenuName;
                    mm.isActive = _mainMenu.isActive;
                    mm.IconClass = _mainMenu.IconClass;
                    mm.CreatedDate = System.DateTime.Now;
                    mm.ModifiedDate = System.DateTime.Now;
                    mm.CreatedBy = user.RoleId;
                    mm.ModifiedBy = user.RoleId;
                    _mainMenuResp.Add(mm);
                    _unitOfWork.Complete();
                    return true;
                }
                else return false;
            }
            catch (Exception e) { return false; }
        }

        public bool UpdateMainMenu(MainMenuVM _mainMenu)
        {
            try
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    var user = (LoginVM)HttpContext.Current.Session["User"];

                    var mm = _mainMenuResp.GetById(_mainMenu.MenuId);
                    if (mm != null)
                    {
                        mm.MenuName = _mainMenu.MenuName;
                        mm.isActive = _mainMenu.isActive;
                        mm.IconClass = _mainMenu.IconClass;
                        mm.ModifiedDate = System.DateTime.Now;
                        mm.ModifiedBy = user.RoleId;
                        _mainMenuResp.Update(mm);
                        _unitOfWork.Complete();
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception e) { return false; }
        }

        public bool DeleteMainMenu(int id)
        {
            try
            {
                var mm = _mainMenuResp.GetById(id);
                if (mm != null)
                {
                    mm.isActive = false;
                    _mainMenuResp.Update(mm);
                    _unitOfWork.Complete();
                }
                return true;
            }
            catch (Exception e) { return false; }
        }

       
    }
}
