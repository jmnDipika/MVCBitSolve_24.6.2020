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
    
    public partial class tblBidMaster
    {
        public tblBidMaster()
        {
            this.tblBidDetails = new HashSet<tblBidDetail>();
        }
    
        public long BidId { get; set; }
        public string BidNo { get; set; }
        public System.DateTime BidDate { get; set; }
        public Nullable<long> RFQId { get; set; }
        public Nullable<int> BidLevelId { get; set; }
        public string supplierId { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual ICollection<tblBidDetail> tblBidDetails { get; set; }
    }
}