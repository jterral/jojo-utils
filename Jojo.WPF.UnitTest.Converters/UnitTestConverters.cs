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
        public void NullToFalseConverterConverter()
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
    }
}
