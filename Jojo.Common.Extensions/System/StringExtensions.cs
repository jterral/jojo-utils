using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jojo.Common.Extensions.System
{
    /// <summary>
    /// Extensions du type <see cref="System.String" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indique si la chaine de caractères contient la chaine spécifique.
        /// </summary>
        /// <param name="source">La chaine de caractères où vérifier.</param>
        /// <param name="value">La chaine spécifique.</param>
        /// <param name="comparisonType">Le type de comparaison.</param>
        /// <returns>Retourne une valeur indiquant si la chaine de caractères contient la chaine spécifique.</returns>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return source.IndexOf(value, comparisonType) >= 0;
        }
    }
}
