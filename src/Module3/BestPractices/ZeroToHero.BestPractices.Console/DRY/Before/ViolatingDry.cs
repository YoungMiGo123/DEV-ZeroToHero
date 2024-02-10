namespace ZeroToHero.BestPractices.Console.DRY.Before;

using System;
public class Calculator
{
    public int Add(int a, int b)
    {
        Console.WriteLine($"Adding {a} and {b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        Console.WriteLine($"Subtracting {b} from {a}");
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        Console.WriteLine($"Multiplying {a} by {b}");
        return a * b;
    }
}
public class ViolatingDry
{
    public static void Build()
    {
        var calculator = new Calculator();

        int result1 = calculator.Add(5, 3);
        Console.WriteLine($"Result: {result1}");

        int result2 = calculator.Subtract(10, 7);
        Console.WriteLine($"Result: {result2}");

        int result3 = calculator.Multiply(4, 6);
        Console.WriteLine($"Result: {result3}");
    }
}
