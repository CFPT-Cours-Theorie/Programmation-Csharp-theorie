using Ex08_VerificationsAnyAllContains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_VerificationsAnyAllContains.Services
{
    internal class TacheService
    {
        private readonly List<Tache> taches;

        public TacheService(List<Tache> taches)
        {
            this.taches = taches;
        }

        // 1️⃣ Any
        public bool ExisteTachesEnRetard()
        {
            return taches.Any(t =>
                !t.EstTerminee &&
                t.DateEcheance < DateTime.Now);
        }

        // 2️⃣ All
        public bool ToutesTachesTerminees()
        {
            return taches.All(t => t.EstTerminee);
        }

        // 3️⃣ Any avec condition
        public bool ExisteTacheAvecPriorite(int priorite)
        {
            return taches.Any(t => t.Priorite == priorite);
        }

        // 4️⃣ Validation globale
        public ResultatValidation ValiderListeTaches()
        {
            var resultat = new ResultatValidation { EstValide = true };

            if (ExisteTachesEnRetard())
            {
                resultat.EstValide = false;
                resultat.Messages.Add("Il existe des tâches en retard.");
            }

            if (!ToutesTachesTerminees())
            {
                resultat.Messages.Add("Toutes les tâches ne sont pas terminées.");
            }

            if (ExisteTacheAvecPriorite(5))
            {
                resultat.Messages.Add("Attention : des tâches urgentes (priorité 5) existent.");
            }

            return resultat;
        }

        // ⭐ Bonus
        public bool ToutesTachesUrgentesTerminees()
        {
            return taches
                .Where(t => t.Priorite == 5)
                .All(t => t.EstTerminee);
        }
    }
}
