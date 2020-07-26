using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UnitMasterVM
    {
        public int UnitId { get; set; }
       
        [Display(Name = "Unit")]
        public string Unit { get; set; }
         [Required]
        [Display(Name = "Abbreviation")]
        public string abbreviation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
