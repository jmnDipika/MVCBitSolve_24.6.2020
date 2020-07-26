using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public sealed class Log : ILog
    {
        private Log()
       { 
       
       }
       private static readonly Lazy<Log> LogInstance = new Lazy<Log>(() => new Log());
       public static Log GetInstance
        {
            get { return LogInstance.Value; }
        }

       public void LogException(string message)
       {
           
       }
    }
}
