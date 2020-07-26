using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RFQVM
    {
        public long RfqId { get; set; }

        [Required]
        [Display(Name = "RFQ No")]
        public string RfqNo { get; set; }

        [Required]
        [Display(Name = "RFQ Date")]
        public Nullable<System.DateTime> RfqDate { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public string SupplierId { get; set; }
        [Display(Name = "Supplier")]
        public string SupplierName { get; set; }
        public string hdnSupplierIds { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> OrderDate { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Deliver To")]
        public string DeliverTo { get; set; }


        [Display(Name = "Schedule Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ScheduleDate { get; set; }


        [Display(Name = "Bid Valid Until")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> BidValidUntil { get; set; }


        [Display(Name = "Total Amount")]
        public Nullable<decimal> TotalAmount { get; set; }


        public Nullable<System.DateTime> CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public int createdBy { get; set; }

        [Display(Name = "Created By")]
        public string createdByName { get; set; }

        [Display(Name = "Modified By")]
        public int ModifiedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public bool IsEmailSent { get; set; }

        public RFQDetailsVM _RFQDetailsVM { get; set; }
        [Required(ErrorMessage="At least one record required")]
        public List<RFQDetailsVM> _RFQDetailsVMList { get; set; }
    }
}
