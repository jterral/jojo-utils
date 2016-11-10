using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Jojo.WPF.Converters
{

    /// <summary>
    /// Représentation d'un convertisseur d'opérations arithmétiques simples sur des valeurs numériques.
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// ...
    /// xmlns:converter="clr-namespace:TCS.CIC65.UI.Helpers.Converters"
    /// ...
    /// <MultiBinding Converter="{x:Static converter:ArithmeticConverter.Default}" ConverterParameter="*">
    ///   <Binding Path="ValeurA" />
    ///   <Binding Path="ValeurB" />
    /// </MultiBinding>
    /// ...
    /// ]]>
    /// </example>
    public sealed class ArithmeticConverter : IValueConverter, IMultiValueConverter
    {
        /// <summary>
        /// Obtient l'instance du convertisseur arithmétique.
        /// </summary>
        /// <value>
        /// L'instance partagée d'un <see cref="ArithmeticConverter"/>.
        /// </value>
        public static readonly ArithmeticConverter Default = new ArithmeticConverter();

        /// <summary>
        /// Obtient le résultat d'une opération arithmétique unaire.
        /// </summary>
        /// <param name="value">La valeur transformable en <see cref="System.Convert.ToDouble"/>.</param>
        /// <param name="targetType">Ignoré, le type est toujours <see cref="Double"/>.</param>
        /// <param name="parameter">L'opération arithmétique à appliquer. Opérations supportées : + (absolu) and - (négation).</param>
        /// <param name="culture">Une implémentation de l'interface <see cref="IFormatProvider"/> qui supporte l'information de culture.</param>
        /// <returns>Retourne un <see cref="Double"/> qui est le résultat de l'opération entre <paramref name="parameter"/> avec la <paramref name="value"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            var operations = parameter as string ?? string.Empty;

            var result = System.Convert.ToDouble(value, culture);
            for (int o = 0; o < operations.Length; o++)
            {
                result = Interpret(operations[o], result);
            }

            return result;
        }

        /// <summary>
        /// Obtient le résultat d'une opération arithmétique binaire à plusieurs valeurs.
        /// </summary>
        /// <param name="values">Les valeurs transformable en <see cref="System.Convert.ToDouble"/>.</param>
        /// <param name="targetType">Ignoré, le type est toujours <see cref="Double"/>.</param>
        /// <param name="parameter">L'opération binaire arithmétique à appliquer. Opérations supportées +, -, *, /, %, and ^. Le nombre d'opérations doit être exactement un de moins que le nombre de valeurs.</param>
        /// <param name="culture">Une implémentation de l'interface <see cref="IFormatProvider"/> qui supporte l'information de culture.</param>
        /// /// <returns>Retourne un <see cref="Double"/> qui est le résultat de l'opération <paramref name="parameter"/> avec les <paramref name="values"/>.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (Array.IndexOf(values, DependencyProperty.UnsetValue) >= 0)
            {
                return DependencyProperty.UnsetValue;
            }

            var operations = parameter as string ?? string.Empty;

            if (operations.Length != values.Length - 1)
            {
                throw new ArgumentException("The number of arithmetic operators (" + operations.Length + ") does not match the number of values (" + values.Length + ").", "parameter");
            }

            var result = System.Convert.ToDouble(values[0], culture);
            for (int o = 0; o < operations.Length; o++)
            {
                var operand = System.Convert.ToDouble(values[o + 1], culture);
                result = Interpret(operations[o], result, operand);
            }

            return result;
        }

        /// <summary>
        /// Méthode non supportée.
        /// </summary>
        /// <param name="value">La valeur.</param>
        /// <param name="targetType">Le type de la valeur.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Opération non supportée.</returns>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Méthode non supportée.
        /// </summary>
        /// <param name="value">La valeur.</param>
        /// <param name="targetTypes">Les types de la valeur.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Opération non supportée.</returns>
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Obtient le résultat de l'opération unaire <paramref name="operation"/>.
        /// </summary>
        /// <param name="operation">L'opération à appliquer.</param>
        /// <param name="operand">L'opérande à utiliser.</param>
        /// <returns>Retourne le résultat de <paramref name="operation"/> sur le <paramref name="operand"/>.</returns>
        private static double Interpret(char operation, double operand)
        {
            switch (operation)
            {
                case '+': return Math.Abs(operand);
                case '-': return -operand;
                default: throw new ArgumentException("Unknown unary operator: " + operation, "operation");
            }
        }

        /// <summary>
        /// Obtient le résultat de l'opération binaire <paramref name="operation"/> sur deux opérandes.
        /// </summary>
        /// <param name="operation">L'opération à appliquer.</param>
        /// <param name="operand1">La première opérande.</param>
        /// <param name="operand2">La seconde opérande.</param>
        /// <returns>Retourne le résultat de : <paramref name="operand1"/> <paramref name="operation"/> <paramref name="operand2"/>.</returns>
        private static double Interpret(char operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/': return operand1 / operand2;
                case '%': return operand1 % operand2;
                case '^': return Math.Pow(operand1, operand2);
                default: throw new ArgumentException("Unknown binary operator: " + operation, "operation");
            }
        }
    }
}
