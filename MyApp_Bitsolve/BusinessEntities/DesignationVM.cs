using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DesignationVM
    {
        
        public int DesignationId { get; set; }
        [Required]
        [Display(Name="Designation Name")]
        public string Name { get; set; }
    }
}
