using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Tests.Models
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void PassGroupTitle()
        {
            Group g = new Group { GroupTitle = "MerryChristmasOfficeParty" };
            Assert.AreEqual(g.GroupTitle, "MerryChristmasOfficeParty");
        }
    }
}
