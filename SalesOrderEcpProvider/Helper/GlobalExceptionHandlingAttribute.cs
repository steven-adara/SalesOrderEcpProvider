using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kfzteile24.SalesOrderEcpProvider.Helper
{
    public class GlobalExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionHandlingAttribute> myLogger;

        public GlobalExceptionHandlingAttribute(ILogger<GlobalExceptionHandlingAttribute> logger)
        {
            this.myLogger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            //this one is invoked by every unhandled(!) exception.
            //if there are any handled exceptions like try...catch this one is not called
            var eventId = new EventId(context.Exception.HResult);
            var exception = context.Exception;
            var message = exception.GetBaseException().Message;

            context.HttpContext.Response.StatusCode = 500;

            //then log errors here
            myLogger.LogError(eventId, exception, "### ==> " + message);

            //give a description back to the client of what went wrong
            context.Result = new JsonResult(message);
        }
    }
}
