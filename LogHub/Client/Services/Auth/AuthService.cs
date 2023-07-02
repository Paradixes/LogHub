﻿using Blazored.LocalStorage;
using LogHub.Client.Providers.Auth;
using LogHub.Shared.ViewModel;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace LogHub.Client.Services.Auth;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;
    private readonly AuthenticationStateProvider _provider;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient client, AuthenticationStateProvider provider, ILocalStorageService localStorage)
    {
        _client = client;
        _provider = provider;
        _localStorage = localStorage;
    }

    public virtual async Task SignInAsync(LoginViewModel model)
    {
        // query account info from the server
        var response = await _client.PostAsJsonAsync("API/Account", model);
        response.EnsureSuccessStatusCode();
        var token = await response.Content.ReadAsStringAsync();

        // store token
        await _localStorage.SetItemAsStringAsync("token", token);
    }

    public virtual async Task SignOutAsync()
    {
        await _localStorage.RemoveItemAsync("token");
        ((ApiAuthStateProvider)_provider).MarkUserAsLoggedOut();
        _client.DefaultRequestHeaders.Authorization = null;
    }
}
