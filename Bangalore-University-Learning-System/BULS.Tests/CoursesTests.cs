namespace BULS.Tests
{
    using System;
    using System.Linq;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CoursesTests
    {
        private IBangaloreUniversityData mockedData;

        private Course course;

        [TestInitialize]
        public void InitializeMock()
        {
            var dataMock = new Mock<IBangaloreUniversityData>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = new Course("C# for babies");
            courseRepoMock.Setup(r => r.Get(It.IsAny<int>())).Returns(this.course);
            dataMock.Setup(d => d.Courses).Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;
        }


        [TestMethod]
        public void AddLecture_ValidCourseId_ShouldAddToCourse()
        {
            // Arrange
            var controller = new CoursesController(this.mockedData, new User("Pesho", "123456", Role.Lecturer));

            const int LectureId = 5;
            string lectureName = DateTime.Now.ToString();

            // Act
            var view = controller.AddLecture(LectureId, lectureName);

            // Assert
            Assert.AreEqual(this.course.Lectures.First().Name, lectureName);
            Assert.IsNotNull(view);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLecture_InvalidCourseId_ShouldThrow()
        {
            // Arrange
            var dataMock = new Mock<IBangaloreUniversityData>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = new Course("C# for babies");
            courseRepoMock.Setup(r => r.Get(It.IsAny<int>())).Returns(default(Course));
            dataMock.Setup(d => d.Courses).Returns(courseRepoMock.Object);
            this.mockedData = dataMock.Object;

            var controller = new CoursesController(this.mockedData, new User("Pesho", "123456", Role.Lecturer));

            const int LectureId = 5;
            string lectureName = DateTime.Now.ToString();

            // Act
            var view = controller.AddLecture(LectureId, lectureName);
        }
    }
}
