using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LogHub.Client.Providers.Auth;

public class ApiAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;

    public ApiAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _client = httpClient;
        _localStorage = localStorage;
    }

    private static IEnumerable<Claim> GetClaimsFromToken(string token)
    {
        JwtSecurityTokenHandler handler = new();
        var jwtToken = handler.ReadJwtToken(token);
        return jwtToken.Claims;
    }

    public async Task NotifyAuthenticationStateChangedAsync()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = new();
        var token = await _localStorage.GetItemAsStringAsync("token");
        if (string.IsNullOrWhiteSpace(token))
        {
            return new(principal);
        }
        var claims = GetClaimsFromToken(token);
        var identity = new ClaimsIdentity(claims, "api");
        principal.AddIdentity(identity);
        return new(principal);
    }
}
