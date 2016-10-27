using System;
using System.Globalization;
using System.Windows.Data;

namespace Jojo.WPF.Converters
{
    /// <summary>
    /// Conversion d'un <see cref="bool"/> en son inverse.
    /// </summary>
    [ValueConversion(null, typeof(bool))]
    public class InvertBoolConverter : IValueConverter
    {
        /// <summary>
        /// Conversion d'un <see cref="bool"/> en son inverse.
        /// </summary>
        /// <param name="value">L'objet à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne <c>false</c> si le <see cref="bool"/> est <c>true</c>, <c>false</c> sinon.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }

            return false;
        }

        /// <summary>
        /// Conversion d'un <see cref="bool"/> en son inverse.
        /// </summary>
        /// <param name="value">L'objet à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne <c>false</c> si le <see cref="bool"/> est <c>true</c>, <c>false</c> sinon.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }

            return false;
        }
    }
}
