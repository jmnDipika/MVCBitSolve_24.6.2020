using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class MainMenuVM
    {
        public int MenuId { get; set; }
        [Required]
        [Display(Name="Menu Name")]
        public string MenuName { get; set; }
        public Nullable<bool> isActive { get; set; }
        [Required]
        [Display(Name = "Icon Class")]
        public string IconClass { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        [Display(Name="Created By")]
        public string CreatedByname { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedByname { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
