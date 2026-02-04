using Ex03_ProjectionSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ProjectionSelect.Services
{
    internal class ProduitService
    {
        private readonly List<Produit> _produits;

        public ProduitService(List<Produit> produits)
        {
            _produits = produits;
        }

        // Projection simple : string
        public IEnumerable<string> ObtenirNomsEnMajuscules()
        {
            return _produits
                .Select(p => p.Nom.ToUpper());
        }

        // Projection vers un autre modèle
        public IEnumerable<ProduitAffichage> ObtenirProduitsAvecPrixTTC()
        {
            return _produits
                .Select(p => new ProduitAffichage
                {
                    NomComplet = $"{p.Nom} ({p.Categorie})",
                    PrixTTC = p.PrixHT * (decimal)(1 + p.TauxTVA / 100),
                    Disponibilite = p.Stock > 0 ? "En stock" : "Rupture"
                });
        }

        // Projection formatée
        public IEnumerable<string> ObtenirDescriptionsFormatees()
        {
            return _produits
                .Select(p =>
                    $"{p.Nom} - CHF {(p.PrixHT * (decimal)(1 + p.TauxTVA / 100)):0.00} (Stock: {p.Stock})");
        }

        // ⭐ Bonus : projection vers type anonyme
        public IEnumerable<object> ObtenirNomEtPrixTtcAnonyme()
        {
            return _produits
                .Select(p => new
                {
                    Nom = p.Nom,
                    PrixTTC = Math.Round(
                        p.PrixHT * (decimal)(1 + p.TauxTVA / 100), 2)
                });
        }
    }
}
