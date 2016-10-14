using Jojo.Common.Helpers.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Helpers
{
    [TestClass]
    public class UnitTestConfig
    {
        [TestMethod]
        public void NoKeyConfiguration()
        {
            // Clé non présente
            string keyValue = ConfigHelper.ConfigSetting("key");
            Assert.IsNotNull(keyValue);
            Assert.AreEqual(string.Empty, keyValue);
        }

        [TestMethod]
        public void StringConfiguration()
        {
            string keyValue = ConfigHelper.ConfigSetting("keyA");
            Assert.IsNotNull(keyValue);
            Assert.IsInstanceOfType(keyValue, typeof(string));
            Assert.AreEqual("ValueA", keyValue);

            keyValue = ConfigHelper.ConfigSetting("keyB");
            Assert.IsNotNull(keyValue);
            Assert.IsInstanceOfType(keyValue, typeof(string));
            Assert.AreEqual("42", keyValue);

            keyValue = ConfigHelper.ConfigSetting("keyC");
            Assert.IsNotNull(keyValue);
            Assert.IsInstanceOfType(keyValue, typeof(string));
            Assert.AreEqual("42,05", keyValue);
        }

        [TestMethod]
        public void IntConfiguration()
        {
            int keyValue = ConfigHelper.ConfigSetting<int>("keyB");
            Assert.IsNotNull(keyValue);
            Assert.IsInstanceOfType(keyValue, typeof(int));
            Assert.AreEqual(42, keyValue);

            int? keyNullValue = ConfigHelper.ConfigSetting<int?>("keyB");
            Assert.IsNotNull(keyNullValue);
            Assert.IsInstanceOfType(keyNullValue, typeof(int?));
            Assert.AreEqual(42, keyValue);

            keyNullValue = ConfigHelper.ConfigSetting<int?>("key");
            Assert.IsNull(keyNullValue);
        }

        [TestMethod]
        public void DoubleConfiguration()
        {
            double keyValue = ConfigHelper.ConfigSetting<double>("keyC");
            Assert.IsNotNull(keyValue);
            Assert.IsInstanceOfType(keyValue, typeof(double));
            Assert.AreEqual(42.05, keyValue);

            double? keyNullValue = ConfigHelper.ConfigSetting<double?>("keyC");
            Assert.IsNotNull(keyValue);
            Assert.IsInstanceOfType(keyValue, typeof(double?));
            Assert.AreEqual(42.05, keyValue);

            keyNullValue = ConfigHelper.ConfigSetting<double?>("key");
            Assert.IsNull(keyNullValue);
        }
    }
}
