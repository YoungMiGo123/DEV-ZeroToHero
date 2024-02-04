namespace ZeroToHero.Collections.PracticeWithTests
{
    public class QueueExercises
    {
        /*
            Problem:
            Reverse the order of elements in a queue.

            Example:
            ReverseQueue(new Queue<int>(new[] { 1, 2, 3, 4, 5 }))
            ➞ { 5, 4, 3, 2, 1 }
        */
        public static Queue<T> ReverseQueue<T>(Queue<T> queue)
        {
            throw new NotImplementedException();
        }

        /*
            Problem:
            Check if a given sequence of numbers can be obtained by performing stack operations (push and pop) on a queue.

            Example:
            IsStackSequence(new Queue<int>(new[] { 1, 2, 3, 4, 5 }), new List<int> { 1, 2, 3, 4, 5 })
            ➞ true
        */
        public static bool IsStackSequence<T>(Queue<T> originalQueue, List<T> stackSequence)
        {
            throw new NotImplementedException();
        }

        /*
            Problem:
            Implement a circular queue that supports enqueue, dequeue, and checking if the queue is full or empty.

            Example:
            var circularQueue = new CircularQueue<int>(5);
            circularQueue.Enqueue(1);
            circularQueue.Enqueue(2);
            circularQueue.Enqueue(3);
            circularQueue.Dequeue();
            circularQueue.Enqueue(4);
            circularQueue.Enqueue(5);
            circularQueue.Enqueue(6);
            circularQueue.IsFull() ➞ true
        */
        public class CircularQueue<T>
        {
            public CircularQueue(int capacity)
            {
                throw new NotImplementedException();
            }

            public void Enqueue(T item)
            {
                throw new NotImplementedException();
            }

            public T Dequeue()
            {
                throw new NotImplementedException();
            }

            public bool IsFull()
            {
                throw new NotImplementedException();
            }

            public bool IsEmpty()
            {
                throw new NotImplementedException();
            }
        }
    }

}
