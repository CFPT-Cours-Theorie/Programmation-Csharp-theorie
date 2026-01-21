using Ex05_SimulBDD.Models;
using Ex05_SimulBDD.Services;
using Ex05_SimulBDD.Views;

namespace Ex05
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var repository = new ProduitRepository();
            var view = new ProduitView();

            // 1️. Tous les produits
            Console.WriteLine("Tous les produits :");
            var produits = await repository.ObtenirTousProduitsAsync();
            view.AfficherListeProduits(produits);
            Console.WriteLine();

            // 2️. Produit par ID
            Console.WriteLine("Produit par ID :");
            var produit = await repository.ObtenirProduitParIdAsync(2);
            if (produit != null)
            {
                view.AfficherProduit(produit);
            }
            Console.WriteLine();

            // 3️. Ajout d’un produit
            Console.WriteLine("Ajout d'un produit :");
            Produit nouveauProduit = new Produit(4, "Casque", 89.90m, 15);
            await repository.AjouterProduitAsync(nouveauProduit);
            view.AfficherListeProduits(await repository.ObtenirTousProduitsAsync());
            Console.WriteLine();

            // 4️. Mise à jour du stock
            Console.WriteLine("Mise à jour du stock :");
            await repository.MettreAJourStockAsync(1, 20);
            view.AfficherProduit(await repository.ObtenirProduitParIdAsync(1)!);
            Console.WriteLine();

            // ⭐ BONUS : Recherche
            string keySearch = "s";
            Console.WriteLine($"Recherche par {keySearch} :");
            var recherches = await repository.RechercherProduitsAsync(keySearch);
            view.AfficherListeProduits(recherches);
        }
    }
}
