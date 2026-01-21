using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Models;

namespace Ex04.Services
{
    internal class VenteService
    {
        private List<Vente> _ventes;

        public VenteService(List<Vente> ventes)
        {
            _ventes = ventes;
        }

        // 📊 Statistiques globales
        public StatistiquesVente CalculerStatistiquesGlobales()
        {
            return new StatistiquesVente
            {
                NombreVentes = _ventes.Count(),
                MontantTotal = _ventes.Sum(v => v.Montant),
                MontantMoyen = _ventes.Average(v => v.Montant),
                MontantMin = _ventes.Min(v => v.Montant),
                MontantMax = _ventes.Max(v => v.Montant)
            };
        }

        // 📊 Statistiques par vendeur
        public StatistiquesVente CalculerStatistiquesParVendeur(string vendeur)
        {
            var ventesVendeur = _ventes
                .Where(v => v.Vendeur.Equals(vendeur, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!ventesVendeur.Any())
                return new StatistiquesVente();

            return new StatistiquesVente
            {
                NombreVentes = ventesVendeur.Count(),
                MontantTotal = ventesVendeur.Sum(v => v.Montant),
                MontantMoyen = ventesVendeur.Average(v => v.Montant),
                MontantMin = ventesVendeur.Min(v => v.Montant),
                MontantMax = ventesVendeur.Max(v => v.Montant)
            };
        }

        // 🔢 Compter les ventes > seuil
        public int CompterVentesSuperieurA(decimal seuil)
        {
            return _ventes.Count(v => v.Montant > seuil);
        }

        // 📅 Chiffre d'affaires par mois
        public decimal CalculerChiffreAffairesMois(int mois, int annee)
        {
            return _ventes
                .Where(v => v.DateVente.Month == mois && v.DateVente.Year == annee)
                .Sum(v => v.Montant);
        }

        // ⭐ Bonus : meilleur vendeur
        public string ObtenirMeilleurVendeur()
        {
            return _ventes
                .GroupBy(v => v.Vendeur)
                .Select(g => new
                {
                    Vendeur = g.Key,
                    Total = g.Sum(v => v.Montant)
                })
                .OrderByDescending(x => x.Total)
                .First()
                .Vendeur;
        }
    }
}
