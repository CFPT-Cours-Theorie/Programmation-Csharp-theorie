using Ex03_ProjectionSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ProjectionSelect.Views
{
    internal class ProduitView
    {
        public void AfficherNoms(IEnumerable<string> noms)
        {
            Console.WriteLine("\n--- Noms des produits ---");
            foreach (var nom in noms)
                Console.WriteLine(nom);
        }

        public void AfficherProduitsFormates(IEnumerable<ProduitAffichage> produits)
        {
            Console.WriteLine("\n--- Produits (affichage) ---");
            foreach (var p in produits)
                Console.WriteLine($"{p.NomComplet} | CHF {p.PrixTTC:0.00} | {p.Disponibilite}");
        }
    }
}
