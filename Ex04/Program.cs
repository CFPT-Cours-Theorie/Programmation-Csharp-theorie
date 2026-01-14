using Ex04.Services;
using Ex04.Views;

namespace Ex04
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var urls = new List<string>
            {
                "https://example.com",
                "https://httpbin.org/html",
                "https://jsonplaceholder.typicode.com/posts",
                "https://www.ietf.org"
            };

            var service = new WebService();
            var view = new PerformanceView();

            // Séquentiel
            var resultatsSequentiels = await service.TelechargerSequentiellementAsync(urls);

            // Parallèle
            var resultatsParalleles = await service.TelechargerEnParalleleAsync(urls);

            // Comparaison
            view.AfficherComparaison(resultatsSequentiels, resultatsParalleles);

            // ⭐ BONUS
            Console.WriteLine("\n--- BONUS : résultats au fil de l’eau ---");
            await service.TelechargerAvecRetourProgressifAsync(
                urls,
                r => Console.WriteLine($"Reçu : {r.Url} en {r.Duree.TotalMilliseconds} ms"));
        }
    }
}
