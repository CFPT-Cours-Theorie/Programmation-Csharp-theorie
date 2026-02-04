using Ex05_RegroupementGroupBy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_RegroupementGroupBy.Services
{
    internal class CommandeService
    {
        private readonly List<Commande> commandes;

        public CommandeService(List<Commande> commandes)
        {
            this.commandes = commandes;
        }

        // 1️⃣ Groupement simple
        public IEnumerable<IGrouping<string, Commande>> GrouperParClient()
        {
            return commandes
                .GroupBy(c => c.Client);
        }

        // 2️⃣ GroupBy + Select (projection)
        public IEnumerable<ResumeParClient> ObtenirResumeParClient()
        {
            return commandes
                .GroupBy(c => c.Client)
                .Select(g => new ResumeParClient
                {
                    NomClient = g.Key,
                    NombreCommandes = g.Count(),
                    MontantTotal = g.Sum(c => c.Quantite * c.PrixUnitaire)
                });
        }

        // 3️⃣ Groupement par mois
        public IEnumerable<IGrouping<int, Commande>> GrouperParMois()
        {
            return commandes
                .GroupBy(c => c.DateCommande.Month);
        }

        // ⭐ Bonus
        public string ObtenirClientAvecLePlusDeCommandes()
        {
            return commandes
                .GroupBy(c => c.Client)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }
    }
}
