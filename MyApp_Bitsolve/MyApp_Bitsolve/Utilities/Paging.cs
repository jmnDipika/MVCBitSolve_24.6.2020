using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace MyApp_Bitsolve
{
    public  class Paging
    {
        public object draw {get; set;}
        public int pageNum  {get; set;}
        public int pageSize  {get; set;}
        public string colSort {get; set;}
        public string colDir  {get; set;}
        public string search { get; set; }
        
    }

    
     public static class Pager 
    {
         public static Paging pager()
         {
             Paging p = new Paging();
             
                 p.draw = HttpContext.Current.Request.Form.GetValues("draw").FirstOrDefault();
             p.pageNum = Convert.ToInt32(HttpContext.Current.Request["start"]);
             p.pageSize = Convert.ToInt32(HttpContext.Current.Request["length"]);
             p.colSort = HttpContext.Current.Request.Form.GetValues("columns[" + HttpContext.Current.Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
             p.colDir = HttpContext.Current.Request.Form.GetValues("order[0][dir]").FirstOrDefault();
             p.search = HttpContext.Current.Request["search[value]"] == "" ? null : HttpContext.Current.Request["search[value]"];
             return p;
         }
    }
}