﻿using Client.ViewModel;

namespace Client.Services.Authentications;

public interface ILogHubAuthenticationService
{
    Task<bool> LogInAsync(LoginModel model);

    Task LogOutAsync();

    Task<bool> RegisterAsync(RegisterModel model);
}