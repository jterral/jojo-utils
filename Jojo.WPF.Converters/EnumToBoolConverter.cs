using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Jojo.WPF.Converters
{
    /// <summary>
    /// Conversion d'un <see cref="Enum"/> en <see cref="Boolean"/>.
    /// </summary>
    /// <example>
    /// ...
    /// <converter:EnumToBoolConverter x:Key="EnumToBoolConverter"/>
    /// ...
    /// Binding="{Binding Path=MyObject.MyEnumField, Converter={StaticResource ResourceKey=EnumToBoolConverter}, ConverterParameter={x:Static local:MyEnum.EnumValueA}}"
    /// ...
    /// </example>
    [ValueConversion(typeof(Enum), typeof(bool))]
    public class EnumToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Conversion d'une valeur d'énumération en <see cref="bool"/>.
        /// </summary>
        /// <param name="value">L'objet à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne <c>true</c> si l'énumération vaut la valeur demandée, <c>false</c> sinon.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }

            return value.Equals(parameter);
        }

        /// <summary>
        /// Conversion inverse d'un <see cref="bool"/> en énumération.
        /// </summary>
        /// <param name="value">La valeur à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne la valeur de l'énumération.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter.ToString();
            if (string.IsNullOrEmpty(parameterString))
            {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, parameterString);
        }
    }
}
