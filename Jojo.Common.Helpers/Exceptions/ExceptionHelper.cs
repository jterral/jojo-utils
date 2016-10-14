using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jojo.Common.Helpers.Exceptions
{
    /// <summary>
    /// Utilitaire de gestion des exceptions.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Obtient le message d'exception mise en forme.
        /// </summary>
        /// <param name="exception">L'exception à mettre en forme.</param>
        /// <param name="withStackTrace">Indique si la pile d'appel est à imprimer (par défaut) ou non.</param>
        /// <returns>Le message de l'exception mis en forme.</returns>
        public static string GetMessageException(Exception exception, bool withStackTrace = true)
        {
            StringBuilder messageBuilder = new StringBuilder(200);
            messageBuilder.AppendLine(exception.Message.Trim());
            if (exception.InnerException != null)
            {
                // Ajout du message d'exception interne
                messageBuilder.AppendLine(exception.InnerException.Message.Trim());
            }

            if (withStackTrace)
            {
                // Pile d'appel si demandée
                messageBuilder.AppendLine("<StackTrace>");
                messageBuilder.AppendLine(exception.StackTrace);
                messageBuilder.AppendLine("</StackTrace>");
            }

            return messageBuilder.ToString().Trim();
        }

        /// <summary>
        /// Obtient le message de l'exception Web mis en forme.
        /// </summary>
        /// <param name="exception">L'exception web à mettre en forme.</param>
        /// <param name="withStackTrace">Indique si la pile d'appel est à imprimer (par défaut) ou non.</param>
        /// <returns>Le message de l'exception mis en forme.</returns>
        public static string GetWebMessageException(Exception exception, bool withStackTrace = true)
        {
            // Message à renvoyer
            StringBuilder messageBuilder = new StringBuilder(200);

            // Récupération de l'exception de base
            Exception baseException = exception.GetBaseException();
            string baseMessage = baseException.Message.Trim();
            if (!string.IsNullOrEmpty(baseMessage))
            {
                messageBuilder.AppendLine(baseMessage);
            }

            // Exceptin Web
            WebException webException = exception.InnerException as WebException;
            if (webException != null)
            {
                // Récupération de l'erreur complète
                if (webException.Response != null)
                {
                    Stream responseStream = webException.Response.GetResponseStream();
                    if (responseStream != null && responseStream.CanRead)
                    {
                        // La réponse est valide et peut être lue
                        string response = new StreamReader(responseStream).ReadToEnd();
                        if (!string.IsNullOrEmpty(response))
                        {
                            // Si du texte est bien contenu dans la réponse on l'ajoute
                            messageBuilder.AppendLine(response);
                        }
                    }
                }
                else
                {
                    if (baseMessage != webException.Message)
                    {
                        messageBuilder.AppendLine(webException.Message);
                    }
                }
            }

            if (withStackTrace)
            {
                // Pile d'appel si demandée
                messageBuilder.AppendLine("<StackTrace>");
                messageBuilder.AppendLine(exception.StackTrace);
                messageBuilder.AppendLine("</StackTrace>");
            }

            return messageBuilder.ToString().Trim();
        }
    }
}
