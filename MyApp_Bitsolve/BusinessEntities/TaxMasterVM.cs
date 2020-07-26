using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class TaxMasterVM
    {
        public int TaxId { get; set; }
        [Required]
        [Display(Name = "Tax Name")]
        public string TaxName { get; set; }

        [Required]
        [Display(Name = "Tax Value")]
        public Nullable<decimal> TaxValue { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
