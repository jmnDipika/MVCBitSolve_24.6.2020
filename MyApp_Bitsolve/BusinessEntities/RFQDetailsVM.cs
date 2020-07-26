using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RFQDetailsVM
    {
        public long RfqDetailsId { get; set; }

        public long RfqId { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public int ItemId { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Manufactured By")]
        public string ManufacturedBy { get; set; }

        [Required]
        [Display(Name = "Qty")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter valid Qty")]
        public decimal Qty { get; set; }

        [Required]
        [Display(Name = "Unit")]
        public int UnitId { get; set; }

        [Required]
        [Display(Name = "Price")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter valid Qty")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Tax")]
        public int TaxId { get; set; }

        [Required]
        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }

        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public string TaxName { get; set; }
    }
}
