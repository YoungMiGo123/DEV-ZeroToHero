

namespace ZeroToHero.DI.Console.Services.Auth;

// Interface for user authorization
public interface IAuthorizationService
{
    AuthorizationResponse Authorize(string username, string resource);
}

