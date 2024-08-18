using AssessmentApp.Services.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace AssessmentApp.Services.Services;
    public class AuthService : IAuthService
{
    private readonly HttpClient _client;
    private const string AuthUrl = "https://test-api-y04b.onrender.com/signIn";

    public AuthService(HttpClient client)
    {
        _client = client;
    }

    public async Task<AuthResponse> AuthenticateUser(string user, string password)
    {
        var payload = new
        {
            user,
            password
        };

        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(AuthUrl, content);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<AuthResponse>(jsonResponse)!;
    }
}
