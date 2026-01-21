using Ex02.Models;
using Ex02.Services;
using Ex02.Views;

namespace Ex02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employes = new List<Employe>
            {
                new Employe { Id = 1, Nom = "Dupont", Prenom = "Jean", Departement = "Informatique", Salaire = 6000, DateEmbauche = new DateTime(2018, 3, 12) },
                new Employe { Id = 2, Nom = "Martin", Prenom = "Claire", Departement = "Marketing", Salaire = 5200, DateEmbauche = new DateTime(2020, 6, 5) },
                new Employe { Id = 3, Nom = "Durand", Prenom = "Paul", Departement = "Comptabilité", Salaire = 4800, DateEmbauche = new DateTime(2017, 9, 20) },
                new Employe { Id = 4, Nom = "Bernard", Prenom = "Sophie", Departement = "Informatique", Salaire = 7200, DateEmbauche = new DateTime(2015, 1, 10) },
                new Employe { Id = 5, Nom = "Leroy", Prenom = "Lucas", Departement = "Marketing", Salaire = 4500, DateEmbauche = new DateTime(2022, 2, 14) },
                new Employe { Id = 6, Nom = "Petit", Prenom = "Emma", Departement = "Comptabilité", Salaire = 5000, DateEmbauche = new DateTime(2019, 11, 3) },
                new Employe { Id = 7, Nom = "Roux", Prenom = "Nicolas", Departement = "Informatique", Salaire = 6500, DateEmbauche = new DateTime(2021, 8, 1) },
                new Employe { Id = 8, Nom = "Moreau", Prenom = "Julie", Departement = "Marketing", Salaire = 5800, DateEmbauche = new DateTime(2016, 4, 18) },
                new Employe { Id = 9, Nom = "Garcia", Prenom = "Hugo", Departement = "Comptabilité", Salaire = 4700, DateEmbauche = new DateTime(2023, 1, 9) },
                new Employe { Id = 10, Nom = "Dubois", Prenom = "Claire", Departement = "Informatique", Salaire = 7000, DateEmbauche = new DateTime(2014, 7, 25) }
            };

            var service = new EmployeService(employes);
            var view = new EmployeView();

            view.AfficherTableauEmployes(
                service.TrierParSalaireCroissant(),
                "Salaire croissant");

            view.AfficherTableauEmployes(
                service.TrierParSalaireDecroissant(),
                "Salaire décroissant");

            view.AfficherTableauEmployes(
                service.TrierParDepartementPuisNom(),
                "Par département puis nom");

            view.AfficherTableauEmployes(
                service.TrierParAnciennete(),
                "Par ancienneté (plus ancien en premier)");

            // Bonus
            view.AfficherTableauEmployes(
                service.TrierParDepartementPuisSalaireDecroissant(),
                "Par département puis salaire décroissant");
        }
    }
}
