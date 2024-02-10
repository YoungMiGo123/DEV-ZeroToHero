
namespace ZeroToHero.BestPractices.Console.CleanCoding.Before;

using System;
using System.Linq;


public class ViolatingCleanCode
{
    public static void FizzBuzz()
    {
        var nums = Enumerable.Range(1, 200).ToArray();

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
        FizzBuzz();
    }

}
