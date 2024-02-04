namespace ZeroToHero.Collections.Console.Dictionary
{
    using System;
    using System.Collections.Generic;


    public class DictionaryExamples
    {
        public static void EasyExample()
        {
            Dictionary<int, string> employeeNames = new()
            {
                { 1, "John" },
                { 2, "Alice" },
                { 3, "Bob" }
            };

            Console.WriteLine("Easy Dictionary Example:");
            foreach (var kvp in employeeNames)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
            }
        }

        public static void MediumExample()
        {
            Dictionary<string, int> wordOccurrences = new();
            string[] words = { "apple", "banana", "apple", "orange", "banana", "apple" };

            Console.WriteLine("Medium Dictionary Example:");
            foreach (var word in words)
            {
                if (wordOccurrences.ContainsKey(word))
                {
                    wordOccurrences[word]++;
                }
                else
                {
                    wordOccurrences[word] = 1;
                }
            }

            foreach (var kvp in wordOccurrences)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} occurrences");
            }
        }

        public static void ComplexExample()
        {
            // Real-world example: Managing employee information
            Console.WriteLine("Complex Dictionary Example:");
            Dictionary<string, Employee> employeeDatabase = new();

            employeeDatabase.Add("JohnDoe", new Employee("John Doe", 35, "Software Engineer"));
            employeeDatabase.Add("AliceSmith", new Employee("Alice Smith", 28, "UX Designer"));
            employeeDatabase.Add("BobJohnson", new Employee("Bob Johnson", 40, "Project Manager"));

            foreach (var kvp in employeeDatabase)
            {
                Console.WriteLine($"Employee: {kvp.Value.Name}, Age: {kvp.Value.Age}, Role: {kvp.Value.Role}");
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
