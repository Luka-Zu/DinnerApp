using DinnerApp.Api.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Application.Common.Interfaces.Services;
using DinnerApp.Infrastracture.Authentication;
using DinnerApp.Infrastracture.Persistence;
using DinnerApp.Infrastracture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerApp.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastracture(this IServiceCollection services,
                                                       ConfigurationManager configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();  
        return services;
    }
}
 

