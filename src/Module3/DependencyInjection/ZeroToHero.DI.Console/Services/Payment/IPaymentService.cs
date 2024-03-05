namespace ZeroToHero.DI.Console.Services.Payment
{
    public interface IPaymentService
    {
        void ProcessPayment(decimal amount);
    }
}