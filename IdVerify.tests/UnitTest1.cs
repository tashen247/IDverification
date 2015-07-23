using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdVerify.library;

namespace IdVerify.tests
{
    [TestClass]
    public class UnitTest1
    {
        string id = "8006015084089";
        [TestMethod]
        public void TestValidation()
        {
            IdVerifyNumber verify = new IdVerifyNumber(id);

            Assert.Fail("check failed");
        }

        [TestMethod]
        public void TestGeneration()
        {
            GenerateNewId newid = new GenerateNewId();
            string newId = newid.NewID;
        }
    }
}
