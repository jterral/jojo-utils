using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Jojo.Common.Extensions.System.Xml
{
    /// <summary>
    /// Extensions de la classe <see cref="XElement"/>.
    /// </summary>
    public static class XElementExtensions
    {
        /// <summary>
        /// Ajoute un élément à la balise courante.
        /// </summary>
        /// <param name="root">La balise où ajouter l'élément.</param>
        /// <param name="name">Le nom de l'élément à ajouter.</param>
        /// <param name="value">La valeur de l'élément à ajouter.</param>
        public static void AddElement(this XElement root, string name, object value)
        {
            root.Add(new XElement(name, value));
        }

        /// <summary>
        /// Ajoute un élément de type <c>CData</c> à la balise courante.
        /// </summary>
        /// <param name="root">La balise où ajouter l'élément.</param>
        /// <param name="name">Le nom de l'élément à ajouter.</param>
        /// <param name="value">La valeur de l'élément à ajouter encadrée par <c>CData</c>.</param>
        [DebuggerStepThrough]
        public static void AddCDataElement(this XElement root, string name, string value)
        {
            root.AddElement(name, new XCData(value));
        }

        /// <summary>
        /// Ajoute une liste d'éléments à la balise courante.
        /// </summary>
        /// <param name="root">La balise où ajouter l'élément.</param>
        /// <param name="listName">Le nom de la balise représentant la liste.</param>
        /// <param name="name">Le nom de l'élément dans la liste.</param>
        /// <param name="values">Les valeurs de chaque élément.</param>
        public static void AddElements(this XElement root, string listName, string name, List<string> values)
        {
            root.Add(
                new XElement(
                    listName,
                    from v in values select new XElement(name, v)));
        }
    }
}
