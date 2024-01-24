namespace ZeroToHero.Interfaces.PracticeWithTests
{
    // CurrencyConverterExercise.cs
    using NUnit.Framework;


    /*
     Problem: Convert currency from one currency to another

         // 1 USD = 0.85 EUR
         // 1 GBP = 1.12 EUR
         // 1 USD = 0.75 GBP
         // 1 USD = 18 ZAR

    */
    public interface ICurrencyConverter
    {
        decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency);
    }

    public class CurrencyConverter : ICurrencyConverter
    {
        // Implement the method to convert currency
        public decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            // TODO: Implement currency conversion logic
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class CurrencyConverterExerciseTests
    {
        private CurrencyConverter converter;

        [SetUp]
        public void SetUp()
        {
            converter = new CurrencyConverter();
        }

        [Test]
        public void CurrencyConverter_ConvertCurrency_USD_to_EUR()
        {
            // 1 USD = 0.85 EUR
            decimal result = converter.ConvertCurrency(100, "USD", "EUR");
            Assert.That(result, Is.EqualTo(85.00).Within(0.01));
        }

        [Test]
        public void CurrencyConverter_ConvertCurrency_GBP_to_EUR()
        {
            // 1 GBP = 1.12 EUR
            decimal result = converter.ConvertCurrency(50, "GBP", "EUR");
            Assert.That(result, Is.EqualTo(56.00).Within(0.01));
        }

        [Test]
        public void CurrencyConverter_ConvertCurrency_USD_to_GBP()
        {
            // 1 USD = 0.75 GBP
            decimal result = converter.ConvertCurrency(120, "USD", "GBP");
            Assert.That(result, Is.EqualTo(90.00).Within(0.01));
        }

        [Test]
        public void CurrencyConverter_ConvertCurrency_USD_to_ZAR()
        {
            // 1 USD = 18 ZAR
            decimal result = converter.ConvertCurrency(200, "USD", "ZAR");
            Assert.That(result, Is.EqualTo(3600.00).Within(0.01));
        }
    }



}
