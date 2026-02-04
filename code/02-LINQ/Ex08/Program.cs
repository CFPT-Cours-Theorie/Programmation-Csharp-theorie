using Ex08_VerificationsAnyAllContains.Models;
using Ex08_VerificationsAnyAllContains.Services;
using Ex08_VerificationsAnyAllContains.Views;

namespace Ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taches = new List<Tache>
            {
                new Tache
                {
                    Id = 1,
                    Titre = "Analyse",
                    EstTerminee = true,
                    Priorite = 3,
                    DateEcheance = DateTime.Now.AddDays(-2)
                },
                new Tache
                {
                    Id = 2,
                    Titre = "Développement",
                    EstTerminee = false,
                    Priorite = 5,
                    DateEcheance = DateTime.Now.AddDays(-1)
                },
                new Tache
                {
                    Id = 3,
                    Titre = "Tests",
                    EstTerminee = false,
                    Priorite = 2,
                    DateEcheance = DateTime.Now.AddDays(3)
                }
            };

            var service = new TacheService(taches);
            var view = new TacheView();

            bool enRetard = service.ExisteTachesEnRetard();
            bool toutTermine = service.ToutesTachesTerminees();
            bool tacheUrgente = service.ExisteTacheAvecPriorite(5);

            view.AfficherEtatProjet(enRetard, toutTermine);

            Console.WriteLine(
                tacheUrgente
                    ? "\nUne tâche urgente existe"
                    : "\nAucune tâche urgente");

            var resultat = service.ValiderListeTaches();
            view.AfficherResultatValidation(resultat);

            // BONUS
            Console.WriteLine(
                service.ToutesTachesUrgentesTerminees()
                    ? "\nToutes les tâches urgentes sont terminées"
                    : "\nDes tâches urgentes ne sont pas terminées");
        }
    }
}
