using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ZeroToHero.Collections.Console.ObservableCollection
{
    public static class ObservableCollectionExamples
    {
        public static void BuildExamples()
        {
            
            System.Console.WriteLine("Observable Collection example");
            // Creating an ObservableCollection of integers
            ObservableCollection<int> numbers = [];

            // Subscribing to the CollectionChanged event
            numbers.CollectionChanged += Numbers_CollectionChanged;

            // Adding elements to the ObservableCollection
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            // Removing an element from the ObservableCollection
            numbers.Remove(20);
        }

        private static void Numbers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            System.Console.WriteLine("Collection changed!");

            // Additional handling based on the type of change
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                System.Console.WriteLine($"Added item at index {e.NewStartingIndex}");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                System.Console.WriteLine($"Removed item at index {e.OldStartingIndex}");
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                System.Console.WriteLine($"Replaced item at index {e.NewStartingIndex}");
            }
            // ... other actions can be checked as needed
        }
    }
}
