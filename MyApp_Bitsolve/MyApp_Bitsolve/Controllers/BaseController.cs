using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp_Bitsolve.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILog _ILog;

        public  BaseController()
        {
            _ILog = Log.GetInstance;
        }
        //protected override void OnException(ExceptionContext fiterContext)
        //{
        //    _ILog.LogException(fiterContext.Exception.ToString());
        //    fiterContext.ExceptionHandled = true;
        //    this.View("Error").ExecuteResult(this.ControllerContext);
        //}

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };  
        }
	}
}