using Ex01.Models;
using Ex01.Services;
using Ex01.Views;

namespace Ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var etudiants = new List<Etudiant>
            {
                new Etudiant { Id = 1, Nom = "Dupont", Prenom = "Jean", Age = 22, Moyenne = 14.5 },
                new Etudiant { Id = 2, Nom = "Martin", Prenom = "Marie", Age = 17, Moyenne = 16.0 },
                new Etudiant { Id = 3, Nom = "Durand", Prenom = "Paul", Age = 19, Moyenne = 11.2 },
                new Etudiant { Id = 4, Nom = "Leroy", Prenom = "Sophie", Age = 24, Moyenne = 13.8 },
                new Etudiant { Id = 5, Nom = "Moreau", Prenom = "Lucas", Age = 21, Moyenne = 9.5 },
                new Etudiant { Id = 6, Nom = "Petit", Prenom = "Emma", Age = 20, Moyenne = 15.1 },
                new Etudiant { Id = 7, Nom = "Garcia", Prenom = "Hugo", Age = 26, Moyenne = 12.4 },
                new Etudiant { Id = 8, Nom = "Bernard", Prenom = "Julie", Age = 18, Moyenne = 10.0 },
                new Etudiant { Id = 9, Nom = "Roux", Prenom = "Nicolas", Age = 23, Moyenne = 17.3 },
                new Etudiant { Id = 10, Nom = "Dubois", Prenom = "Claire", Age = 16, Moyenne = 14.0 }
            };

            var service = new EtudiantService(etudiants);
            var view = new EtudiantView();

            view.AfficherListeEtudiants(
                service.ObtenirEtudiantsMajeurs(),
                "Étudiants majeurs");

            view.AfficherListeEtudiants(
                service.ObtenirEtudiantsAvecMoyenneSuperieure(12),
                "Étudiants avec moyenne > 12");

            view.AfficherListeEtudiants(
                service.ObtenirEtudiantsParTrancheAge(20, 25),
                "Étudiants entre 20 et 25 ans");

            // BONUS
            view.AfficherListeEtudiants(
                service.ObtenirEtudiantsDontNomCommencePar('D'),
                "Étudiants dont le nom commence par D");
        }
    }
}
