using Ex06_OperationsEnsemblistes.Models;
using Ex06_OperationsEnsemblistes.Services;
using Ex06_OperationsEnsemblistes.Views;

namespace Ex06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Candidat
            {
                Id = 1,
                Nom = "Alice",
                Competences = new List<Competence>
                {
                    new Competence { Id = 1, Nom = "C#", Niveau = 4 },
                    new Competence { Id = 2, Nom = "SQL", Niveau = 3 },
                    new Competence { Id = 3, Nom = "Git", Niveau = 4 }
                }
            };

            var c2 = new Candidat
            {
                Id = 2,
                Nom = "Bob",
                Competences = new List<Competence>
                {
                    new Competence { Id = 4, Nom = "C#", Niveau = 3 },
                    new Competence { Id = 5, Nom = "JavaScript", Niveau = 4 },
                    new Competence { Id = 6, Nom = "Docker", Niveau = 2 }
                }
            };

            var c3 = new Candidat
            {
                Id = 3,
                Nom = "Charlie",
                Competences = new List<Competence>
                {
                    new Competence { Id = 7, Nom = "Python", Niveau = 5 },
                    new Competence { Id = 8, Nom = "Git", Niveau = 3 },
                    new Competence { Id = 9, Nom = "Docker", Niveau = 4 }
                }
            };

            var offre = new OffreEmploi
            {
                Id = 1,
                Titre = "Développeur Full Stack",
                CompetencesRequises = new List<Competence>
                {
                    new Competence { Nom = "C#" },
                    new Competence { Nom = "JavaScript" },
                    new Competence { Nom = "SQL" },
                    new Competence { Nom = "Docker" }
                }
            };

            var candidats = new List<Candidat> { c1, c2, c3 };
            var service = new RecrutementService();
            var view = new RecrutementView();

            view.AfficherCompetences(
                service.ObtenirCompetencesUniques(candidats),
                "Compétences uniques de tous les candidats");

            view.AfficherCompetences(
                service.ObtenirCompetencesCommunes(c1, c2),
                "Compétences communes entre Alice et Bob");

            view.AfficherCompetences(
                service.ObtenirCompetencesManquantes(c1, offre),
                "Compétences manquantes pour Alice");

            view.AfficherCompetences(
                service.ObtenirToutesCompetences(c1, c2),
                "Toutes les compétences Alice + Bob");

            var meilleur = service.TrouverMeilleurCandidatPourOffre(candidats, offre);
            Console.WriteLine($"\n⭐ Meilleur candidat pour l'offre : {meilleur.Nom}");
        }
    }
}
