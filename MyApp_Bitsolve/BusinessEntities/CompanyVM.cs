using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CompanyVM
    {
        [Required]
        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }

        
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }

        [Required]
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }

        
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Telephone No")]
        public string TelephoneNo { get; set; }

        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Display(Name = "Fax")]
        public string FaxNo { get; set; }

        [Required]
        [Display(Name = "GSTIN")]
        public string GSTIN { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "Bank Account No")]
        public string BankAccountNo { get; set; }

        [Display(Name = "Bank IFSC")]
        public string BankIFSCNo { get; set; }

        
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "IsActive")]
        public Nullable<bool> IsActive { get; set; }

        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }


        public string LogoPath { get; set; }

        public string file { get; set; }

        public CompanyVM()
        {
            LogoPath = "~/ImagesData/Koala.jpg";
        }


    }
}
