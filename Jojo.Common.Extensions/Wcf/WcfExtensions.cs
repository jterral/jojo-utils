using System;
using System.ServiceModel;

namespace Jojo.Common.Extensions.Wcf
{
    /// <summary>
    /// Extension des objets de communication WCF.
    /// </summary>
    public static class WcfExtensions
    {
        /// <summary>
        /// Exécution d'une méthode de service avec ouverture et capture des exceptions.
        /// </summary>
        /// <typeparam name="T">Le type du client WCF.</typeparam>
        /// <typeparam name="TU">Le type de retour de la méthode.</typeparam>
        /// <param name="client">Le client WCF.</param>
        /// <param name="action">La méthode à exécuter.</param>
        /// <returns>La valeur de la méthode exécutée.</returns>
        /// <exception cref="Exception">L'exception non capturée.</exception>
        /// <example>
        /// <c>
        /// using CSharpUtils.Extensions.Wcf;
        /// 
        /// return (new ServiceName1()).Execute(client => client.ServiceMethod1(param1, param2));
        /// </c>
        /// </example>
        public static TU Execute<T, TU>(this T client, Func<T, TU> action) where T : class, ICommunicationObject
        {
            if ((client == null) || (action == null))
            {
                // Renvoie de la valeur par défaut si pas d'ouverture de service
                return default(TU);
            }

            try
            {
                // Exécution de la méthode
                return action(client);
            }
            catch (CommunicationException e)
            {
                // Exception de type CommunicationException
                // TODO: Affichage d'un log
                client.Abort();
                return default(TU);
            }
            catch (TimeoutException e)
            {
                // Exception de type TimeoutException
                // TODO: Affichage d'un log
                client.Abort();
                return default(TU);
            }
            catch (Exception e)
            {
                // Exception inconnue
                // TODO: Affichage d'un log
                if (client.State == CommunicationState.Faulted)
                {
                    client.Abort();
                }

                throw;
            }
            finally
            {
                try
                {
                    if (client.State != CommunicationState.Faulted)
                    {
                        // Fermeture du service après exécution de la méthode
                        client.Close();
                    }
                }
                catch
                {
                    client.Abort();
                }
            }
        }

        /// <summary>
        /// Exécution d'une méthode de service sans retour avec ouverture et capture des exceptions.
        /// </summary>
        /// <typeparam name="T">Le type du client WCF.</typeparam>
        /// <param name="client">Le client WCF.</param>
        /// <param name="action">La méthode à exécuter.</param>
        /// <example>
        /// <c>
        /// using CSharpUtils.Extensions.Wcf;
        /// 
        /// (new ServiceName1()).Execute(client => client.ServiceMethod2(param1));
        /// </c>
        /// </example>
        public static void Execute<T>(this T client, Action<T> action) where T : class, ICommunicationObject
        {
            if ((client == null) || (action == null))
            {
                // Renvoie de la valeur par défaut si pas d'ouverture de service
                return;
            }

            try
            {
                // Exécution de la méthode
                action(client);
            }
            catch (CommunicationException e)
            {
                // Exception de type CommunicationException
                // TODO: Affichage d'un log
                client.Abort();
            }
            catch (TimeoutException e)
            {
                // Exception de type TimeoutException
                // TODO: Affichage d'un log
                client.Abort();
            }
            catch (Exception e)
            {
                // Exception inconnue
                // TODO: Affichage d'un log
                if (client.State == CommunicationState.Faulted)
                {
                    client.Abort();
                }

                throw;
            }
            finally
            {
                try
                {
                    if (client.State != CommunicationState.Faulted)
                    {
                        // Fermeture du service après exécution de la méthode
                        client.Close();
                    }
                }
                catch
                {
                    client.Abort();
                }
            }
        }
    }
}
