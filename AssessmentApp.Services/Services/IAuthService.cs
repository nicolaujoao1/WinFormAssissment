using AssessmentApp.Services.DTOs;

namespace AssessmentApp.Services.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateUser(string user, string password);
    }
}
