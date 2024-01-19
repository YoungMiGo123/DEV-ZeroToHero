namespace ZeroToHero.DecisionsAndIteration
{
    public class IfElseStatements
    {
        public static void Example1(int temperature)
        {
            if (temperature > 25)
            {
                Console.WriteLine("It's a hot day!");
            }
            else if (temperature > 15)
            {
                Console.WriteLine("It's a pleasant day.");
            }
            else
            {
                Console.WriteLine("It's a bit chilly.");
            }
        }

        public static void Example2(int age)
        {
            if (age >= 18)
            {
                Console.WriteLine("You are eligible to vote.");
            }
            else
            {
                Console.WriteLine("You are not eligible to vote yet.");
            }
        }
        public static void Build()
        {
            Console.WriteLine("\n-----Start IfElseStatements Examples -----\n");
            Example1(30);
            Example2(17);
            Console.WriteLine("\n-----End IfElseStatements Examples -----\n");

        }
    }

}
