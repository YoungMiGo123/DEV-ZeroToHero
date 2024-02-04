namespace ZeroToHero.Collections.Console.List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListExamples
    {
        public static void EasyExample()
        {
            List<int> numbers = [1, 2, 3, 4, 5];
            Console.WriteLine("Easy List Example:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public static void MediumExample()
        {
            List<string> fruits = new List<string>() { "Apple", "Banana", "Orange" };
            Console.WriteLine("Medium List Example:");
            Console.WriteLine($"Total fruits: {fruits.Count}");
            Console.WriteLine($"First fruit: {fruits.FirstOrDefault()}");
            Console.WriteLine($"Last fruit: {fruits.LastOrDefault()}");
        }

        public static void ComplexExample()
        {
            // Real-world example: Managing a list of tasks with priority
            Console.WriteLine("Complex List Example:");
            List<TaskItem> tasks = new()
            {
                new TaskItem("Implement feature X", Priority.High),
                new TaskItem("Fix bug in module Y", Priority.Medium),
                new TaskItem("Write documentation", Priority.Low)
            };

            Console.WriteLine("Task List:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Description} - Priority: {task.TaskPriority}");
            }
        }

        public static void BuildExamples()
        {
            EasyExample();
            MediumExample();
            ComplexExample();
        }
    }
}
