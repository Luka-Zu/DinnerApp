using Contracts.Authentication;
using DinnerApp.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;


[ApiController]
[Route("Auth")]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        var Result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var Response = new AuthenticationResponse(
            Result.User.Id,
            Result.User.FirstName,
            Result.User.LastName,
            Result.User.Email,
            Result.Token
            );
        return Ok(Response);
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult Login(LoginRequest request) 
    {
        var Result = _authenticationService.Login(request.Email, request.Password);
        var Response = new AuthenticationResponse(
            Result.User.Id,
            Result.User.FirstName,
            Result.User.LastName,
            Result.User.Email,
            Result.Token
            );


        return Ok(Result);
    }        
}

