namespace ZeroToHero.Collections.Console.SortedList
{
    using System;
    using System.Collections.Generic;

    public class SortedListExamples
    {
        public static void EasyExample()
        {
            SortedList<int, string> months = new()
            {
                { 3, "March" },
                { 1, "January" },
                { 2, "February" }
            };

            Console.WriteLine("Easy SortedList Example:");
            foreach (var kvp in months)
            {
                Console.WriteLine($"Month: {kvp.Value}, Order: {kvp.Key}");
            }
        }

        public static void MediumExample()
        {
            // Medium example for SortedList is omitted for brevity
        }

        public static void ComplexExample()
        {
            // Real-world example: Managing student grades
            Console.WriteLine("Complex SortedList Example:");
            SortedList<string, double> studentGrades = new()
            {
                { "Alice", 92.5 },
                { "Bob", 85.0 },
                { "Charlie", 78.3 }
            };

            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
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
