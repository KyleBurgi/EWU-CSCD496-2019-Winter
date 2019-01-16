using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void PassFirstName()
        {
            User u = new User { FirstName = "Kyle", LastName = "Burgi" };
            Assert.AreEqual("Kyle", u.FirstName);
        }

        [TestMethod]
        public void PassLastName()
        {
            User u = new User { FirstName = "Kyle", LastName = "Burgi" };
            Assert.AreEqual("Burgi", u.LastName);
        }

    }
}