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

        public class EFTPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                // Implement EFT payment processing logic
                Console.WriteLine($"Processing EFT payment of ${amount}");
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
            IPaymentProcessor payment = null;

            Console.WriteLine("Enter payment amount:");
            var input = Console.ReadLine();
            var validInput = decimal.TryParse(input, out var result);
            var paymentAmount = validInput ? result : 100m;

            Console.WriteLine("Which payment processor would you like to use? (1) Credit Card, (2) PayPal, (3) EFT");
            var paymentProcessor = Console.ReadLine();
            switch (paymentProcessor)
            {
                case "1":
                    payment = new CreditCardProcessor();
                    break;
                case "2":
                    payment = new PayPalProcessor();
                    break;
                case "3":
                    payment = new EFTPaymentProcessor();
                    break;
                default:
                    Console.WriteLine("Invalid payment processor selected. Using default payment processor.");
                    break;
            }
            payment.ProcessPayment(paymentAmount);
            Console.WriteLine($"Payment {(payment.IsPaymentSuccessful() ? "was" : "was not")} successful.");
            /*
            payment.ProcessPayment(paymentAmount);
            Console.WriteLine($"Payment {(payment.IsPaymentSuccessful() ? "was" : "was not")} successful.");

            payment = new PayPalProcessor();
            payment.ProcessPayment(paymentAmount);

            Console.WriteLine($"Payment {(payment.IsPaymentSuccessful() ? "was" : "was not")} successful.");

            payment = new EFTPaymentProcessor();
            payment.ProcessPayment(paymentAmount);

            Console.WriteLine($"Payment {(payment.IsPaymentSuccessful() ? "was" : "was not")} successful.");
            */
        }

    }
}
