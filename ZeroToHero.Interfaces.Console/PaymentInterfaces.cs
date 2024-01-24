namespace ZeroToHero.Interfaces.Console
{
    using System;
    public class PaymentInterfaces
    {
        
        public interface IPaymentProcessor
        {
            void ProcessPayment(decimal amount);
            bool IsPaymentSuccessful();
        }

        public class CreditCardProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                // Implement credit card payment processing logic
                Console.WriteLine($"Processing credit card payment of ${amount}");
            }

            public bool IsPaymentSuccessful()
            {
                // Implement logic to check if payment was successful
                return true;
            }
        }

        public class PayPalProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                // Implement PayPal payment processing logic
                Console.WriteLine($"Processing PayPal payment of ${amount}");
            }

            public bool IsPaymentSuccessful()
            {
                // Implement logic to check if payment was successful
                return false;
            }
        }

        public static void BuildPaymentProcessorExample()
        {
            IPaymentProcessor payment = new CreditCardProcessor();
            var paymentAmount = 100.00m;
            payment.ProcessPayment(paymentAmount);
            Console.WriteLine($"Payment {(payment.IsPaymentSuccessful() ? "was" : "was not")} successful.");

            payment = new PayPalProcessor();
            payment.ProcessPayment(paymentAmount);

            Console.WriteLine($"Payment {(payment.IsPaymentSuccessful() ? "was" : "was not")} successful.");
        }
    }
}
