using System;
using System.ComponentModel;
using System.Reflection;

namespace Jojo.Common.Extensions.System
{
    /// <summary>
    /// Extensions du type <see cref="System.Enum" />.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Obtient la description de l'énumération.
        /// </summary>
        /// <typeparam name="T">Le type de l'énumération.</typeparam>
        /// <param name="value">L'énumération pour laquelle récupérer sa description.</param>
        /// <returns>La description de l'énumération si celle-ci existe, sinon l'énumération sous forme de <see cref="string" />.</returns>
        public static string GetDescription<T>(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
