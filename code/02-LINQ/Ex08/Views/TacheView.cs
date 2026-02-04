using Ex08_VerificationsAnyAllContains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_VerificationsAnyAllContains.Views
{
    internal class TacheView
    {
        public void AfficherResultatValidation(ResultatValidation resultat)
        {
            Console.WriteLine("\n--- Validation du projet ---");

            Console.WriteLine(resultat.EstValide
                ? "Projet valide"
                : "Projet non valide");

            foreach (var message in resultat.Messages)
            {
                Console.WriteLine($"- {message}");
            }
        }

        public void AfficherEtatProjet(bool tachesEnRetard, bool toutTermine)
        {
            Console.WriteLine("\n--- État du projet ---");

            Console.WriteLine(
                tachesEnRetard
                    ? "Des tâches sont en retard"
                    : "Aucune tâche en retard");

            Console.WriteLine(
                toutTermine
                    ? "Toutes les tâches sont terminées"
                    : "Des tâches restent à faire");
        }
    }
}
