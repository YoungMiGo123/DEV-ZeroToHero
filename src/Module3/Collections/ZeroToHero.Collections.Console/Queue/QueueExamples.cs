namespace ZeroToHero.Collections.Console.Queue
{
    using System;
    using System.Collections.Generic;

    public class QueueExamples
    {
        public static void EasyExample()
        {
            Queue<int> tasks = new();
            tasks.Enqueue(1);
            tasks.Enqueue(2);
            tasks.Enqueue(3);

            Console.WriteLine("Easy Queue Example:");
            while (tasks.Count > 0)
            {
                Console.Write(tasks.Dequeue() + " ");
            }
            Console.WriteLine();
        }

        public static void MediumExample()
        {
            // Medium example for Queue: Simulating a customer service queue
            Console.WriteLine("Medium Queue Example:");
            Queue<string> customerServiceQueue = new();

            customerServiceQueue.Enqueue("Customer Alice");
            customerServiceQueue.Enqueue("Customer Bob");
            customerServiceQueue.Enqueue("Customer Charlie");

            Console.WriteLine("Customer Service Queue:");
            while (customerServiceQueue.Count > 0)
            {
                Console.WriteLine($"Serving {customerServiceQueue.Dequeue()}");
            }
        }

        public static void ComplexExample()
        {
            // Real-world example: Order processing system
            Console.WriteLine("Complex Queue Example:");
            Queue<Order> orderQueue = new();

            orderQueue.Enqueue(new Order("Order123", "ProductA"));
            orderQueue.Enqueue(new Order("Order124", "ProductB"));
            orderQueue.Enqueue(new Order("Order125", "ProductC"));

            Console.WriteLine("Order Processing Queue:");
            foreach (var order in orderQueue)
            {
                Console.WriteLine($"Processing Order {order.OrderId} for {order.Product}");
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
