using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Jojo.WPF.Skeleton.Helpers.MVVM
{
    /// <summary>
    /// Représentation d'une commande.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields
        /// <summary>
        /// L'action à exécuter.
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// Prédicat indiquant si l'action peut être exécutée.
        /// </summary>
        private readonly Predicate<object> canExecute;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">L'action à exécuter.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">L'action à exécuter.</param>
        /// <param name="canExecute">Prédicat indiquant si l'action peut être exécutée.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Aucune action à exécuter.");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Members
        /// <summary>
        /// Indique si l'action peut être exécutée.
        /// </summary>
        /// <param name="parameter">Le paramètre à passer.</param>
        /// <returns><c>true</c> si l'action peut être exécutée, <c>false</c> sinon.</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute(parameter);
        }

        /// <summary>
        /// Evènement de possibilité d'exécution.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Exécution de l'action.
        /// </summary>
        /// <param name="parameter">Le paramètre de l'action à exécuter.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        #endregion // ICommand Members
    }
}
