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
    
    public partial class tblEmployee
    {
        public long EmpId { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public string MobileNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageInBytes { get; set; }
        public string UserName { get; set; }
        public string EmpPassword { get; set; }
    }
}