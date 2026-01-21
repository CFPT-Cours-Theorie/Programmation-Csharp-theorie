using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex05_SimulBDD.Models;

namespace Ex05_SimulBDD.Services
{
    internal class ProduitRepository
    {
        // Simulation de base de données en mémoire
        private static readonly List<Produit> _produits = new()
        {
            new Produit(1, "Clavier", 49.90m, 10),
            new Produit(2, "Souris", 29.90m, 25),
            new Produit(3, "Écran", 199.00m, 5)
        };

        private const int DelaiSimulationMs = 500;

        public async Task<List<Produit>> ObtenirTousProduitsAsync()
        {
            await Task.Delay(DelaiSimulationMs);
            return _produits.ToList(); // copie pour éviter effets de bord
        }

        public async Task<Produit?> ObtenirProduitParIdAsync(int id)
        {
            await Task.Delay(DelaiSimulationMs);
            return _produits.FirstOrDefault(p => p.Id == id);
        }

        public async Task AjouterProduitAsync(Produit produit)
        {
            await Task.Delay(DelaiSimulationMs);
            _produits.Add(produit);
        }

        public async Task MettreAJourStockAsync(int id, int nouveauStock)
        {
            await Task.Delay(DelaiSimulationMs);
            var produit = _produits.FirstOrDefault(p => p.Id == id);

            if (produit != null)
            {
                produit.Stock = nouveauStock;
            }
        }

        // ⭐ BONUS
        public async Task<List<Produit>> RechercherProduitsAsync(string motCle)
        {
            await Task.Delay(DelaiSimulationMs);

            return _produits
                .Where(p => p.Nom.Contains(motCle, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
