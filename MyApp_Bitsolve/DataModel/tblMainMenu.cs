//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMainMenu
    {
        public tblMainMenu()
        {
            this.tblSubMenus = new HashSet<tblSubMenu>();
        }
    
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string IconClass { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual ICollection<tblSubMenu> tblSubMenus { get; set; }
    }
}