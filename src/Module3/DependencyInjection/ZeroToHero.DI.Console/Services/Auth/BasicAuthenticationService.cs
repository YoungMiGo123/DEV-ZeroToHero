

namespace ZeroToHero.DI.Console.Services.Auth;

public class BasicAuthenticationService : IAuthenticationService
{
    private Dictionary<string, string> _users = new()
    {
         { "user1", "testpass@123" },
         { "user2", "passtest@321" }
    };
    public bool Authenticate(string username, string password)
    {
        return _users.ContainsKey(username) && _users[username] == password;
    }
}

