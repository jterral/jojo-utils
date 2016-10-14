using System;
using Jojo.Common.Extensions.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Extensions
{
    [TestClass]
    public class UnitTestException
    {
        [TestMethod]
        public void DetailedException()
        {
            string message = "Message de l'exception;";
            Exception ex = new Exception(message);

            Assert.AreNotEqual(string.Empty, ex.DetailedException());
        }
    }
}
