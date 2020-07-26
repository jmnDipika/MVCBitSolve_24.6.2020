using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ChangePassword
    {
        public long ChPwdId { get; set; }
        public long EmpId { get; set; }
        [Required]
        [Display(Name = "OldPassword")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "NewPassword")]
        [DataType(DataType.Password)]
        [MinLength(3)]
        public string NewPassword { get; set; }


        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage="New Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
