using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Client.Persistence.API.Exension.ExceptionFilter
{
    internal sealed class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter>? _logger;

        public ExceptionFilter(ILogger<ExceptionFilter>? logger)
        {
            _logger = logger;
        }

        //Method of the "IExceptionFilter", which is called autometically when an unhandled exception occurs during the processing of a request.
        public void OnException(ExceptionContext context)
        {
            _logger?.LogError(context.Exception, "An unexpected exception occurred.");

            context.Result = new ObjectResult("An unexpected exception occurred!")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Value = context.Exception.Message
            };
        }
    }
}
