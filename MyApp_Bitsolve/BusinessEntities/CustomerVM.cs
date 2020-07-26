using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "District")]
        public string District { get; set; }

        [Display(Name = "Pin Code")]
        [MinLength(6)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Pin Code should be numeric")]
        public string PinCode { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Required]
        [Display(Name = "MobileNo1")]
        [MinLength(10, ErrorMessage = "Minimum 10 digit required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile No should be numeric")]
        public string MobileNo1 { get; set; }

        [Display(Name = "MobileNo2")]
        [MinLength(10, ErrorMessage = "Minimum 10 digit required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile No should be numeric")]
        public string MobileNo2 { get; set; }

        [Required]
        [Display(Name = "TelePhone1")]
        public string TelePhone1 { get; set; }

        [Display(Name = "TelePhone2")]
        public string TelePhone2 { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "VAT")]
        public string VAT { get; set; }

        [Display(Name = "CST")]
        public string CST { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
