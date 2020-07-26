using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UserRoleMasterVM
    {
        public long UserRoleId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public long UserId { get; set; }
        public string UserName { get; set; }
       
        [Required]
        [Display(Name = "Role")]
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
