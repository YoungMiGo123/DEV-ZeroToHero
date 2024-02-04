namespace ZeroToHero.Collections.Console.Stack
{
    using System;
    using System.Collections.Generic;

    public class StackExamples
    {
        public static void EasyExample()
        {
            Stack<int> numbers = new();
            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);

            Console.WriteLine("Easy Stack Example:");
            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + " ");
            }
            Console.WriteLine();
        }

        public static void MediumExample()
        {
            Stack<string> browserHistory = new();
            browserHistory.Push("Home");
            browserHistory.Push("About");
            browserHistory.Push("Contact");

            Console.WriteLine("Medium Stack Example:");
            Console.WriteLine($"Current Page: {browserHistory.Peek()}");
            browserHistory.Pop();
            Console.WriteLine($"Back to Page: {browserHistory.Peek()}");
        }

        public static void ComplexExample()
        {
            // Real-world example: Undo/Redo functionality in a text editor
            Console.WriteLine("Complex Stack Example:");
            Stack<string> textEditorHistory = new();

            textEditorHistory.Push("Initial Text");
            Console.WriteLine($"Current Text: {textEditorHistory.Peek()}");

            textEditorHistory.Push("Updated Text");
            Console.WriteLine($"Current Text: {textEditorHistory.Peek()}");

            // Simulate Undo
            textEditorHistory.Pop();
            Console.WriteLine($"After Undo: {textEditorHistory.Peek()}");
        }

        public static void BuildExamples()
        {
            EasyExample();
            MediumExample();
            ComplexExample();
        }
    }
}
