namespace ZeroToHero.DI.Console.Services.Payment;
public class PaymentService : IPaymentService
{
    private readonly ILogger _logger;

    public PaymentService(ILogger logger)
    {
        _logger = logger;
    }

    public void ProcessPayment(decimal amount)
    {
        _logger.Log($"Processing payment of ${amount}");
        // Code to process payment
    }
}
