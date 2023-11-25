using FestivalHue2020WebAPI.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace FestivalHue2020WebAPI.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);
    }
}
