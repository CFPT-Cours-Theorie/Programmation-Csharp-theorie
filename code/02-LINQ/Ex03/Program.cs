using Ex03_ProjectionSelect.Models;
using Ex03_ProjectionSelect.Services;
using Ex03_ProjectionSelect.Views;

namespace Ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var produits = new List<Produit>
            {
                new Produit { Id = 1, Nom = "Laptop", PrixHT = 1200m, TauxTVA = 7.7, Categorie = "Informatique", Stock = 5 },
                new Produit { Id = 2, Nom = "Souris", PrixHT = 25m, TauxTVA = 7.7, Categorie = "Informatique", Stock = 0 },
                new Produit { Id = 3, Nom = "Chaise", PrixHT = 150m, TauxTVA = 7.7, Categorie = "Mobilier", Stock = 3 },
                new Produit { Id = 4, Nom = "Livre C#", PrixHT = 45m, TauxTVA = 2.5, Categorie = "Livre", Stock = 10 },
                new Produit { Id = 5, Nom = "Café", PrixHT = 3.5m, TauxTVA = 2.5, Categorie = "Alimentaire", Stock = 100 }
            };

            var service = new ProduitService(produits);
            var view = new ProduitView();

            // Noms en majuscules
            view.AfficherNoms(service.ObtenirNomsEnMajuscules());

            // Produits avec prix TTC
            view.AfficherProduitsFormates(
                service.ObtenirProduitsAvecPrixTTC());

            // Descriptions formatées
            Console.WriteLine("\n--- Descriptions ---");
            foreach (var desc in service.ObtenirDescriptionsFormatees())
                Console.WriteLine(desc);

            // BONUS
            Console.WriteLine("\n--- Projection anonyme ---");
            foreach (var p in service.ObtenirNomEtPrixTtcAnonyme())
                Console.WriteLine(p);
        }
    }
}
