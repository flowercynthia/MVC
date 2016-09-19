using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestEmpty.Filters
{
    public class RouteLoggerFilter : ActionFilterAttribute
    {
        private ILog logger;

        public RouteLoggerFilter()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.logger = LogManager.GetLogger("root");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];

            logger.Info(String.Format("Executed {0} action from {1} controller", action, controller));

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];

            logger.Info(String.Format("Executing {0} action from {1} controller", action, controller));
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];

            logger.Info(String.Format("Executed result {0} action from {1} controller", action, controller));
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];

            logger.Info(String.Format("Executing result {0} action from {1} controller", action, controller));
        }
    }
}