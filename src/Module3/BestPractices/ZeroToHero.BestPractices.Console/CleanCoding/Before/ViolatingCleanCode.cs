
namespace ZeroToHero.BestPractices.Console.CleanCoding.Before;

using System;
using System.Linq;


public class ViolatingCleanCode
{

    // Fizz Buzz Functions 
    // If its divisible by 3, print Fizz
    // If its divisible by 5, print Buzz
    // If its divisible by 8, print Zipp
    // If its divisible by 3 and 5, print FizzBuzz
    // Otherwise, print the number
    public static void FizzBuzz()
    {

        var nums = Enumerable.Range(1, 10).ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (nums[i] % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if (nums[i] % 3 == 0 && nums[i] % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
    public static void Build()
    {
        Console.WriteLine("Violating Clean Code");

        FizzBuzz();
    }

}
