using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedList.Tests
{
    [TestClass]
    public class CustomLinkedListUnitTest
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void QueueInitialize()
        {
            this.list = new DynamicList<int>();
        }
        
        //test indexator

        [TestMethod]
        public void GetElement_AtPosition_ShouldReturnCorrectlyElementAtThisIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, this.list[i], "Gets the element at the specific position does not work properly.");
            }
        }
        
        [TestMethod]
        public void SetElement_AtPosition_ShouldSetElementCorrectlyAtThisIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            this.list[0] = 999;
            Assert.AreEqual(999, this.list[0], "Sets the element at the specified position does not work properly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AccessElement_AtInvalidPosition_ShouldThrow()
        {
            this.list[0] = 999;
        }


        //test Add()

        [TestMethod]
        public void AddElement_ToEmptyList_ShouldAddElementCorrectly()
        {
            this.list.Add(999);
            Assert.AreEqual(999, this.list[0], "Adding element does not add element correctly.");
        }

        [TestMethod]
        public void AddElement_ToNonEmptyList_ShouldAddElementAtTheEnd()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            this.list.Add(999);
            Assert.AreEqual(999, this.list[10], "Adding element does not add element at the end of the list.");
        }

        [TestMethod]
        public void AddElement_ShouldIncreaseCount()
        {
            this.list.Add(999);
            Assert.AreEqual(1, this.list.Count, "Adding element does not increase the count.");
        }


        //test RemoveAt()

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveElement_AtInvalidPosition_ShouldThrow()
        {
            this.list.RemoveAt(2);
        }

        [TestMethod]
        public void RemoveElement_AtPosition_ShouldReturnElement()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            var element = this.list.RemoveAt(5);
            Assert.AreEqual(5, element, "Removing element at position does not return correct element.");
        }

        [TestMethod]
        public void RemoveElement_AtPosition_ShouldDecreaseCount()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            this.list.RemoveAt(5);
            Assert.AreEqual(9, this.list.Count, "Removing element at position does not decrease list count.");
        }


        //test Remove()

        [TestMethod]
        public void Remove_NonExistingElement_ShouldReturnInvalidPosition()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            var position = this.list.Remove(999);
            Assert.AreEqual(-1, position, "Removing non-existing element does not return -1.");
        }

        [TestMethod]
        public void Remove_ExistingElement_ShouldReturnElementIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            var position = this.list.Remove(5);
            Assert.AreEqual(5, position, "Removing existing element does not return correct index.");
        }

        [TestMethod]
        public void RemoveElement_ShouldDecreaseCount()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            this.list.Remove(5);
            Assert.AreEqual(9, this.list.Count, "Removing element does not decrease list count.");
        }


        //test IndexOf()

        [TestMethod]
        public void IndexOf_NonExistingElement_ShouldReturnInvalidPosition()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            var position = this.list.IndexOf(999);
            Assert.AreEqual(-1, position, "Searching non-existing element does not return -1.");
        }

        [TestMethod]
        public void IndexOf_ExistingElement_ShouldReturnIndexOfFirstOccurrenceOfElement()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(5);
            }

            var position = this.list.IndexOf(5);
            Assert.AreEqual(0, position, "Searching existing element does not return the first occurrence of the element.");
        }


        //test Contains()

        [TestMethod]
        public void Contains_NonExistingElement_ShouldReturnFalse()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            var found = this.list.Contains(999);
            Assert.AreEqual(false, found, "Searching non-existing element does not return false.");
        }

        [TestMethod]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            var found = this.list.Contains(5);
            Assert.AreEqual(true, found, "Searching existing element does not return true.");
        }
    }
}
