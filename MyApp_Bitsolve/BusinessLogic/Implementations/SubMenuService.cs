using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BusinessEntities;
using Repository;
using System.Web;
using System.Data.SqlClient;
using System.Linq.Dynamic;

namespace BusinessLogic
{
    public  class SubMenuService : ISubMenuService
    {
        private readonly ISubMenuRepository _subMResp;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainMenuRepository _mainMResp;
        private readonly IEmployeeRepository _empResp;
        //------------singeton eg----------------------------
        //private static readonly Lazy<SubMenuService> subMenuInstance=new Lazy< SubMenuService>(()=>new SubMenuService());
        //public static SubMenuService GetInstance
        //{
        //    get {  return subMenuInstance.Value; }
        //}
        //------------singeton eg----------------------------

        public SubMenuService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _subMResp = new SubMenuRepository(_unitOfWork);
            _mainMResp = new MainMenuRepository(_unitOfWork);
            _empResp = new EmployeeRepository(_unitOfWork);
        }
        public List<SubMenuVM> GetAllSubMenu()
        { var SubMenuList = new List<SubMenuVM>();
        if (HttpContext.Current.Session["User"] != null)
        {
            var user = (LoginVM)HttpContext.Current.Session["User"];

            SubMenuList = _subMResp.GetAll().Select(x => new SubMenuVM
           {
               ActionName = x.ActionName,
               ControllerName = x.ControllerName,
               isActive = (bool)x.isActive,
               MenuId = x.MenuId,
               MenuName = _mainMResp.GetById(x.MenuId).MenuName,
               SubMenuId = x.SubMenuId,
               SubMenuName = x.SubMenuName,
               IconClass = x.IconClass,
               CreatedByname = _empResp.GetById((long)x.CreatedBy).FirstName,
               ModifiedByname = _empResp.GetById((long)x.CreatedBy).FirstName,
               CreatedDate = x.CreatedDate,
               ModifiedDate = x.ModifiedDate
           }).ToList();
        }
        return SubMenuList;

        }

        public Tuple<List<SubMenuVM>,int> GetAllSubMenu(int pageNum, int pageSize, string search, string sortCol, string sortDir )
        {
            try
            {
                List<SubMenuVM> SubMenuList = null; int recordsTotal = 0;
                if (HttpContext.Current.Session["User"] != null)
                {
                    var user = (LoginVM)HttpContext.Current.Session["User"];

                    //SqlParameter[] param =new SqlParameter[]{
                    //new SqlParameter("@PageNum",pageNum),
                    //new SqlParameter("@PageSize",pageSize),
                    //new SqlParameter("@SortCol",sortCol),
                    //new SqlParameter("@SortDir",sortDir),
                    //new SqlParameter("@Search", search??(object)DBNull.Value)
                    //};

                    //var   SubMenuList = _subMResp.GetAll("SP_SubMenu @PageNum=@pageNum,@PageSize=@pageSize,@SortCol=@sortCol,@SortDir=@sortDir,@Search=@search ", param).ToList();

                    SubMenuList=_subMResp.GetAll(x=>x.isActive==true)
                        .Select (x => new SubMenuVM
                        {
                            SubMenuId = x.SubMenuId,
                       ActionName = x.ActionName,
                       ControllerName = x.ControllerName,
                       isActive = (bool)x.isActive,
                       MenuName = _mainMResp.GetById(x.MenuId).MenuName,
                       SubMenuName = x.SubMenuName,
                       IconClass = x.IconClass,
                       CreatedByname = _empResp.GetById((long)x.CreatedBy).FirstName,
                       ModifiedByname = _empResp.GetById((long)x.CreatedBy).FirstName,
                       CreatedDate = x.CreatedDate,
                       ModifiedDate = x.ModifiedDate
                   }).ToList();
                    if (!string.IsNullOrEmpty(search))
                   {
                       SubMenuList = SubMenuList.Where(x => x.ActionName != null && x.ActionName.ToLower().Contains(search.ToLower())
                           || x.ControllerName!=null && x.ControllerName.ToLower().Contains(search.ToLower())
                           || x.CreatedByname!=null && x.CreatedByname.ToLower().Contains(search.ToLower())
                           || x.CreatedDate!=null && x.CreatedDate.ToString().Contains(search)
                           || x.IconClass!=null &&  x.IconClass.ToLower().Contains(search.ToLower())
                           || x.MenuName!=null && x.MenuName.ToLower().Contains(search.ToLower())
                           || x.ModifiedByname!=null && x.ModifiedByname.ToString().Contains(search.ToLower())
                           || x.SubMenuName!=null && x.SubMenuName.ToLower().Contains(search.ToLower())
                           
                           ).ToList();
                   }
                     recordsTotal = SubMenuList.Count();
                     SubMenuList = SubMenuList.OrderBy(sortCol + " " + sortDir).Skip(pageNum).Take(pageSize).ToList();
                  
                }
                return new Tuple<List<SubMenuVM>,int>(SubMenuList, recordsTotal);
            }
            catch (Exception e) { throw e; }
        }



        public SubMenuVM GetSubMenuById(int id)
        {
            try
            {
                var SubMenu = _subMResp.GetById(id);
                SubMenuVM smVM = new SubMenuVM();
                if (SubMenu != null)
                {
                    smVM.ActionName = SubMenu.ActionName;
                    smVM.ControllerName = SubMenu.ControllerName;
                    smVM.isActive = SubMenu.isActive;
                    smVM.MenuId = SubMenu.MenuId;
                    smVM.SubMenuId = SubMenu.SubMenuId;
                    smVM.SubMenuName = SubMenu.SubMenuName;
                    smVM.IconClass = SubMenu.IconClass;
                }
                return smVM;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AddSubMenu(SubMenuVM SubMenu)
        {
            try
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    var user = (LoginVM)HttpContext.Current.Session["User"];
                    tblSubMenu sm = new tblSubMenu();
                    sm.ActionName = SubMenu.ActionName;
                    sm.ControllerName = SubMenu.ControllerName;
                    sm.isActive = SubMenu.isActive;
                    sm.MenuId = SubMenu.MenuId;
                    sm.SubMenuName = SubMenu.SubMenuName;
                    sm.IconClass = SubMenu.IconClass;
                    sm.CreatedBy =user.RoleId;
                    sm.ModifiedBy=user.RoleId;
                    sm.CreatedDate = System.DateTime.Now;
                    sm.ModifiedDate = System.DateTime.Now;
                    _subMResp.Add(sm);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception e) { return false; }
        }

        public bool UpdateSubMenu(SubMenuVM SubMenu)
        {
            try
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    var user = (LoginVM)HttpContext.Current.Session["User"];
                    tblSubMenu sm = _subMResp.GetById(SubMenu.SubMenuId);
                    sm.ActionName = SubMenu.ActionName;
                    sm.ControllerName = SubMenu.ControllerName;
                    sm.isActive = SubMenu.isActive;
                    sm.MenuId = SubMenu.MenuId;
                    sm.SubMenuName = SubMenu.SubMenuName;
                    sm.IconClass = SubMenu.IconClass;
                    sm.ModifiedBy = user.RoleId;
                    sm.ModifiedDate = System.DateTime.Now;
                    _subMResp.Update(sm);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception e) { return false; }
        }

        public bool DeleteSubMenu(int id)
        {
            throw new NotImplementedException();
        }
    }
}
