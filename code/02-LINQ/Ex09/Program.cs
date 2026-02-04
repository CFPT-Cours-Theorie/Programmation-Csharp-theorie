using Ex09.Models;
using Ex09.Services;
using Ex09.Views;

namespace Ex09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var films = new List<Film>
            {
                new() { Id = 1, Titre = "Inception", Annee = 2010, Genre = "Science-Fiction", Note = 8.8, Duree = 148, Realisateur = "Christopher Nolan" },
                new() { Id = 2, Titre = "Interstellar", Annee = 2014, Genre = "Science-Fiction", Note = 8.6, Duree = 169, Realisateur = "Christopher Nolan" },
                new() { Id = 3, Titre = "The Dark Knight", Annee = 2008, Genre = "Action", Note = 9.0, Duree = 152, Realisateur = "Christopher Nolan" },
                new() { Id = 4, Titre = "Mad Max Fury Road", Annee = 2015, Genre = "Action", Note = 8.1, Duree = 120, Realisateur = "George Miller" },
                new() { Id = 5, Titre = "Gladiator", Annee = 2000, Genre = "Drame", Note = 8.5, Duree = 155, Realisateur = "Ridley Scott" },
                new() { Id = 6, Titre = "The Hangover", Annee = 2009, Genre = "Comédie", Note = 7.7, Duree = 100, Realisateur = "Todd Phillips" },
                new() { Id = 7, Titre = "Joker", Annee = 2019, Genre = "Drame", Note = 8.4, Duree = 122, Realisateur = "Todd Phillips" },
                new() { Id = 8, Titre = "Get Out", Annee = 2017, Genre = "Horreur", Note = 7.8, Duree = 104, Realisateur = "Jordan Peele" },
                new() { Id = 9, Titre = "Us", Annee = 2019, Genre = "Horreur", Note = 6.9, Duree = 116, Realisateur = "Jordan Peele" },
                new() { Id = 10, Titre = "Tenet", Annee = 2020, Genre = "Action", Note = 7.3, Duree = 150, Realisateur = "Christopher Nolan" }
                // ➜ ajoute facilement jusqu’à 20+
            };

            var service = new FilmService(films);
            var view = new FilmView();

            // Recherche combinée
            view.AfficherFilms(
                service.RechercherFilms("Action", 2010, 7));

            // Statistiques par genre
            view.AfficherStatistiquesGenre(
                service.ObtenirStatistiquesParGenre());

            // Top 3 Action
            view.AfficherFilms(
                service.ObtenirTopFilmsParGenre("Action", 3));

            // Réalisateurs prolifiques
            Console.WriteLine("\n--- Réalisateurs prolifiques ---");
            foreach (var r in service.ObtenirRealisateursProlifiques(2))
                Console.WriteLine(r);

            // BONUS
            Console.WriteLine(
                $"\nAnnée la plus prolifique : {service.AnneeLaPlusProlifique()}");
        }
    }
}
