using DinnerApp.Domain.Entities;

namespace DinnerApp.Api.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
