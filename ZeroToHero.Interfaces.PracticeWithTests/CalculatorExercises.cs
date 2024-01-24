namespace ZeroToHero.Interfaces.PracticeWithTests
{
    using NUnit.Framework;
    using System;

    public class Exercises
    {
        /*
          Problem:
          Implement the ICalculator interface to create a simple calculator.
          The calculator should support addition, subtraction, multiplication, division, square, and power to operations.
          The result should be rounded to two decimal places.

          Example:
          var calculator = new Calculator();
          var result = calculator.Calculate(10, 5, Operation.Add); // 15.00
        */
        public interface ICalculator
        {
            double Calculate(double operand1, double operand2, Operation operation);
        }

        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Square,
            PowerTo
        }

        public class Calculator : ICalculator
        {
            public double Calculate(double operand1, double operand2, Operation operation)
            {
                throw new NotImplementedException();
            }
        }

        [TestFixture]
        public class ExerciseTests
        {
            [Test]
            public void Calculator_Calculate_Tests()
            {
                var calculator = new Calculator();

                // Addition
                Assert.That(calculator.Calculate(10, 5, Operation.Add), Is.EqualTo(15.00));

                // Subtraction
                Assert.That(calculator.Calculate(10, 5, Operation.Subtract), Is.EqualTo(5.00));

                // Multiplication
                Assert.That(calculator.Calculate(10, 5, Operation.Multiply), Is.EqualTo(50.00));

                // Division
                Assert.That(calculator.Calculate(10, 5, Operation.Divide), Is.EqualTo(2.00));

                Assert.That(calculator.Calculate(2, 2, Operation.Square), Is.EqualTo(4.00));

                Assert.That(calculator.Calculate(2, 4, Operation.PowerTo), Is.EqualTo(16.00));
                // Division by zero
                Assert.Throws<ArgumentException>(() => calculator.Calculate(10, 0, Operation.Divide));
            }
        }
    }

}
