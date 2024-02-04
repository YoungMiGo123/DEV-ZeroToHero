namespace ZeroToHero.Collections.Console.Arrays
{
    using System;
    using System.Linq;

    public class ArrayExamples
    {
        public static void EasyExample()
        {
            int[] numbers = [1, 2, 3, 4, 5];
            Console.WriteLine("Easy Array Example:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public static void MediumExample()
        {
            string[] fruits = { "Apple", "Banana", "Orange" };
            Console.WriteLine("Medium Array Example:");
            Console.WriteLine($"Total fruits: {fruits.Length}");
            Console.WriteLine($"First fruit: {fruits.FirstOrDefault()}");
            Console.WriteLine($"Last fruit: {fruits.LastOrDefault()}");
        }

        public static void ComplexExample()
        {
            // Real-world example: Analyzing sensor data
            Console.WriteLine("Complex Array Example:");
            double[] sensorData = { 23.5, 24.0, 22.8, 25.3, 24.9 };

            double averageTemperature = sensorData.Average();
            double maxTemperature = sensorData.Max();
            double minTemperature = sensorData.Min();

            Console.WriteLine($"Average Temperature: {averageTemperature}");
            Console.WriteLine($"Max Temperature: {maxTemperature}");
            Console.WriteLine($"Min Temperature: {minTemperature}");
        }

        public static void BuildExamples()
        {
            EasyExample();
            MediumExample();
            ComplexExample();
        }
    }
}
