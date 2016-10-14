using Jojo.Common.Extensions.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Extensions
{
    [TestClass]
    public class UnitTestEnum
    {
        private enum ETest
        {
            [System.ComponentModel.Description("Test A")]
            TestA = 0,

            [System.ComponentModel.Description("Test B")]
            TestB,

            [System.ComponentModel.Description("Test C")]
            TestC,

            TestD
        }

        [TestMethod]
        public void GetDescription()
        {
            Assert.AreEqual("Test A", ETest.TestA.GetDescription<ETest>());
            Assert.AreEqual("Test B", ETest.TestB.GetDescription<ETest>());
            Assert.AreEqual("Test C", ETest.TestC.GetDescription<ETest>());
            Assert.AreEqual("TestD", ETest.TestD.GetDescription<ETest>());
        }
    }
}
