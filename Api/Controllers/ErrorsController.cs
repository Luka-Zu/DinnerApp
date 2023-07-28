using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;



public class ErrorsController : ControllerBase
{

    [Route("/error")]
    public IActionResult Error()
    {
        Exception? Exc = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;


        return Problem(title: Exc?.Message);
    }

}