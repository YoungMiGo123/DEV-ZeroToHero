

namespace ZeroToHero.DI.Console.Services.Auth;

// Interface for user authentication
public interface IAuthenticationService
{
    bool Authenticate(string username, string password);
}

