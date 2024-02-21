

namespace ZeroToHero.DI.Console.Services.Auth;
using System;

public class IdentityService(IAuthenticationService authenticationService, IAuthorizationService authorizationService) : IIdentityService
{
    private bool _authenticated;

    public void Login(string username, string password)
    {
        _authenticated = authenticationService.Authenticate(username, password);
    }

    public void AccessResource(string username, string resource)
    {
        if (!_authenticated)
        {
            Console.WriteLine("Authentication failed. Please login");
            return;
        }

        var authorizationResponse = authorizationService.Authorize(username, resource);

        if (!authorizationResponse.IsAuthorized)
        {
            Console.WriteLine(authorizationResponse.Message);
            return;
        }

        Console.WriteLine(authorizationResponse.Message);
    }
}

