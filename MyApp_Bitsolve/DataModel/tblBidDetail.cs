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
    
    public partial class tblBidDetail
    {
        public long BidDetailId { get; set; }
        public long BidId { get; set; }
        public long RfqDetailsId { get; set; }
        public long ItemId { get; set; }
        public string HSN { get; set; }
        public string Description { get; set; }
        public string ManufacturedBy { get; set; }
        public decimal Qty { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> TaxId { get; set; }
        public decimal SubTotal { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual tblBidMaster tblBidMaster { get; set; }
    }
}
