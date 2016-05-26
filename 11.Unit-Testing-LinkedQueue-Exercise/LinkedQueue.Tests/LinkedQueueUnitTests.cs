using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.LinkedQueue;

namespace LinkedQueue.Tests
{
    [TestClass]
    public class LinkedQueueUnitTests
    {
        private LinkedQueue<int> queue;

        [TestInitialize]
        public void QueueInitialize()
        {
            this.queue = new LinkedQueue<int>();
        }
        
        [TestMethod]
        public void Dequeue_QueueWithOneElement_ShouldReturnTheElement()
        {
            this.queue.Enqueue(1);
            var element = this.queue.Dequeue();
            Assert.AreEqual(1, element, "The Dequeue operation does not work properly.");
        }

        [TestMethod]
        public void Dequeue_QueueWithSeveralElements_ShouldReturnFirstEnqueuedElement()
        {
            for (int i = 1; i <= 10; i++)
            {
                this.queue.Enqueue(i);
            }

            for (int i = 1; i < 10; i++)
            {
                var element = this.queue.Dequeue();
                Assert.AreEqual(i, element, "The Dequeue operation does not work properly.");
            }
        }


        [TestMethod]
        public void DequeueElement_ShouldDecreaseCount()
        {
            for (int i = 1; i <= 10; i++)
            {
                this.queue.Enqueue(i);
            }

            for (int i = 1; i <= 5; i++)
            {
                this.queue.Dequeue();
            }
            
            var queueLength = this.queue.Count;
            Assert.AreEqual(5, queueLength, "Dequeing does not decrease queue count.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ShouldThrow()
        {
            this.queue.Dequeue();
        }
    }
}
