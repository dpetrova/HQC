using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Theatre.Tests
{
    using System.Collections.Generic;

    using Huy_Phuong.Models;

    [TestClass]
    public class AddPerformanceUnitTests
    {
        private SortedDictionary<string, SortedSet<Performance>> performances;

        [TestInitialize]
        public void QueueInitialize()
        {
            this.performances = new SortedDictionary<string, SortedSet<Performance>>();
        }


        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
