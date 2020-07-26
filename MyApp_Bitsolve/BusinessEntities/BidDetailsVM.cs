using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public  class BidDetailsVM
    {
        public long BidDetailId { get; set; }
        public long BidId { get; set; }
        public long RfqDetailsId { get; set; }
        public long ItemId { get; set; }
        public string  ItemName { get; set; }
        public string HSN { get; set; }
        public string Description { get; set; }
        public string ManufacturedBy { get; set; }
        public decimal Qty { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> TaxId { get; set; }
        public string  Tax { get; set; }
        public decimal SubTotal { get; set; }
    
    }
}
