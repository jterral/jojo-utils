using System;

namespace Jojo.Common.Helpers.Switch
{
    /// <summary>
    /// Représentation d'un <c>switch</c> sur le type d'un objet.
    /// </summary>
    /// <remarks>
    /// Voir <c>http://stackoverflow.com/questions/298976/is-there-a-better-alternative-than-this-to-switch-on-type</c>.
    /// Définition complète de la classe : <c>https://gist.github.com/Virtlink/8722649</c>.
    /// </remarks>
    public static class TypeSwitch
    {
        /// <summary>
        /// <c>switch</c> sur le type de l'objet.
        /// </summary>
        /// <typeparam name="TSource">Le type de l'objet.</typeparam>
        /// <param name="value">La valeur de l'objet.</param>
        /// <returns>Une instance de la classe <see cref="Switch{TSource}"/>.</returns>
        public static Switch<TSource> On<TSource>(TSource value)
        {
            return new Switch<TSource>(value);
        }

        /// <summary>
        /// Classe représentant l'instance de <c>switch</c>.
        /// </summary>
        /// <typeparam name="TSource">Le type de l'objet source.</typeparam>
        public sealed class Switch<TSource>
        {
            /// <summary>
            /// La valeur de l'objet source.
            /// </summary>
            private readonly TSource value;

            /// <summary>
            /// Indique si la valeur a été trouvée dans le <c>switch</c>.
            /// </summary>
            private bool handled = false;

            /// <summary>
            /// Initialise une nouvelle instance de la classe <see cref="Switch{TSource}"/>.
            /// </summary>
            /// <param name="value">La valeur de l'objet.</param>
            internal Switch(TSource value)
            {
                this.value = value;
            }

            /// <summary>
            /// Cas d'un <c>switch</c>.
            /// </summary>
            /// <typeparam name="TTarget">Le type de sortie de l'objet.</typeparam>
            /// <param name="action">L'action à exécuter sur l'objet.</param>
            /// <returns>Une instance de la classe <see cref="Switch{TSource}"/>.</returns>
            public Switch<TSource> Case<TTarget>(Action<TTarget> action)
                where TTarget : TSource
            {
                if (!this.handled && this.value is TTarget)
                {
                    action((TTarget)this.value);
                    this.handled = true;
                }

                return this;
            }

            /// <summary>
            /// Cas par défaut d'un <c>switch</c>.
            /// </summary>
            /// <param name="action">L'action à exécuter sur l'objet dans le cas par défaut.</param>
            public void Default(Action<TSource> action)
            {
                if (!this.handled)
                {
                    action(this.value);
                }
            }
        }
    }
}
