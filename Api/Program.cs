using DinnerApp.Api.Errors;
using DinnerApp.Api.Filters;
using DinnerApp.Api.Middleware;
using DinnerApp.Application;
using DinnerApp.Application.Services.Authentication;
using DinnerApp.Infrastracture;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastracture(builder.Configuration);

    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, DinnerAppProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


