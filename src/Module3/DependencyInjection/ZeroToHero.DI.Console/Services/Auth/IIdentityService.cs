namespace ZeroToHero.DI.Console.Services.Auth
{
    public interface IIdentityService
    {
        void AccessResource(string username, string role);
        void Login(string username, string password);
    }
}