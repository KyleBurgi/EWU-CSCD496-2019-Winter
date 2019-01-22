using Microsoft.VisualStudio.TestTools.UnitTesting;
using Import;
using System;

namespace Import.Test
{
    /* *
     * 1. Write test that fails to show you need to write some code
     * 2. Write code to get test to pass 
     * 3. Refactor
     * 4. Go to #1
     * */
    [TestClass]
    public class ImportTest
    {
        public TestContext TestContext { get; set; }
        public Import Import;

        [TestInitialize]
        public void TestInit()
        {
            Import = new Import();
        }

        [TestMethod]
        [DataRow("The_Directory_String", "The_Directory_String")]
        [DataRow("The_Directory_String", "The_Directory_Strings")]
        public void ImportTestOne(string input, string output)
        {
            
            Assert.AreEqual<string>(output, "The_Directory_String");
            //Assert.AreNotEqual<string>(Import.SetDirectoryString(input), output);

        }

        [TestMethod]
        [DataRow(typeof(ArgumentNullException), null)]
        public void Set_DirectoryString_ThrowArgument(Type exceptionType, string directoryString)
        {
            Import.SetDirectoryString(directoryString);
        }
    }
}
