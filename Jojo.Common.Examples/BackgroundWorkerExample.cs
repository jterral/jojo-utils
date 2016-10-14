using System;
using System.ComponentModel;

namespace Jojo.Common.Examples
{
    /// <summary>
    /// Exemple d'utilisation du <see cref="BackgroundWorker"/>.
    /// </summary>
    public class BackgroundWorkerExample
    {
        /// <summary>
        /// Le thread en arrière plan.
        /// </summary>
        private readonly BackgroundWorker _workerExample;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BackgroundWorkerExample"/>.
        /// </summary>
        public BackgroundWorkerExample()
        {
            _workerExample = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _workerExample.DoWork += WorkerExampleDoWork;
            _workerExample.RunWorkerCompleted += WorkerExampleCompleted;
            _workerExample.ProgressChanged += WorkerExampleProgressChanged;
        }

        /// <summary>
        /// Lancement du travail en arrière plan.
        /// </summary>
        public void Start()
        {
            if (!this._workerExample.IsBusy)
            {
                this._workerExample.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Terminaison de travail en arrière plan.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private void WorkerExampleCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Background Worker Done");

            if (e.Error != null)
            {
                Console.WriteLine("Exception during execution...");
                Console.WriteLine(e.Error.Message);
            }

            if (e.Cancelled)
            {
                Console.WriteLine("Job cancelled.");
            }

            if (e.Result != null)
            {
                Console.WriteLine("Job result : " + e.Result);
            }
        }

        /// <summary>
        /// Travail en arrière plan.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private void WorkerExampleDoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Background Worker - Job start...");

            BackgroundWorker workerExample = sender as BackgroundWorker;

            for (int i = 1; (i <= 10); i++)
            {
                if (workerExample.CancellationPending)
                {
                    // En cours d'annulation
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
                    workerExample.ReportProgress(i * 10);
                }
            }

            // Mise à jour du résultat si besoin
            e.Result = "DONE";

            Console.WriteLine("Background Worker - Job end.");
        }

        /// <summary>
        /// Réception d'un message d'avancement du job en arrière plan.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        public void WorkerExampleProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + "%");
        }
    }
}
