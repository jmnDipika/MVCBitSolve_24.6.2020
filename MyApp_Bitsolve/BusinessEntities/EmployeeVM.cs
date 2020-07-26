using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessEntities
{
    public class EmployeeVM
    {
        public long EmpId { get; set; }
        [Required]
        [Display(Name = "Employee No")]
        public string EmployeeNo { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Display(Name = "Designation")]
        public Nullable<int> DesignationId { get; set; }

        [Display(Name = "Deptartment")]
        public Nullable<int> DeptId { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        //[MinLength(10, ErrorMessage = "Minmum 10 digit required.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid Mobile No")]
        public string MobileNo { get; set; }


        [Display(Name = "Fax")]
        public string Fax { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [MaxLength(500)]
        public string Address { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        [Display(Name = "Profile Image")]
        public string ImageName { get; set; }
        public byte[] ImageInBytes { get; set; }

       
        [Display(Name = "User Name")]
        public string UserName { get; set; }

      
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(3)]
        public string EmpPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("EmpPassword", ErrorMessage = "Password do not matched.")]
        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase file { get; set; }

        public EmployeeVM()
        {
            ImageName = "user.png";
        }
    }
}
