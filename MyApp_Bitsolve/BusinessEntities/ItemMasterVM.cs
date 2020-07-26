using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ItemMasterVM
    {
        public int ItemId { get; set; }
        [Required]
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        public Nullable<int> TypeId { get; set; }
         [Display(Name = "Type Name")]
        public string TypeName { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public Nullable<int> UOMId { get; set; }

        public string UOM { get; set; }

        [Display(Name = "Price")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Display(Name = "Manufactured By")]
        public string ManufacturedBy { get; set; }

        [Display(Name = "Serial No")]
        public string SerialNo { get; set; }

        [Display(Name = "Batch No")]
        public string BatchNo { get; set; }

        [Display(Name = "HSN")]
        public string HSN { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
