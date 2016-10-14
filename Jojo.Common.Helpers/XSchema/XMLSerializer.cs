using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Jojo.Common.Helpers.XSchema
{
    /// <summary>
    /// Utilitaire de sérialisation ou dé-sérialisation d'un fichier XML.
    /// </summary>
    public class XMLSerializer
    {
        /// <summary>
        /// Sérialisation d'un objet en fichier.
        /// </summary>
        /// <typeparam name="T">Le type de l'objet à sérialiser.</typeparam>
        /// <param name="value">L'objet à sérialiser.</param>
        /// <param name="xmlFilePath">Le chemin du fichier de destination.</param>
        /// <param name="xmlWriterSettings">Les options de l'écrivain XML.</param>
        public static void SerializeToFile<T>(T value, string xmlFilePath, XmlWriterSettings xmlWriterSettings = null) where T : class, new()
        {
            if (value == null)
            {
                throw new ArgumentException("value");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = xmlWriterSettings ?? new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false
            };

            try
            {
                using (TextWriter textWriter = new StreamWriter(xmlFilePath))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, value);
                    }
                }
            }
            catch (Exception)
            {
                // TODO : implémentation de la logique d'exception
                throw;
            }
        }

        /// <summary>
        /// Dé-sérialisation d'un fichier en objet.
        /// </summary>
        /// <typeparam name="T">Le type de l'objet de destination.</typeparam>
        /// <param name="xmlFilePath">Le chemin du fichier XML.</param>
        /// <param name="xmlReaderSettings">Les options du lecteur XML.</param>
        /// <returns>Retourne l'objet créé à partir du fichier XML.</returns>
        public static T DeserializeFromFile<T>(string xmlFilePath, XmlReaderSettings xmlReaderSettings = null) where T : class, new()
        {
            if (string.IsNullOrEmpty(xmlFilePath))
            {
                throw new ArgumentException("xmlFilePath");
            }

            T deserializedObject = null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlReaderSettings settings = xmlReaderSettings ?? new XmlReaderSettings();

            try
            {
                using (TextReader textReader = new StreamReader(xmlFilePath))
                {
                    using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                    {
                        deserializedObject = serializer.Deserialize(xmlReader) as T;
                    }
                }
            }
            catch (Exception)
            {
                // TODO : implémentation de la logique d'exception
                throw;
            }

            return deserializedObject;
        }
    }
}
