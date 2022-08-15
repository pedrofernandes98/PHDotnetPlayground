using PHDotnetPlaygroundAPI.Models;

namespace PHDotnetPlaygroundAPI.Services.Auth
{
    public interface IJwtToken
    {
        string GenerateToken(IAuthEntity authEntity);
    }
}