using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Tests
{
    using Huy_Phuong.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListTheatresUnitTests
    {
        private SortedDictionary<string, SortedSet<Performance>> performances;

        [TestInitialize]
        public void QueueInitialize()
        {
            this.performances = new SortedDictionary<string, SortedSet<Performance>>();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ListTheatres_EmptyList_ShouldThrow()
        {
            var database = new PerformanceDatabase();
            var theatres = database.ListTheatres();
        }


        [TestMethod]
        public void ListTheatres_NonEmptyList_ShouldListTheatresCorrectly()
        {
            //this.performances.Add();
            //var theatres = this.database.ListTheatres();
        }


    }
}
