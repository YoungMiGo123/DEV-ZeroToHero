using System.Linq;

namespace ZeroToHero.DecisionsAndIteration
{
    public class Iteration
    {
        public static void InfiniteLoopExample()
        {
            int count = 0;
            int max = 10; 
            while (true)
            {

                if (count % 2 == 0)
                {
                    Console.WriteLine($"Skipping iteration, because we reached a multiple of 2 with value ({count}) using 'continue'.");
                    count++;
                    continue;
                }
                if (count >= max)
                {
                    Console.WriteLine("Breaking out of the infinite loop.");
                    break;
                }

                Console.WriteLine($"Infinite Loop Iteration: {count}");
                count++;
            }
            Console.WriteLine();
        }

        public static void ForLoopExample()
        {
            Console.WriteLine("\n==================== Start Bubble Sort ====================\n");

            int[] array = { 5, 3, 8, 4, 2 };

            Console.WriteLine($"\nOriginal Array: [{string.Join(",", array)}]\n");
           

            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.WriteLine($"-----Start Outer Iteration: {i} ------\n");
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    Console.WriteLine($"Inner Iteration: {j}");
                    if (array[j] > array[j + 1])
                    {
                        // Swap values if they are in the wrong order
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                Console.WriteLine($"\nArray after iteration: [{string.Join(",", array)}]\n");
                Console.WriteLine($"\n-----End Outer Iteration: {i} ------\n");
            }

            Console.WriteLine($"Sorted Array: [{string.Join(",", array)}]");
            Console.WriteLine("\n==================== End Bubble Sort ====================\n");
        }

        public static void ForeachLoopExample()
        {
            string[] colors = ["Red", "Green", "Blue"];

            foreach (var color in colors)
            {
                Console.WriteLine($"Color: {color}");
            }
        }

        public static void WhileLoopExample()
        {
            int count = 0;

            while (count < 3)
            {
                Console.WriteLine($"Count: {count}");
                count++;
            }
        }

        public static void DoWhileLoopExample()
        {
            int attempts = 4;

            do
            {
                Console.WriteLine("Attempting...");
                attempts++;
            } while (attempts < 3);
        }
        public static void Build()
        {
            Console.WriteLine("\n-----Start Iteration Examples -----\n");
            InfiniteLoopExample();
            ForLoopExample();
            ForeachLoopExample();
            WhileLoopExample();
            DoWhileLoopExample();
            Console.WriteLine("\n-----End Iteration Examples -----\n");
        }
    }

}
