using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Domain;
using SecretSanta.Domain.Models;
using SecretSanta.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        public User TestUser { get; set; }

        
        [TestInitialize]
        public void TestingInitialize()
        {
            TestUser = new User();
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(SqliteConnection).Options;

            using (var dbContext = new ApplicationDbContext(Options))
            {
                dbContext.Database.EnsureCreated();
            }
        }

        [TestMethod]
        [DataRow("Kyle")]
        [DataRow("Mario")]
        [DataRow("MeAnd")]
        public void AddFirstName_Pass(string firstName)
        {
            TestUser.FirstName = firstName;
            Assert.AreEqual<String>(firstName, TestUser.FirstName);
        }

        [TestMethod]
        [DataRow("Burgi")]
        [DataRow("Mario")]
        [DataRow("Mrs. Jones")]
        public void AddLastName_Pass(string lastName)
        {
            TestUser.LastName = lastName;
            Assert.AreEqual<String>(lastName, TestUser.LastName);
        }

        [TestMethod]
        [DataRow("Kyle", "Burgi", "Burgi, Kyle")]
        [DataRow("Mario","Mario", "Mario, Mario")]
        [DataRow("MeAnd", "Mrs. Jones", "Mrs. Jones, MeAnd")]
        public void UserToString_Pass(string firstName, string lastName, string correctOutput)
        {
            TestUser.FirstName = firstName;
            TestUser.LastName = lastName;
            Assert.AreEqual(TestUser.ToString(), correctOutput);
        }

        [TestMethod]
        [DataRow(typeof(ArgumentNullException), "Kyle", null)]
        [DataRow(typeof(ArgumentNullException), null, "Burgi")]
        [DataRow(typeof(ArgumentNullException), null, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_User_ThrowArgumentNullException(Type exceptionType, string firstName, string lastName)
        {
            TestUser = new User(firstName, lastName);
        }
        private SqliteConnection SqliteConnection { get; set; }
        private DbContextOptions<ApplicationDbContext> Options { get; set; }


        [TestCleanup]
        public void CloseConnection()
        {
            SqliteConnection.Close();
        }


        [TestMethod]
        public void AddUser_Success()
        {
            User u = new User { FirstName = "Kyle", LastName = "Burgi" };
            using (var dbContext = new ApplicationDbContext(Options))
            {
                Users users = new Users(dbContext);
                users.AddUser(u);
                Assert.AreEqual(1, u.Id);
            }
        }

        [TestMethod]
        public void UpdateUser_Success()
        {
            User u = new User { FirstName = "Kyle", LastName = "Burgi" };
            using (var dbContext = new ApplicationDbContext(Options))
            {
                Users users = new Users(dbContext);

                users.AddUser(u);
  
                User updateUser = users.GetUserById(1);
                updateUser.FirstName = "NotKyle";
                updateUser.LastName = "SuzyDropTables";
                users.UpdateUser(updateUser);

                User testUser = users.GetUserById(1);
                Assert.AreEqual("NotKyle", testUser.FirstName);
                Assert.AreEqual("SuzyDropTables", testUser.LastName);
                Assert.AreNotEqual("Kyle", testUser.FirstName);
                Assert.AreNotEqual("Burgi", testUser.LastName);
            }
        }

    }
}