using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DepartVM
    {
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name="Department Name")]
        public string Name { get; set; }
    }
}
