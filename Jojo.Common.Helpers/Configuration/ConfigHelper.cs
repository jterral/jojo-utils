using System;
using System.Configuration;
using System.Globalization;

namespace Jojo.Common.Helpers.Configuration
{
    /// <summary>
    /// Utilitaire de gestion du fichier de configuration.
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// Obtient la valeur lue dans le fichier de configuration pour la clé donnée sous forme de chaine de caractère.
        /// </summary>
        /// <param name="settingName">Le nom de la clé du fichier de configuration.</param>
        /// <returns>Retourne la valeur lue dans le fichier de configuration ou <c>string.Empty</c> si non trouvée.</returns>
        public static string ConfigSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName] ?? string.Empty;
        }

        /// <summary>
        /// Obtient la valeur lue dans le fichier de configuration avec conversion de type.
        /// </summary>
        /// <typeparam name="T">Le type de retour attendu.</typeparam>
        /// <param name="settingName">Le nom de la clé du fichier de configuration.</param>
        /// <returns>Retourne la valeur lue dans le fichier de configuration.</returns>
        /// <remarks>Si une erreur de conversion se produit, une exception est levée.</remarks>
        public static T ConfigSetting<T>(string settingName)
        {
            return ConfigSetting<T>(settingName, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Obtient la valeur lue dans le fichier de configuration avec conversion de type.
        /// </summary>
        /// <typeparam name="T">Le type de retour attendu.</typeparam>
        /// <param name="settingName">Le nom de la clé du fichier de configuration.</param>
        /// <param name="culture">La culture pour conversion de type (ex un double est représenté avec une virgule en FR-fr).</param>
        /// <returns>Retourne la valeur lue dans le fichier de configuration.</returns>
        /// <remarks>Si une erreur de conversion se produit, une exception est levée.</remarks>
        public static T ConfigSetting<T>(string settingName, CultureInfo culture)
        {
            object value = ConfigurationManager.AppSettings[settingName];

            // Vérification pour conversion en Nullable
            Type t = typeof(T);
            t = Nullable.GetUnderlyingType(t) ?? t;

            return value == null ? default(T) : (T)Convert.ChangeType(value, t, culture);
        }
    }
}
