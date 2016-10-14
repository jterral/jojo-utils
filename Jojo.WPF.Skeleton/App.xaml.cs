using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Jojo.WPF.Skeleton
{
    /// <summary>
    /// Logique d'interaction pour l'application principale.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Chargement de l'application.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            new ApplicationView().Show();
        }
    }
}
