using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Mvc5Ef6WebApiDataFirstNthW.Helpers
{
    public static class MyTracer
    {
        public static void MyTrace(TraceLevel type, Type theClass, string controllerName, string actionName, string message, Exception e)
        {
            string messageToShow;
            log4net.ILog log;
            log = log4net.LogManager.GetLogger(theClass);
            if (e != null)
            {
                messageToShow = string.Format("\tClass={0} \r\n\tController= {1} \r\n\tAction= {2} \r\n\tMessage= {3} \r\n\tGetBaseException= {4}",
                            theClass.ToString(), controllerName, actionName, message, e.GetBaseException().ToString());
            }
            else
            {
                messageToShow = string.Format("\tClass={0} \r\n\tController= {1} \r\n\tAction= {2} \r\n\tMessage= {3}",
                            theClass.ToString(), controllerName, actionName, message);
            }
            switch (type)
            {
                case TraceLevel.Info:
                    Trace.TraceInformation(messageToShow);
                    log.Info(messageToShow);
                    break;
                case TraceLevel.Error:
                    Trace.TraceError(messageToShow);
                    log.Error(messageToShow);
                    break;
                case TraceLevel.Warning:
                    Trace.TraceWarning(messageToShow);
                    log.Warn(messageToShow);
                    break;
            }
        }
    }
}