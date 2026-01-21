using Ex04.Models;
using Ex04.Services;
using Ex04.Views;

namespace Ex04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ventes = new List<Vente>
            {
                new Vente { Id = 1, DateVente = new DateTime(2024, 1, 10), Montant = 450, Vendeur = "Alice", Region = "Suisse" },
                new Vente { Id = 2, DateVente = new DateTime(2024, 1, 15), Montant = 720, Vendeur = "Bob", Region = "France" },
                new Vente { Id = 3, DateVente = new DateTime(2024, 2, 5), Montant = 300, Vendeur = "Alice", Region = "Suisse" },
                new Vente { Id = 4, DateVente = new DateTime(2024, 2, 20), Montant = 980, Vendeur = "Charlie", Region = "Allemagne" },
                new Vente { Id = 5, DateVente = new DateTime(2024, 3, 3), Montant = 560, Vendeur = "Bob", Region = "France" },
                new Vente { Id = 6, DateVente = new DateTime(2024, 3, 18), Montant = 1200, Vendeur = "Alice", Region = "Suisse" },
                new Vente { Id = 7, DateVente = new DateTime(2024, 3, 25), Montant = 410, Vendeur = "Charlie", Region = "Allemagne" },
                new Vente { Id = 8, DateVente = new DateTime(2024, 4, 2), Montant = 890, Vendeur = "Bob", Region = "France" }
            };

            var service = new VenteService(ventes);
            var view = new StatistiquesView();

            view.AfficherStatistiques(
                service.CalculerStatistiquesGlobales(),
                "Statistiques globales");

            view.AfficherStatistiques(
                service.CalculerStatistiquesParVendeur("Alice"),
                "Statistiques pour Alice");

            Console.WriteLine($"\nVentes > 500 CHF : {service.CompterVentesSuperieurA(500)}");

            Console.WriteLine(
                $"Chiffre d'affaires Mars 2024 : {service.CalculerChiffreAffairesMois(3, 2024)} CHF");

            Console.WriteLine(
                $"Meilleur vendeur : {service.ObtenirMeilleurVendeur()}");
        }
    }
}
