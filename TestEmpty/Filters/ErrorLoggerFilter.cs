using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestEmpty.Filters
{
    public class ErrorLoggerFilter : HandleErrorAttribute
    {
        private ILog logger;

        public ErrorLoggerFilter()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.logger = LogManager.GetLogger("root");
        }
        public override void OnException(ExceptionContext filterContext)
        {
            logger.Error(filterContext.Exception.Message);
        }
    }
}