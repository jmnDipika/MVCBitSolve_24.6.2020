using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic;
using BusinessEntities;
using System.Web.Mvc;


namespace MyApp_Bitsolve
{
    public static class DropDownLists
    {
        private static readonly ItemMasterSerivce _ItemService;
        static DropDownLists()
        {
            _ItemService = new ItemMasterSerivce();
        }
        //-----item list for auto complete

        public static List<SelectListItem> DDLGetItems(this BusinessDropDownList d, string itemname)
        {
            //  List<SelectListItem> ItemList = BusinessDropDownList.GetItems(itemTerm);
            return d.GetItems(itemname);
        }

        public static List<SelectListItem> DDLGetItems(this BusinessDropDownList d)
        {
            //List<SelectListItem> ItemList = BusinessDropDownList.GetItems();
            return d.GetItems();
        }

        public static List<SelectListItem> DDLGetMainMenus(this BusinessDropDownList d)
        {
           // List<SelectListItem> mainMenuList = BusinessDropDownList.GetMainMenus();
            return d.GetMainMenus();
        }

        public static List<SelectListItem> DDLGetTax(this BusinessDropDownList d)
        {
            //List<SelectListItem> TaxList = BusinessDropDownList.GetTax();
            return d.GetTax(); 
        }


        public static List<SelectListItem> DDLGetTypes(this BusinessDropDownList d)
        {
           // List<SelectListItem> TypeList = BusinessDropDownList.GetTypes();
            return d.GetTypes();
        }
        public static List<SelectListItem> DDLGetUnits(this BusinessDropDownList d)
        {
           // List<SelectListItem> UnitList = BusinessDropDownList.GetUnits();
            return d.GetUnits(); 
        }

        public static List<SelectListItem> DDLGetDept(this BusinessDropDownList d)
        {
            //List<SelectListItem> DeptList = BusinessDropDownList.GetDept();
            return d.GetDept(); 

        }
        public static List<SelectListItem> DDLGetDesignation(this BusinessDropDownList d)
        {
           // List<SelectListItem> DesList = BusinessDropDownList.GetDesignation();
            return d.GetDesignation(); 

        }

        public static List<SelectListItem> DDLGetUsers(this BusinessDropDownList d, int id)
        {
            //List<SelectListItem> userList = BusinessDropDownList.GetUsers(id);
            return d.GetUsers(id);

        }

        public static List<SelectListItem> DDLGetRoles(this BusinessDropDownList d)
        {
            //List<SelectListItem> RoleList = BusinessDropDownList.GetRoles();
            return d.GetRoles(); 

        }

        public static List<SelectListItem> DDLGetSuppliers(this BusinessDropDownList d)
        {
            //List<SelectListItem> SuppliersList = BusinessDropDownList.GetSuppliers();
            return d.GetSuppliers(); 

        }
        public static List<SelectListItem> DDLGetSuppliers(this BusinessDropDownList d,string supp)
        {
            //List<SelectListItem> SuppliersList = BusinessDropDownList.GetSuppliers(supp);
            return d.GetSuppliers(supp);

        }
        public static List<SelectListItem> DDLGetRFQNOs(this BusinessDropDownList d)
        {
            //List<SelectListItem> RFQNOsList = BusinessDropDownList.GetRFQNOs();
            return d.GetRFQNOs();

        }
        public static List<SelectListItem> DDLGetRFQNOs(this BusinessDropDownList d,int  suppid)
        {
           // List<SelectListItem> RFQNOsList = BusinessDropDownList.GetRFQNOs(suppid);
            return d.GetRFQNOs(suppid);

        }
    }
}