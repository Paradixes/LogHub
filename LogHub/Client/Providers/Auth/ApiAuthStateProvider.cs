using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LogHub.Client.Providers.Auth;

/// <summary>
/// 
/// </summary>
public class ApiAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;

    public ApiAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _client = httpClient;
        _localStorage = localStorage;
    }

    public void MarkUserAsLoggedOut()
    {
        ClaimsPrincipal principal = new();
        var authState = Task.FromResult(new AuthenticationState(principal));
        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsAuthenticated(string token)
    {
        ClaimsPrincipal principal = new();

    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = new();
        var token = await _localStorage.GetItemAsStringAsync("token");
        if (string.IsNullOrWhiteSpace(token))
        {
            return new(principal);
        }

        // get jwt token
        JwtSecurityTokenHandler handler = new();
        var jwtToken = handler.ReadJwtToken(token);

        var claims = jwtToken.Claims;
        var identity = new ClaimsIdentity(claims, "api");
        principal.AddIdentity(identity);
        return new(principal);
    }
}
