using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public  class PagingVM
    {
        //const int maxPageSize = 20;  
  
        //public int pageNumber { get; set; } 
  
        //public int _pageSize { get; set; }
  
        //public int pageSize  
        //{  
  
        //    get { return _pageSize; }  
        //    set  
        //    {  
        //        _pageSize = (value > maxPageSize) ? maxPageSize : value;  
        //    }  
        //}

        public int page { get; set; }
        public int pageSize { get; set; }

        public int start { get; set; }
        public int length { get; set; }
        public string SearchValue { get; set; }

        public string sortColumn { get; set; }
        public string sortColumnDir { get; set; }
    }
}
