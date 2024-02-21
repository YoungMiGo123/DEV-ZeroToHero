

namespace ZeroToHero.DI.Console.Services.Auth;

public class AuthorizationResponse
{
    public bool IsAuthorized { get; set; }
    public string Message { get; set; }
    public string Resource { get; set; }
}
public class RoleBasedAuthorizationService : IAuthorizationService
{
    private Dictionary<string, string> _userRoles = new()
    {
        { "user1", "admin" },
        { "user2", "user" }
    };

    private Dictionary<string, string> _roleResources = new()
    {
        { "admin", "HR Payroll" },
        { "user", "Accounting Module" }
    };
    public AuthorizationResponse Authorize(string username, string resource)
    {
        var userExists = _userRoles.ContainsKey(username);
        if (!userExists)
        {
            return new AuthorizationResponse
            {
                IsAuthorized = false,
                Message = "User does not exist",
                Resource = string.Empty
            };
        }

        var role = _userRoles[username];
        var hasAccessToResource = _roleResources.ContainsKey(role) && _roleResources[role] == resource;

        return new AuthorizationResponse
        {
            IsAuthorized = hasAccessToResource,
            Message = hasAccessToResource ? $"Access granted for user '{username}' to resource '{_roleResources[role]}'" : "Unauthorized",
            Resource = hasAccessToResource ? resource : string.Empty
        };
    }


}

