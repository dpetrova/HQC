namespace BULS.Tests
{
    using System.Collections.Generic;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        private IRepository<User> users;

        [TestInitialize]
        public void InitializeRepository()
        {
            this.users = new Repository<User>();
        }

        [TestMethod]
        public void Get_ValidId_ShouldReturnElement()
        {
            // Arrange
            var userList = new List<User>
                               {
                                   new User("Pesho", "123456", Role.Student), 
                                   new User("Gosho", "654321", Role.Lecturer)
                               };

            foreach (var user in userList)
            {
                this.users.Add(user);
            }

            // Act
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            // Assert
            Assert.AreEqual(userList[Id - 1], actualUser);
        }

        [TestMethod]
        public void Get_InValidId_ShouldReturnDefault()
        {
            // Act
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            // Assert
            Assert.AreEqual(default(User), actualUser); // default(User) == null
        }
    }
}