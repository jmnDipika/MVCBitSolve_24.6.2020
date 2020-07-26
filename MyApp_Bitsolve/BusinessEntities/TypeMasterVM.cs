using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class TypeMasterVM
    {
        public int TypeId { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
