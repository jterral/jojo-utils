using System;
using System.Windows.Input;
using Jojo.WPF.Skeleton.Helpers.MVVM;
using Jojo.WPF.Skeleton.Resources.Internationalization;

namespace Jojo.WPF.Skeleton.Views
{
    /// <summary>
    /// Vue modèle de la page principale.
    /// </summary>
    public class HomeViewModel : ViewModelBase, IPageViewModel
    {
        /// <summary>
        /// Obtient le titre de la page principale.
        /// </summary>
        public string Title
        {
            get { return HomeMsg.Title; }
        }

        /// <summary>
        /// Le compteur exemple.
        /// </summary>
        private int _counter;

        /// <summary>
        /// Obtient ou définit le compteur exemple.
        /// </summary>
        public int Counter
        {
            get
            {
                return _counter;
            }

            set
            {
                _counter = value;
                OnPropertyChanged("Counter");
                OnPropertyChanged("RandomText");
            }
        }

        /// <summary>
        /// Obtient le texte exemple à afficher.
        /// </summary>
        public string RandomText
        {
            get
            {
                return string.Format("Count : {0}", Counter);
            }
        }

        /// <summary>
        /// Commande exemple.
        /// </summary>
        private ICommand _exampleCommand = null;

        /// <summary>
        /// Obtient la commande exemple.
        /// </summary>
        public ICommand ExampleCommand
        {
            get
            {
                if (_exampleCommand == null)
                {
                    _exampleCommand = new RelayCommand(
                        param => OnExample(),
                        param => true);
                }

                return _exampleCommand;
            }
        }

        /// <summary>
        /// L'évènement exemple.
        /// </summary>
        public event EventHandler ExampleNavigate;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="HomeViewModel"/>.
        /// </summary>
        public HomeViewModel()
        {
            _counter = 0;
        }

        /// <summary>
        /// Notification des abonnés.
        /// </summary>
        private void OnExample()
        {
            if (ExampleNavigate != null)
            {
                ExampleNavigate(this, null);
            }
        }
    }
}
