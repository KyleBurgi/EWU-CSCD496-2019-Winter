using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SecretSanta.Import;
using System.IO;
using SecretSanta.Domain;
using System.Linq;

namespace SecretSanta.Import.Tests
{
    [TestClass]
    public class ImportTests
    {
        private static List<string> goodTestListOne = new List<string> { "Name:Kyle Burgi", "Pokemon Cards", "Shiny New Computer", "Millions of Dollars" };
        private static List<string> goodTestListTwo = new List<string> { "Name:Burgi, Kyle", "Digimon Cards", "Shiny New Computer", "Millions of Dollars", "A Pony." };
        private static List<string> badTestListThree = new List<string> { "Kyle Burgi", "Coal", "Used Socks", "Value Village Gift Card" };
        private static List<string> goodTestListEmpty = new List<string> { "Name:Burgi, Kyle" };
        private static List<string> goodTestListEmptyTwo = new List<string> { "Name:Kyle Burgi" };
        [TestInitialize]
        public void TestInitialize()
        {
            TestCleanup();

            if (!File.Exists(Path.GetTempPath() + "/goodTestListOne.txt"))
                File.WriteAllLines(Path.GetTempPath() + "/goodTestListOne.txt", goodTestListOne);

            if (!File.Exists(Path.GetTempPath() + "/goodTestListTwo.txt"))
                File.WriteAllLines(Path.GetTempPath() + "/goodTestListTwo.txt", goodTestListTwo);

            if (!File.Exists(Path.GetTempPath() + "/badTestListThree.txt"))
                File.WriteAllLines(Path.GetTempPath() + "/badTestListThree.txt", badTestListThree);

            if (!File.Exists(Path.GetTempPath() + "/goodTestListEmpty.txt"))
                File.WriteAllLines(Path.GetTempPath() + "/goodTestListEmpty.txt", goodTestListEmpty);

            if (!File.Exists(Path.GetTempPath() + "/goodTestListEmptyTwo.txt"))
                File.WriteAllLines(Path.GetTempPath() + "/goodTestListEmptyTwo.txt", goodTestListEmptyTwo);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(Path.GetTempPath() + "/goodTestListOne.txt"))
                File.Delete(Path.GetTempPath() + "/goodTestListOne.txt");

            if (File.Exists(Path.GetTempPath() + "/goodTestListTwo.txt"))
                File.Delete(Path.GetTempPath() + "/goodTestListTwo.txt");

            if (File.Exists(Path.GetTempPath() + "/badTestListThree.txt"))
                File.Delete(Path.GetTempPath() + "/badTestListThree.txt");

            if (File.Exists(Path.GetTempPath() + "/goodTestListEmpty.txt"))
                File.Delete(Path.GetTempPath() + "/goodTestListEmpty.txt");

            if (!File.Exists(Path.GetTempPath() + "/goodTestListEmptyTwo.txt"))
                File.Delete(Path.GetTempPath() + "/goodTestListEmptyTwo.txt");
        }

        //Check Arguments From Here On
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Import_filenameIsNull_ThrowsException()
        {
            Import import = new Import(null);
        }


        [TestMethod]
        [DataRow("/ThisIsABadPath.txt")]
        [DataRow("/ThisIsABadPath2.txt")]
        [DataRow("/ThisIsABadPath3.txt")]
        [DataRow("/goodTestListThree.txt")]
        [ExpectedException(typeof(ArgumentException))]
        public void Import_DoesNotExistThrowsException(string wrongPath)
        {
            Import import = new Import(Path.GetTempPath() + wrongPath);
        }

        //Check Data
        [TestMethod]
        [DataRow("/goodTestListOne.txt")]
        [DataRow("/goodTestListTwo.txt")]
        public void CheckHeader_Name_Success(string path)
        {
            Import import = new Import();
            Assert.IsTrue(import.ProperHeaderExists(Path.GetTempPath() + path));

        }

        [TestMethod]
        [DataRow("/goodTestListOne.txt", "Kyle", "Burgi")]
        [DataRow("/goodTestListTwo.txt", "Kyle", "Burgi")]
        public void CheckHeader_CorrectName_Pass(string path, string correctFirstName, string correctLastName)
        {
            Import import = new Import(Path.GetTempPath() + path);
            User checkUser = import.ReadHeader();
            Assert.AreEqual<string>(correctFirstName, checkUser.FirstName);
            Assert.AreEqual<string>(correctLastName, checkUser.LastName);
        }

        [TestMethod]
        [DataRow("/goodTestListOne.txt", 3)]
        [DataRow("/goodTestListTwo.txt", 4)]
        public void CorrectGiftAmount_Pass(string path, int numOfGifts)
        {
            Import import = new Import(Path.GetTempPath() + path);
            User checkUser = import.ReadHeader();
            import.ReadFileGifts(checkUser);
            Assert.AreEqual<int>(checkUser.Gifts.Count, numOfGifts);
        }

        [TestMethod]
        [DataRow("/goodTestListOne.txt")]
        [DataRow("/goodTestListTwo.txt")]
        public void CorrectGiftNames_Pass(string path)
        {
            Import import = new Import(Path.GetTempPath() + path);
            User checkUser = import.ReadHeader();
            import.ReadFileGifts(checkUser);
            Assert.IsTrue(checkUser.PrintWishList().Contains("Millions of Dollars"));
        }

        [TestMethod]
        [DataRow("/goodTestListEmpty.txt")]
        [DataRow("/goodTestListEmptyTwo.txt")]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckWishlist_IsEmpty_ThrowArgument(string path)
        {
            Import import = new Import(Path.GetTempPath() + path);
            User checkUser = import.ReadHeader();
            import.ReadFileGifts(checkUser);
            checkUser.PrintWishList().Contains("Millions of Dollars");

        }


    }
}
