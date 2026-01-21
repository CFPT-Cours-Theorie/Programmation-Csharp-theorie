using Ex07.Models;
using Ex07.Services;
using Ex07.Views;

namespace Ex07
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var service = new FichierService();
            var view = new ProgressionView();

            using var cts = new CancellationTokenSource();

            // Annulation automatique après 5 secondes
            cts.CancelAfter(TimeSpan.FromSeconds(5));

            // Progression thread-safe
            var progress = new Progress<EtatTelechargement>(etat =>
            {
                view.AfficherProgression(etat);
            });

            // BONUS : annulation utilisateur (touche)
            Task.Run(() =>
            {
                Console.WriteLine("Appuyez sur une touche pour annuler...");
                while (!cts.IsCancellationRequested)
                {
                    if (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                        cts.Cancel();
                        break;
                    }
                    Thread.Sleep(100);
                }
            });

            try
            {
                bool succes = await service.TelechargerGrosFichierAsync(
                    "https://example.com/grosfichier",
                    cts.Token,
                    progress);

                if (succes)
                {
                    view.AfficherCompletion();
                }
            }
            catch (OperationCanceledException)
            {
                view.AfficherAnnulation();
            }
        }
    }
}
