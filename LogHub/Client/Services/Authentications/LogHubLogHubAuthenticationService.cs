using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using Client.ViewModel;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Services.Authentications;

public sealed class LogHubLogHubAuthenticationService : AuthenticationStateProvider, ILogHubAuthenticationService
{
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;

    public LogHubLogHubAuthenticationService(
        HttpClient client,
        ILocalStorageService localStorage)
    {
        _client = client;
        _localStorage = localStorage;
    }

    public async Task<bool> LogInAsync(LoginModel model)
    {
        var response = await _client.PostAsJsonAsync("api/login", model);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var token = await response.Content.ReadAsStringAsync();
        token = token.Trim('"');

        await _localStorage.SetItemAsStringAsync("token", token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        return true;
    }

    public async Task LogOutAsync()
    {
        await _localStorage.RemoveItemAsync("token");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task<bool> RegisterAsync(RegisterModel model)
    {
        var response = await _client.PostAsJsonAsync("api/users", model);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        return await LogInAsync(new LoginModel(model.Email, model.Password));
    }

    public async Task<Guid> GetUserIdAsync()
    {
        if ((await GetAuthenticationStateAsync()).User.Identity is null)
        {
            return Guid.Empty;
        }

        var claims = (await GetAuthenticationStateAsync()).User.Claims;
        return Guid.Parse(claims.First(c => c.Type == ClaimTypes.Sid).Value);
    }

    private static IEnumerable<Claim> GetClaimsFromToken(string token)
    {
        JwtSecurityTokenHandler handler = new();
        var jwtToken = handler.ReadJwtToken(token);
        return jwtToken.Claims;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = new();
        var token = await _localStorage.GetItemAsStringAsync("token");
        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(principal);
        }

        var claims = GetClaimsFromToken(token);
        var identity = new ClaimsIdentity(claims, "api", ClaimTypes.Name, ClaimTypes.Role);
        principal.AddIdentity(identity);
        return new AuthenticationState(principal);
    }
}
