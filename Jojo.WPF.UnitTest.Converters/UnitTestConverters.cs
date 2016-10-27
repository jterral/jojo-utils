using System;
using System.Globalization;
using System.Windows;
using Jojo.WPF.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.WPF.UnitTest.Converters
{
    [TestClass]
    public class UnitTestConverters
    {
        /// <summary>
        /// Enumération pour utilisation dans les tests.
        /// </summary>
        private enum ETest
        {
            TestA = 0,
            TestB,
            TestC,
            TestD
        }

        [TestMethod]
        public void BooleanToVisibilityConverter()
        {
            // Conversion de true
            var btvc = new BoolToVisibilityConverter();
            Visibility visibilty = (Visibility)btvc.Convert(true, null, null, CultureInfo.CurrentCulture);
            Assert.IsNotNull(visibilty);
            Assert.AreEqual<Visibility>(Visibility.Visible, visibilty);

            // Conversion de false
            visibilty = (Visibility)btvc.Convert(false, null, null, CultureInfo.CurrentCulture);
            Assert.IsNotNull(visibilty);
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visibilty);

            // Conversion de false avec Hidden
            btvc = new BoolToVisibilityConverter(false);
            visibilty = (Visibility)btvc.Convert(false, null, null, CultureInfo.CurrentCulture);
            Assert.IsNotNull(visibilty);
            Assert.AreEqual<Visibility>(Visibility.Hidden, visibilty);
        }

        [TestMethod]
        public void NullToFalseConverter()
        {
            var ntfc = new NullToFalseConverter();
            object value = "Blabla";

            bool b = (bool)ntfc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsTrue(b);

            value = new object();
            b = (bool)ntfc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsTrue(b);

            value = "";
            b = (bool)ntfc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsFalse(b);

            value = null;
            b = (bool)ntfc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void EnumToBoolConverter()
        {
            var etbc = new EnumToBoolConverter();
            object value = ETest.TestA;

            bool b = (bool)etbc.Convert(value, null, ETest.TestA, CultureInfo.CurrentCulture);
            Assert.IsTrue(b);

            value = 0;
            b = (bool)etbc.Convert(value, null, ETest.TestA, CultureInfo.CurrentCulture);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void InvertBoolConverter()
        {
            var ibc = new InvertBoolConverter();
            object value = true;

            bool b = (bool)ibc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsFalse(b);

            value = false;
            b = (bool)ibc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsTrue(b);

            value = string.Empty;
            b = (bool)ibc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsFalse(b);

            value = "value";
            b = (bool)ibc.Convert(value, null, null, CultureInfo.CurrentCulture);
            Assert.IsFalse(b);
        }
    }
}
