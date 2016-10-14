using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jojo.Common.Extensions.System
{
    /// <summary>
    /// Extensions du type <see cref="System.Exception" />.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Obtient l'exception sous forme de chaine de caractères formatée.
        /// </summary>
        /// <param name="ex">L'exception à formater.</param>
        /// <returns>Retourne l'exception sous forme de chaine de caractère.</returns>
        public static string DetailedException(this Exception ex)
        {
            StringBuilder exceptionBuilder = new StringBuilder(500);

            // Ajout du message d'exception
            exceptionBuilder.AppendFormat("Exception : {0}", ex.Message);
            exceptionBuilder.AppendLine();

            // Ajout du message d'exception enfant
            if (ex.InnerException != null)
            {
                exceptionBuilder.AppendFormat("Inner Exception : {1}", ex.InnerException.Message);
                exceptionBuilder.AppendLine();
            }

            // Ajout de la pile d'appel
            exceptionBuilder.AppendLine("Stack Trace :");
            exceptionBuilder.AppendLine(ex.StackTrace);

            return exceptionBuilder.ToString();
        }
    }
}
