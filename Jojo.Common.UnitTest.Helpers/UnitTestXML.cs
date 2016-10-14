using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Jojo.Common.Helpers.XSchema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Helpers
{
    [TestClass]
    public class UnitTestXML
    {
        [XmlRoot(ElementName = "note")]
        public class Note
        {
            [XmlAttribute(AttributeName = "id")]
            public int Id { get; set; }

            [XmlElement(ElementName = "to")]
            public string To { get; set; }

            [XmlElement(ElementName = "from")]
            public string From { get; set; }

            [XmlElement(ElementName = "heading")]
            public string Heading { get; set; }

            [XmlElement(ElementName = "body")]
            public string Body { get; set; }
        }

        [TestMethod]
        public void Deserialize()
        {
            string noteFilePath = Path.GetFullPath(@"../../Fixtures/XML/Note.xml");
            var value = XMLSerializer.DeserializeFromFile<Note>(noteFilePath);

            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(Note));
            Assert.AreEqual(501, value.Id);
            Assert.AreEqual("Tove", value.To);
            Assert.AreEqual("Jani", value.From);
            Assert.AreEqual("Reminder", value.Heading);
            Assert.AreEqual("Don't forget me this weekend!", value.Body);
        }

        [TestMethod]
        public void Serialize()
        {
            var value = new Note
            {
                Id = 1,
                To = "TagTo",
                From = "TagFrom",
                Heading = "TagHeading",
                Body = "TagBody"
            };

            string noteFilePath = Path.GetFullPath(@"../../Fixtures/XML/Test.xml");
            XMLSerializer.SerializeToFile<Note>(value, noteFilePath);
            Assert.IsTrue(File.Exists(noteFilePath));

            var valueOut = XMLSerializer.DeserializeFromFile<Note>(noteFilePath);
            Assert.IsNotNull(valueOut);
            Assert.AreEqual(value.Id, valueOut.Id);
            Assert.AreEqual(value.To, valueOut.To);
            Assert.AreEqual(value.From, valueOut.From);
            Assert.AreEqual(value.Heading, valueOut.Heading);
            Assert.AreEqual(value.Body, valueOut.Body);

            File.Delete(noteFilePath);
        }
    }
}
