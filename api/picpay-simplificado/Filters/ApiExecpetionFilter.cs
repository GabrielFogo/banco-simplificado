using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace picpay_simplificado.Filters;

public class ApiExecpetionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var exceptionMessage = exception.Message;
        var exceptionStackTrace = exception.StackTrace;
        var exceptionType = exception.GetType().Name;

        var problemDetails = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Ocorreu um problema ao tratar a sua solicitação",
            Type = exceptionType,
            Detail = exceptionMessage,
            Instance = context.HttpContext.Request.Path
        };
        
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };
    }
}