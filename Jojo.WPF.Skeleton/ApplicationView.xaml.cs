using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Jojo.WPF.Skeleton.Views;

namespace Jojo.WPF.Skeleton
{
    /// <summary>
    /// Logique d'interaction de la fenêtre principale <c>MainWindow.xaml</c>.
    /// </summary>
    public partial class ApplicationView : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Titre de la fenêtre.
        /// </summary>
        private string customWindowTitle = string.Empty;

        /// <summary>
        /// Obtient ou définit le titre de la fenêtre.
        /// </summary>
        public string CustomWindowTitle
        {
            get
            {
                return customWindowTitle;
            }

            set
            {
                customWindowTitle = value;
                OnPropertyChanged("CustomWindowTitle");
            }
        }

        #region Gestions des pages affichées dans la fenêtre
        /// <summary>
        /// Liste des vues à afficher.
        /// </summary>
        private List<IPageViewModel> _pageViewModels = null;

        /// <summary>
        /// Obtient la liste des vues à afficher.
        /// </summary>
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<IPageViewModel>();
                }

                return _pageViewModels;
            }
        }

        /// <summary>
        /// Vue affichée.
        /// </summary>
        private IPageViewModel _currentPageViewModel = null;

        /// <summary>
        /// Obtient ou définit la vue affichée.
        /// </summary>
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }

            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }
        #endregion

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ApplicationView"/>.
        /// </summary>
        public ApplicationView()
        {
            // Initialisation des composants.
            InitializeComponent();

            // Binding du contexte
            DataContext = this;

            // Affichage de la page principale
            ExampleCommandBackToHomeView();
        }

        #region Implémentation du INotifyPropertyChanged
        /// <summary>
        /// Evènement levé à la modification.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Appelé lors d'une modification.
        /// </summary>
        /// <param name="propertyName">La propriété qui a été modifiée.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        /// <summary>
        /// Changement de fenêtre.
        /// </summary>
        /// <param name="viewModel">La vue à afficher.</param>
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
            {
                // Si la vue n'existe pas encore dans la liste, on l'ajoute
                PageViewModels.Add(viewModel);
            }

            // Changement de fenêtre si valide
            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);

            if (CurrentPageViewModel != null)
            {
                // Changement du titre
                CustomWindowTitle = CurrentPageViewModel.Title;
            }
        }

        /// <summary>
        /// Exemple de fonction appelée pour changer de vue.
        /// </summary>
        private void ExampleCommandBackToHomeView()
        {
            HomeViewModel homeVM = PageViewModels.FirstOrDefault(vm => vm.GetType() == typeof(HomeViewModel)) as HomeViewModel;
            if (homeVM == null)
            {
                // Création d'une nouvelle vue
                homeVM = new HomeViewModel();
                homeVM.ExampleNavigate += OnExampleNavigate;
            }
            else
            {
                // Traitement sur la vue
                homeVM.Counter = -1;
            }

            ChangeViewModel((IPageViewModel)homeVM);
        }

        /// <summary>
        /// Demande d'appel à la fonction exemple.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private void OnExampleNavigate(object sender, System.EventArgs e)
        {
            HomeViewModel homeVM = PageViewModels.FirstOrDefault(vm => vm.GetType() == typeof(HomeViewModel)) as HomeViewModel;
            if (homeVM != null)
            {
                homeVM.Counter++;
            }
        }
    }
}
