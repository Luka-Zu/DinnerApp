using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DinnerApp.Api.Filters;
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var Exception = context.Exception;
        var ProblemDetails = new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Title = "An error occured while processing your request. ",
            Status = (int) HttpStatusCode.InternalServerError,

        };
        var ErrorResult = new { error = "An error occured while processing your request. " };

        context.Result = new ObjectResult(ProblemDetails);


        context.ExceptionHandled = true;
    }

}

