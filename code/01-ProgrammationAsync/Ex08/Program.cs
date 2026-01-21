using System.Diagnostics;
using Ex08_ProgressionIProgress.Models;
using Ex08_ProgressionIProgress.Services;
using Ex08_ProgressionIProgress.Views;

namespace Ex08
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var service = new TraitementService();
            var view = new ProgressionView();

            async Task Tester(int etapes)
            {
                Console.WriteLine($"\n--- Test avec {etapes} étapes ---");

                var stopwatch = Stopwatch.StartNew();

                var progress = new Progress<InfoProgression>(info =>
                {
                    view.AfficherBarreProgression(info);
                });

                await service.TraiterDonneesAvecProgressionAsync(etapes, progress);

                stopwatch.Stop();
                view.AfficherCompletion(stopwatch.Elapsed);
            }

            await Tester(10);
            await Tester(20);
            // await Tester(50);
        }
    }
}
