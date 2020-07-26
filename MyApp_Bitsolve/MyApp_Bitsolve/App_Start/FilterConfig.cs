using System.Web;
using System.Web.Mvc;

namespace MyApp_Bitsolve
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}