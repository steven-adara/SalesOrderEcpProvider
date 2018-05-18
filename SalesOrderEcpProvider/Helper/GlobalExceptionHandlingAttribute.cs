using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
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

            //then log errors here
            myLogger.LogError(eventId, exception, "### ==> " + exception.Message);
        }

    }
}
