namespace Jojo.Common.Patterns
{
    /// <summary>
    /// Implémentation du pattern Singleton.
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// Objet verrouillant la création de l'instance.
        /// </summary>
        private static readonly object SingletonLock = new object();

        /// <summary>
        /// L'instance courante.
        /// </summary>
        private static Singleton _instance = null;

        /// <summary>
        /// Empêche la création d'une instance par défaut de la classe <see cref="Singleton" />.
        /// </summary>
        private Singleton()
        {
        }

        /// <summary>
        /// Obtient l'instance courante.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                lock (SingletonLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }

                return _instance;
            }
        }

        #region Implémentation de la logique.
        // Ajout de toutes les méthodes d'instance.
        #endregion
    }
}
