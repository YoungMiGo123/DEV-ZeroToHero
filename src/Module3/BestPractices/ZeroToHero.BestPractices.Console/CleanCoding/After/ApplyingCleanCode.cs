namespace ZeroToHero.BestPractices.Console.CleanCoding.After;

using System;
using System.Collections.Generic;
using System.Linq;

public class ApplyingCleanCode
{
    private static string MapInputToOutput(int number)
    {
        var map = new Dictionary<int, string>()
        {
            { 3, "Fizz" },
            { 5, "Buzz" }
        };
        var response = string.Empty;
        foreach (var item in map)
        {
            if (number % item.Key == 0)
            {
                response += item.Value;
            }
        }
        return response;
    }
    public static void FizzBuzz()
    {
        var range = Enumerable.Range(1, 200).ToArray();

        foreach (var currentNumber in range)
        {
            var response = MapInputToOutput(currentNumber);
            var result = string.IsNullOrEmpty(response) ? currentNumber.ToString() : response;
            Console.WriteLine(result);
        }
    }

    public static void Build()
    {
        FizzBuzz();
    }
}
