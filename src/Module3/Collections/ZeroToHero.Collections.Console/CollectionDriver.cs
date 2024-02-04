namespace ZeroToHero.Collections.Console
{
    using System;
    using ZeroToHero.Collections.Console.Arrays;
    using ZeroToHero.Collections.Console.Dictionary;
    using ZeroToHero.Collections.Console.List;
    using ZeroToHero.Collections.Console.Queue;
    using ZeroToHero.Collections.Console.SortedList;
    using ZeroToHero.Collections.Console.Stack;

    public class CollectionBuilder
    {
        public static void BuildAllExamples()
        {
            Console.WriteLine("Array Examples:");
            ArrayExamples.BuildExamples();

            Console.WriteLine("\nList Examples:");
            ListExamples.BuildExamples();

            Console.WriteLine("\nDictionary Examples:");
            DictionaryExamples.BuildExamples();

            Console.WriteLine("\nStack Examples:");
            StackExamples.BuildExamples();

            Console.WriteLine("\nSortedList Examples:");
            SortedListExamples.BuildExamples();

            Console.WriteLine("\nQueue Examples:");
            QueueExamples.BuildExamples();

            Console.WriteLine("\nHashset Examples:");
            HashSetExamples.BuildExamples();
        }
    }
}
