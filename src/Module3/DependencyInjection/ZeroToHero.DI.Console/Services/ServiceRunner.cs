

namespace ZeroToHero.DI.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZeroToHero.DI.Console.Services.Auth;
using ZeroToHero.DI.Console.Services.CustomerService;
using ZeroToHero.DI.Console.Services.Payment;

public enum ServiceLifetime
{
    Singleton = 1,
    Transient = 2,
    Scoped = 3
}
public static class ServiceRunner
{
    public static void Build()
    {
        while (true)
        {
            Run();
            Console.WriteLine("Do you want to try another service lifetime? (Y/N)");
            var response = Console.ReadLine();
            if (response?.ToLower() != "y")
            {
                break;
            }
        }
    }
    private static void Run()
    {
        var serviceLifetime = GetServiceLifetime();

        var serviceProvider = serviceLifetime switch
        {
            ServiceLifetime.Transient => DIContainer.RegisterTransientServices(),
            ServiceLifetime.Scoped => DIContainer.RegisterScopedServices(),
            ServiceLifetime.Singleton => DIContainer.RegisterSingletonServices(),
            _ => throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null)
        };

        var paymentService = serviceProvider.GetService<IPaymentService>();
        paymentService.ProcessPayment(100.00m);

        var customerService = serviceProvider.GetService<ICustomerService>();
        customerService.AddCustomer("John Doe");

        var identityService = serviceProvider.GetService<IIdentityService>();
        identityService.Login("user1", "testpass@123");
        identityService.AccessResource("user1", "HR Payroll");
    }
    private static ServiceLifetime GetServiceLifetime()
    {
        Console.WriteLine("Welcome to the Dependency Injection module");
        Console.WriteLine("Please select the service lifetime: ");
        Console.WriteLine("1. Singleton");
        Console.WriteLine("2. Transient");
        Console.WriteLine("3. Scoped");
        Console.WriteLine("Enter your choice: ");
        var serviceLifetime = Console.ReadLine();
        var validChoices = new[] { "1", "2", "3" };
        while (!validChoices.Contains(serviceLifetime))
        {
            Console.WriteLine("Invalid choice. Please enter a valid choice: ");
            serviceLifetime = Console.ReadLine();
        }

        var serviceLifetimeType = (ServiceLifetime)Enum.Parse(typeof(ServiceLifetime), serviceLifetime);
        return serviceLifetimeType;
    }

}
