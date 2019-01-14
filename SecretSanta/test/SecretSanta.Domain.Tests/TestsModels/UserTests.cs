using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SecretSanta.Domain;

namespace SecretSanta.Domain.Tests
{
    [TestClass]
    class UserTests
    {
        [TestMethod]
        public void MyFirstTestMethod()
        {
            User u = new User { FirstName = "Kyle", LastName = "Burgi" };
            Assert.AreEqual("Kyle", u.FirstName);
            Assert.AreEqual("Burgi", u.LastName);
        }
    }
}
