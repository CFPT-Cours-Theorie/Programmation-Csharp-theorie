using Ex06_GestionErreurs.Models;
using Ex06_GestionErreurs.Services;
using Ex06_GestionErreurs.Views;

namespace Ex06
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var service = new TelechargementService();
            var view = new TelechargementView();
            var urls = new[]
            {
                    "https://example.com", // valide
                    "https://urlquinexistepas123456.com" // invalide
                };

            foreach (var url in urls)
            {
                Console.WriteLine($"\n=== Test URL : {url} ===");

                var historique = new List<ResultatTentative>();

                string? resultat = await service.TelechargerAvecRetryAsync(
                    url,
                    maxTentatives: 3,
                    historique: historique);

                foreach (var tentative in historique)
                {
                    view.AfficherTentative(tentative);
                }

                view.AfficherResultatFinal(resultat != null, historique);
            }
        }
    }
}
