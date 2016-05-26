// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkedQueue.cs" company="">
//   
// </copyright>
// <summary>
//   The linked queue.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _01.LinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Linked Queue: basic linear data structure which allows for pushing elements and its end, and retrieving elements from its front.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class LinkedQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// The head.
        /// </summary>
        private QueueNode<T> head;

        /// <summary>
        /// The tail.
        /// </summary>
        private QueueNode<T> tail;

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Allows us to use our data structure in a foreach loop.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        /// <summary>
        /// The enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Add a new element to the end of the queue.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Return and remove the first element of the queue.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var element = this.head.Value;
            this.head = this.head.NextNode;

            this.Count--;

            return element;
        }

        /// <summary>
        /// Return a boolean which tells us whether we have a specific element in our collection or not.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Contains(T element)
        {
            return this.Any(e => e.Equals(element));
        }

        /// <summary>
        /// Remove all the contents of our queue and set its count to zero.
        /// </summary>
        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        /// <summary>
        /// Return the value of the front element without removing it from the data structure.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var element = this.head.Value;

            return element;
        }
    }
}