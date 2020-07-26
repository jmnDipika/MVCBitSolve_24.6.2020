using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class SupplierVM
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Owner { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string TelePhone1 { get; set; }
        public string TelePhone2 { get; set; }
        public string Email { get; set; }
        public string VAT { get; set; }
        public string CST { get; set; }
        public bool IsActive { get; set; }
    }
}
