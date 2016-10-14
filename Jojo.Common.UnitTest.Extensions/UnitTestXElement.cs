using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jojo.Common.Extensions.System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Extensions
{
    [TestClass]
    public class UnitTestXElement
    {
        [TestMethod]
        public void AddElement()
        {
            XElement root = new XElement("ROOT");
            Assert.AreEqual(0, root.Nodes().Count());
            Assert.IsFalse(root.HasElements);

            int intValue = 15;
            root.AddElement("CHILD", intValue);
            Assert.AreEqual(intValue, Convert.ToInt32(root.Element("CHILD").Value));

            string stringValue = "value";
            root.AddElement("CHILD2", stringValue);
            Assert.AreEqual(stringValue, root.Element("CHILD2").Value);

            Assert.IsTrue(root.HasElements);
            Assert.AreEqual(2, root.Nodes().Count());
        }

        [TestMethod]
        public void AddCDataElement()
        {
            XElement root = new XElement("ROOT");
            Assert.AreEqual(0, root.Nodes().Count());
            Assert.IsFalse(root.HasElements);

            string cdataValue = "<test>TEST</test>";
            root.AddCDataElement("CHILD", cdataValue);
            Assert.AreEqual(cdataValue, root.Element("CHILD").Value);
        }

        [TestMethod]
        public void AddElements()
        {
            XElement root = new XElement("ROOT");
            Assert.AreEqual(0, root.Nodes().Count());
            Assert.IsFalse(root.HasElements);

            List<string> stringValues = new List<string> { "Value1", "Value2", "Value3" };

            root.AddElements("CHILDS", "CHILD", stringValues);
            Assert.AreEqual(1, root.Nodes().Count());
            Assert.AreEqual(stringValues.Count, root.Element("CHILDS").Nodes().Count());

            XElement child = null;
            for (int i = 0; i < stringValues.Count; i++)
            {
                child = root.Element("CHILDS").Nodes().ElementAt(i) as XElement;
                Assert.IsNotNull(child);
                Assert.AreEqual(stringValues[i], child.Value);
            }
        }
    }
}
