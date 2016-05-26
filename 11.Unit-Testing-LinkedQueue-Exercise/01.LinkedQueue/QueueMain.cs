namespace _01.LinkedQueue
{
    using System;

    internal class QueueMain
    {
        public static void Main()
        {
            var q = new LinkedQueue<int>();

            q.Enqueue(1);
            Console.WriteLine(q.Peek());
        }
    }
}