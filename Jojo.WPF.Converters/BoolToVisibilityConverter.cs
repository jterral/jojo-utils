using System;
using System.Windows;
using System.Windows.Data;

namespace Jojo.WPF.Converters
{
    /// <summary>
    /// Conversion d'un <see cref="bool"/> en <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Obtient ou définit une valeur indiquant si la visibilité du composant est à mettre en <see cref="Visibility.Collapsed"/> ou <see cref="Visibility.Hidden"/>.
        /// </summary>
        public bool CollapseWhenInvisible { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BoolToVisibilityConverter"/>.
        /// </summary>
        public BoolToVisibilityConverter()
            : this(true)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BoolToVisibilityConverter"/>.
        /// </summary>
        /// <param name="collapseWhenInvisible">Une valeur indiquant si la visibilité du composant est à mettre en <see cref="Visibility.Collapsed"/> ou <see cref="Visibility.Hidden"/>.</param>
        public BoolToVisibilityConverter(bool collapseWhenInvisible)
            : base()
        {
            CollapseWhenInvisible = collapseWhenInvisible;
        }

        /// <summary>
        /// Conversion d'un objet en <see cref="Visibility"/>.
        /// </summary>
        /// <param name="value">La valeur <c>bool</c> à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne une valeur de type <see cref="Visibility"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? Visibility.Visible :
                (bool)value ? Visibility.Visible :
                CollapseWhenInvisible ? Visibility.Collapsed : Visibility.Hidden;
        }

        /// <summary>
        /// Conversion d'un <see cref="Visibility"/> en <see cref="bool"/>.
        /// </summary>
        /// <param name="value">La valeur <see cref="Visibility"/> à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne une valeur de type <see cref="bool"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Visibility))
            {
                return DependencyProperty.UnsetValue;
            }

            return (Visibility)value == Visibility.Visible;
        }
    }
}
