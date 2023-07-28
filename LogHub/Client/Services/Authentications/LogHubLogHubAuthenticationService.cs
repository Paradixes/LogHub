using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using LogHub.Client.ViewModel;
using Microsoft.AspNetCore.Components.Authorization;

namespace LogHub.Client.Services.Authentications;

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
        // query account info from the server
        var response = await _client.PostAsJsonAsync("api/users/login", model);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        response.EnsureSuccessStatusCode();

        var token = await response.Content.ReadAsStringAsync();
        token = token.Trim('"');

        // store token
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
        var response = await _client.PostAsJsonAsync("api/users/register", model);
        return response.IsSuccessStatusCode;
    }

    private IEnumerable<Claim> GetClaimsFromToken(string token)
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
        var identity = new ClaimsIdentity(claims, "api");
        principal.AddIdentity(identity);
        return new AuthenticationState(principal);
    }
}
