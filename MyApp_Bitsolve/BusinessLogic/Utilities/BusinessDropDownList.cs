using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogic
{
    public  class BusinessDropDownList
    {
        //----item .list for auto complete-----

        public  List<SelectListItem> GetItems(string itemTerm)
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var Items = db.tblItemMasters.Where(x => x.IsDeleted == false && x.IsActive == true
                    && x.ItemName.Contains(itemTerm)).Select(x => new { x.ItemId, x.ItemName }).ToList();
                List<SelectListItem> ItemsList = new List<SelectListItem>();
                foreach (var t in Items)
                {
                    ItemsList.Add(new SelectListItem
                    {
                        Value = t.ItemId.ToString(),
                        Text = t.ItemName,
                    });
                }
                return ItemsList;
            }
        }

        public  List<SelectListItem> GetItems()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var Items = db.tblItemMasters.Where(x => x.IsDeleted == false && x.IsActive == true)
                    .Select(x => new { x.ItemId, x.ItemName }).ToList();
                List<SelectListItem> ItemsList = new List<SelectListItem>();
                foreach (var t in Items)
                {
                    ItemsList.Add(new SelectListItem
                    {
                        Value = t.ItemId.ToString(),
                        Text = t.ItemName,
                    });
                }
                return ItemsList;
            }
        }

        public  List<SelectListItem> GetMainMenus()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var menu = db.tblMainMenus.Where(x => x.isActive == true).Select(x => new { x.MenuId, x.MenuName }).ToList();
                List<SelectListItem> menulist = new List<SelectListItem>();
                foreach (var t in menu)
                {
                    menulist.Add(new SelectListItem
                    {
                        Value = t.MenuId.ToString(),
                        Text = t.MenuName,
                    });
                }
                return menulist;
            }
        }


        public  List<SelectListItem> GetTax()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var Tax = db.tblTaxMasters.Where(x => x.IsDeleted == false && x.IsActive == true)
                    .Select(x => new { x.TaxId, x.TaxName }).ToList();
                List<SelectListItem> TaxList = new List<SelectListItem>();
                foreach (var t in Tax)
                {
                    TaxList.Add(new SelectListItem
                    {
                        Value = t.TaxId.ToString(),
                        Text = t.TaxName,
                    });
                }
                return TaxList;
            }
        }



        public  List<SelectListItem> GetTypes()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var type = db.tblTypeMasters.Where(x => x.IsDeleted == false).Select(
                x => new { x.TypeId, x.Type }).ToList();
                List<SelectListItem> TypeList = new List<SelectListItem>();
                foreach (var t in type)
                {
                    TypeList.Add(new SelectListItem
                    {
                        Value = t.TypeId.ToString(),
                        Text = t.Type
                    });
                }
                return TypeList;
            }
        }

        public  List<SelectListItem> GetUnits()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var units = db.tblUnitMasters.Where(x => x.IsDeleted == false).Select(
                x => new { x.UnitId, x.abbreviation }).ToList();
                List<SelectListItem> unitsList = new List<SelectListItem>();
                foreach (var u in units)
                {
                    unitsList.Add(new SelectListItem
                    {
                        Value = u.UnitId.ToString(),
                        Text = u.abbreviation
                    });
                }
                return unitsList;
            }
        }

        public  List<SelectListItem> GetDept()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var depts = db.tblDepartments.Select(x => new { x.DepartmentId, x.Name }).ToList();
                List<SelectListItem> deptsLits = new List<SelectListItem>();
                foreach (var u in depts)
                {
                    deptsLits.Add(new SelectListItem
                    {
                        Value = u.DepartmentId.ToString(),
                        Text = u.Name
                    });
                }
                return deptsLits;
            }
        }

        public  List<SelectListItem> GetDesignation()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var designation = db.tblDesignations.Select(x => new { x.DesignationId, x.Name }).ToList();
                List<SelectListItem> designationLits = new List<SelectListItem>();
                foreach (var u in designation)
                {
                    designationLits.Add(new SelectListItem
                    {
                        Value = u.DesignationId.ToString(),
                        Text = u.Name
                    });
                }
                return designationLits;
            }
        }


        public  List<SelectListItem> GetRoles()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var roles = db.tblRoleMasters.Select(x => new { x.RoleId, x.RoleName }).ToList();
                List<SelectListItem> roleList = new List<SelectListItem>();
                foreach (var u in roles)
                {
                    roleList.Add(new SelectListItem
                    {
                        Value = u.RoleId.ToString(),
                        Text = u.RoleName
                    });
                }
                return roleList;
            }
        }

        public  List<SelectListItem> GetSuppliers()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var Suppliers = db.tblSuppliers.Where(x => x.IsDeleted == false && x.IsActive == true)
                    .Select(x => new { x.SupplierId, x.SupplierName }).ToList();
                List<SelectListItem> SuppliersList = new List<SelectListItem>();
                foreach (var u in Suppliers)
                {
                    SuppliersList.Add(new SelectListItem
                    {
                        Value = u.SupplierId.ToString(),
                        Text = u.SupplierName
                    });
                }
                return SuppliersList;
            }
        }

        public  List<SelectListItem> GetSuppliers(string supp)
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var Suppliers = db.tblSuppliers.Where(x => x.IsDeleted == false && x.IsActive == true &&
                    x.SupplierName.Contains(supp)).Select(x => new { x.SupplierId, x.SupplierName }).ToList();
                List<SelectListItem> SuppliersList = new List<SelectListItem>();
                foreach (var u in Suppliers)
                {
                    SuppliersList.Add(new SelectListItem
                    {
                        Value = u.SupplierId.ToString(),
                        Text = u.SupplierName
                    });
                }
                return SuppliersList;
            }
        }

        public  List<SelectListItem> GetUsers(int id)
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var _userList = db.tblEmployees.Where(x => x.IsActive == true && x.IsDeleted == false
                    && x.UserName != null).Select(x => new { x.EmpId, x.UserName }).ToList();
                List<SelectListItem> UserList = new List<SelectListItem>();
                if (id == 0)
                {
                    var _userRoleList = db.UserRoleMasters.Select(x => x.UserId).ToList();
                    var result = (from u in _userList where !_userRoleList.Contains(u.EmpId) select u).ToList();
                    foreach (var u in result)
                    {
                        UserList.Add(new SelectListItem
                        {
                            Value = u.EmpId.ToString(),
                            Text = u.UserName
                        });
                    }
                }
                else
                {
                    foreach (var u in _userList)
                    {
                        UserList.Add(new SelectListItem
                        {
                            Value = u.EmpId.ToString(),
                            Text = u.UserName
                        });
                    }
                }

                return UserList;
            }
        }


        public  List<SelectListItem> GetRFQNOs()
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                var RFQNOs = db.tblRFQs.Where(x => x.isDeleted == false).Select(x => new { x.RfqId, x.RfqNo }).ToList();
                List<SelectListItem> RFQNOsList = new List<SelectListItem>();
                foreach (var u in RFQNOs)
                {
                    RFQNOsList.Add(new SelectListItem
                    {
                        Value = u.RfqId.ToString(),
                        Text = u.RfqNo
                    });
                }
                return RFQNOsList;
            }
        }

        public  List<SelectListItem> GetRFQNOs(int suppid)
        {
            using (MyApp_BitSolveEntities db = new MyApp_BitSolveEntities())
            {
                string id = suppid.ToString();
                var RFQNOs = db.tblRFQs.Where(x => x.isDeleted == false && x.SupplierId.Contains(id))
                    .Select(x => new { x.RfqId, x.RfqNo }).ToList();
                List<SelectListItem> RFQNOsList = new List<SelectListItem>();
                foreach (var u in RFQNOs)
                {
                    RFQNOsList.Add(new SelectListItem
                    {
                        Value = u.RfqId.ToString(),
                        Text = u.RfqNo
                    });
                }
                return RFQNOsList;
            }
        }


    }
}
