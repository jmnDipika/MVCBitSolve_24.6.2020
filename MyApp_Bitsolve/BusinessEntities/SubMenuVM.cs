using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class SubMenuVM
   {
       public int SubMenuId { get; set; }
       public int MenuId { get; set; }
       public string MenuName { get; set; }
       [Required]
       [Display(Name="Sub Menu")]
       public string SubMenuName { get; set; }
       [Required]
       [Display(Name="Controller Name")]
       public string ControllerName { get; set; }
       [Required]
       [Display(Name = "Action Name")]
       public string ActionName { get; set; }
       public Nullable<bool> isActive { get; set; }

       [Display(Name = "Icon Class")]
       public string IconClass { get; set; }
       public Nullable<System.DateTime> CreatedDate { get; set; }
       public Nullable<int> CreatedBy { get; set; }
       [Display(Name = "Created By")]
       public string CreatedByname { get; set; }
       public Nullable<System.DateTime> ModifiedDate { get; set; }
       public Nullable<int> ModifiedBy { get; set; }
       [Display(Name = "Modified By")]
       public string ModifiedByname { get; set; }
    }
}
