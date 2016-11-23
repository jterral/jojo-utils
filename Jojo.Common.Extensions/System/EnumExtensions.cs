using System;
using System.ComponentModel;
using System.Linq;
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
        /// <param name="enumValue">L'énumération pour laquelle récupérer sa description.</param>
        /// <returns>Retourne la description de l'énumération si celle-ci existe, sinon l'énumération sous forme de <see cref="string" />.</returns>
        public static string GetDescription<T>(this Enum enumValue)
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? enumValue.ToString() : attribute.Description;
        }

        /// <summary>
        /// Obtient l'attribut personnalisé d'une énumération.
        /// </summary>
        /// <typeparam name="TAttribute">Le type de l'attribut à récupérer.</typeparam>
        /// <param name="enumValue">L'énumération pour laquelle récupérer l'attribut.</param>
        /// <returns>Retourne l'attribut retrouvé sur l'énumération.</returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<TAttribute>();
        }
    }
}
