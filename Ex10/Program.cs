using Ex10.Services;
using Ex10.Views;

namespace Ex10
{
    internal class Program
    {
        static async Task Main()
        {
            /*
             * Il y a un problème au niveau de l'API !
             */
            const string apiKey = "07fe7c9cb884df2bdc06c47ec07b6e87"; // 🔑 OpenWeatherMap
            var villes = new List<string>
            {
                "Paris", "Londres", "New York", "Tokyo", "Sydney"
            };

            var client = new HttpClient();
            var cache = new CacheService();
            var meteoService = new MeteoService(client, apiKey, cache);
            var fichierService = new FichierService();
            var view = new MeteoView();

            using var cts = new CancellationTokenSource();

            Console.WriteLine("Appuyez sur une touche pour annuler...\n");
            Task.Run(() =>
            {
                Console.ReadKey();
                cts.Cancel();
            });

            var progress = new Progress<int>(p =>
            {
                Console.WriteLine($"Progression globale : {p}%");
            });

            try
            {
                var resultats = await meteoService.ObtenirPlusieursVillesAsync(
                    villes,
                    progress,
                    cts.Token);

                view.AfficherTableauMeteo(resultats);

                var succes = resultats
                    .Where(r => r.Succes)
                    .Select(r => r.Meteo)
                    .ToList();

                await fichierService.SauvegarderCsvAsync(succes, "meteo.csv");
                Console.WriteLine("\nDonnées sauvegardées dans meteo.csv");
            }
            catch (OperationCanceledException)
            {
                view.AfficherErreur("Opération annulée par l'utilisateur");
            }
        }
    }
}
