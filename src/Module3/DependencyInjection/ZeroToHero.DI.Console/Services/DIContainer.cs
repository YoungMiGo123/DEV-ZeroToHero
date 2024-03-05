using Microsoft.Extensions.DependencyInjection;
using ZeroToHero.DI.Console.Services.Auth;
using ZeroToHero.DI.Console.Services.CustomerService;
using ZeroToHero.DI.Console.Services.Payment;

namespace ZeroToHero.DI.Console.Services
{
    public static class DIContainer
    {
        public static IServiceProvider RegisterTransientServices()
        {
            var services = new ServiceCollection();
            // Payments 
            services.AddTransient<ILogger, FileLogger>();
            services.AddTransient<IPaymentService, PaymentService>();

            // Customer 
            services.AddTransient<IDataAccess, DatabaseAccess>();
            services.AddTransient<ICustomerService, CustomerService.CustomerService>();

            // Auth
            services.AddSingleton<IAuthenticationService, BasicAuthenticationService>();
            services.AddSingleton<IAuthorizationService, RoleBasedAuthorizationService>();
            services.AddSingleton<IIdentityService, IdentityService>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static IServiceProvider RegisterScopedServices()
        {
            var services = new ServiceCollection();
            // Payments 
            services.AddScoped<ILogger, FileLogger>();
            services.AddScoped<IPaymentService, PaymentService>();

            // Customer 
            services.AddScoped<IDataAccess, DatabaseAccess>();
            services.AddScoped<ICustomerService, CustomerService.CustomerService>();

            // Auth
            services.AddScoped<IAuthenticationService, BasicAuthenticationService>();
            services.AddScoped<IAuthorizationService, RoleBasedAuthorizationService>();
            services.AddScoped<IIdentityService, IdentityService>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static IServiceProvider RegisterSingletonServices()
        {
            var services = new ServiceCollection();
            // Payments 
            services.AddSingleton<ILogger, FileLogger>();
            services.AddSingleton<IPaymentService, PaymentService>();

            // Customer 
            services.AddSingleton<IDataAccess, DatabaseAccess>();
            services.AddSingleton<ICustomerService, CustomerService.CustomerService>();

            // Auth
            services.AddSingleton<IAuthenticationService, BasicAuthenticationService>();
            services.AddSingleton<IAuthorizationService, RoleBasedAuthorizationService>();
            services.AddSingleton<IIdentityService, IdentityService>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
