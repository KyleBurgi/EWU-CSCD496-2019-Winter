using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SecretSanta.Import;
using System.IO;
using SecretSanta.Domain;

namespace SecretSanta.Import.Tests
{
    [TestClass]
    public class ImportTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            if (File.Exists("tempListOne.txt")) File.Delete("tempListOne.txt");
            if (File.Exists("tempListTwo.txt")) File.Delete("tempListTwo.txt");

            string[] testListOne = { "Name:Kyle Burgi", "Pokemon Cards", "Shiny Computer", "Millions of Dollars" };
            string[] testListTwo = { "Name:Burgi, Kyle", "Digimon Cards", "Shiny Computer", "Millions of Dollars", "A Pony." };

            File.WriteAllLines("tmp.txt", testListOne);
            File.WriteAllLines("tmp2.txt", testListTwo);
        }

        //Check Arguments From Here On
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Import_filenameIsNull_ThrowsException()
        {
            Import import = new Import(null);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Import_DoesNotExistThrowsException()
        {
            Import import = new Import("FakeFile");
        }

        //Check Data
        [TestMethod]
        public void CheckHeader_Name_Success()
        {
            Import import = new Import("tempListOne.txt");
            Assert.IsTrue(import.HeaderExists("tempListOne.txt"));
        }
    }
}
