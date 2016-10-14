using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Jojo.Common.Extensions.System.Collections.Generic
{
    /// <summary>
    /// Extensions du type <see cref="IEnumerable" />.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Obtient la collection sous forme de <see cref="ObservableCollection"/>.
        /// </summary>
        /// <typeparam name="T">Le type des éléments contenus dans la collection.</typeparam>
        /// <param name="collection">La collection contenant les éléments.</param>
        /// <returns>Retourne la collection sous forme d'une collection observable.</returns>
        /// <example>
        /// var list = new ObservableCollection<Employee>();
        /// list = list.OrderBy(emp => emp.Salary).ToObservableCollection();
        /// </example>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
