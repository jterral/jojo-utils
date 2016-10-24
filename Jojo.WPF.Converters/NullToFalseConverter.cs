using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Jojo.WPF.Converters
{
    /// <summary>
    /// Conversion d'un <see cref="object"/> en <see cref="bool"/>.
    /// </summary>
    [ValueConversion(null, typeof(bool))]
    public class NullToFalseConverter : IValueConverter
    {
        /// <summary>
        /// Conversion d'un objet en <see cref="bool"/>.
        /// </summary>
        /// <param name="value">L'objet à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne <c>false</c> si l'objet est <c>null</c> ou <c>string.Empty</c>, <c>true</c> sinon.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string ? !string.IsNullOrEmpty((string)value) : value != null;
        }

        /// <summary>
        /// Aucune conversion inverse.
        /// </summary>
        /// <param name="value">La valeur <see cref="Visibility"/> à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne un <c>DependencyProperty.UnsetValue</c>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Aucune conversion inverse possible
            return DependencyProperty.UnsetValue;
        }
    }
}
