using Jojo.Common.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Patterns
{
    [TestClass]
    public class UnitTestSingleton
    {
        [TestMethod]
        public void CreateSingleton()
        {
            Assert.IsNotNull(Singleton.Instance);
        }
    }
}
