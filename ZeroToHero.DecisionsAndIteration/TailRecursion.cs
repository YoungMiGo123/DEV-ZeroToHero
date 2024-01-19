namespace ZeroToHero.DecisionsAndIteration
{
    public class TailRecursion
    {
        public static int SumOfNumbers(List<int> numbers, int index = 0, int currentSum = 0)
        {
            if (index == numbers.Count)
            {
                return currentSum;
            }
            else
            {
                return SumOfNumbers(numbers, index + 1, currentSum + numbers[index]);
            }
        }

        public static int Factorial(int n, int result = 1)
        {
            if (n == 0)
            {
                return result;
            }
            else
            {
                return Factorial(n - 1, result * n);
            }
        }

        public static void Build()
        {
            Console.WriteLine("\n-----Start TailRecursion Examples -----\n");
            List<int> numbersForSum = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Sum of numbers: {SumOfNumbers(numbersForSum)}");

            int factorialResult = Factorial(5);
            Console.WriteLine($"Factorial of 5: {factorialResult}");
            Console.WriteLine("\n-----End TailRecursion Examples -----\n");
        }
    }

}
