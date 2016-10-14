using System.ComponentModel;

namespace Jojo.WPF.Skeleton.Helpers.MVVM
{
    /// <summary>
    /// Implémentation de l'interface <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Evènement levé à la modification d'une propriété.
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
    }
}
