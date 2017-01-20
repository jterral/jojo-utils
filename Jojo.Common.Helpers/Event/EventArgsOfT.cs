using System;

namespace Jojo.Common.Helpers.Event
{
    /// <summary>
    /// Instance de la classe <see cref="EventArgs"/> avec passage de paramètre générique.
    /// </summary>
    /// <typeparam name="T">Type du paramètre passé.</typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Le paramètre à passer.
        /// </summary>
        private readonly T _value;

        /// <summary>
        /// Obtient le paramètre passé.
        /// </summary>
        public T Value
        {
            get { return this._value; }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EventArgs{T}"/>.
        /// </summary>
        /// <param name="value">La valeur du paramètre.</param>
        public EventArgs(T value)
        {
            this._value = value;
        }
    }
}
