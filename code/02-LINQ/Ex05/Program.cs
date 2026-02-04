using Ex05_RegroupementGroupBy.Models;
using Ex05_RegroupementGroupBy.Services;
using Ex05_RegroupementGroupBy.Views;

namespace Ex05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var commandes = new List<Commande>
            {
                new Commande { Id = 1, Client = "Alice", Produit = "Laptop", Quantite = 1, PrixUnitaire = 1200m, DateCommande = new DateTime(2024, 1, 15) },
                new Commande { Id = 2, Client = "Bob", Produit = "Souris", Quantite = 2, PrixUnitaire = 25m, DateCommande = new DateTime(2024, 1, 20) },
                new Commande { Id = 3, Client = "Alice", Produit = "Clavier", Quantite = 1, PrixUnitaire = 80m, DateCommande = new DateTime(2024, 2, 5) },
                new Commande { Id = 4, Client = "Charlie", Produit = "Écran", Quantite = 2, PrixUnitaire = 300m, DateCommande = new DateTime(2024, 2, 10) },
                new Commande { Id = 5, Client = "Bob", Produit = "Laptop", Quantite = 1, PrixUnitaire = 1200m, DateCommande = new DateTime(2024, 3, 1) }
            };

            var service = new CommandeService(commandes);
            var view = new CommandeView();

            // 1️⃣ Groupes par client
            var groupesClient = service.GrouperParClient();
            view.AfficherGroupesParClient(groupesClient);

            // 2️⃣ Résumé par client
            var resumes = service.ObtenirResumeParClient();
            view.AfficherResumes(resumes);

            // 3️⃣ Chiffre d'affaires par mois
            Console.WriteLine("\n--- Chiffre d'affaires mensuel ---");
            foreach (var groupe in service.GrouperParMois())
            {
                var total = groupe.Sum(c => c.Quantite * c.PrixUnitaire);
                Console.WriteLine($"Mois {groupe.Key} : CHF {total:0.00}");
            }

            // ⭐ Bonus
            Console.WriteLine(
                $"\nClient avec le plus de commandes : {service.ObtenirClientAvecLePlusDeCommandes()}");
        }
    }
}
