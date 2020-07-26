using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BidMasterVM
    {
        public long BidId { get; set; }
        [Required]
        [Display(Name = "Bid No.")]
        public string BidNo { get; set; }
        [Display(Name = "Bid Date")]
        public System.DateTime BidDate { get; set; }

        [Required]
        [Display(Name = "RFQ No.")]
        public string RFQNO { get; set; }
        [Required]
        [Display(Name = "RFQ No.")]
        public Nullable<long> RFQId { get; set; }

        [Display(Name = "RFQ Date")]
        public DateTime RFQDate { get; set; }

        [Required]
        public string supplierId { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Supplier Code")]
        public string SupplierCode { get; set; }

        public Nullable<int> BidLevelId { get; set; }

        [Display(Name = "Net Amount")]
        public decimal NetAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        public Nullable<System.DateTime> OrderDate { get; set; }
        public string CompanyName { get; set; }
        public string DeliverTo { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public Nullable<System.DateTime> BidValidUntil { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public BidDetailsVM _BidDetailsVM {get;set;}
        public List<BidDetailsVM> _BidDetailsVMList { get; set; }
    }
}
