using System;
using Jojo.Common.Extensions.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Extensions
{
    [TestClass]
    public class UnitTestString
    {
        [TestMethod]
        public void Contains()
        {
            Assert.IsTrue("AABBCCDD".Contains("BB", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue("AABBCCDD".Contains("ab", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue("AABBCCDD".Contains("Bc", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsFalse("AABBCCDD".Contains("EE", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
