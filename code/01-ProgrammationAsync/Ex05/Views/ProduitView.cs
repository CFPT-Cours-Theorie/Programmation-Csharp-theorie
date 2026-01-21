using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex05_SimulBDD.Models;

namespace Ex05_SimulBDD.Views
{
    internal class ProduitView
    {
        public void AfficherProduit(Produit produit)
        {
            Console.WriteLine("----- Produit -----");
            Console.WriteLine($"ID     : {produit.Id}");
            Console.WriteLine($"Nom    : {produit.Nom}");
            Console.WriteLine($"Prix   : {produit.Prix} CHF");
            Console.WriteLine($"Stock  : {produit.Stock}");
        }

        public void AfficherListeProduits(List<Produit> produits)
        {
            Console.WriteLine("----- Liste des produits -----");

            foreach (var p in produits)
            {
                Console.WriteLine($"{p.Id} - {p.Nom} | {p.Prix} CHF | Stock : {p.Stock}");
            }
        }
    }
}
