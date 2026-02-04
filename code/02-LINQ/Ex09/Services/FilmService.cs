using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex09.Models;

namespace Ex09.Services
{
    internal class FilmService
    {
        private readonly List<Film> _films;

        public FilmService(List<Film> films)
        {
            _films = films;
        }

        // Recherche combinée avec filtres optionnels
        public IEnumerable<Film> RechercherFilms(
            string genre,
            int? anneeMin,
            double? noteMin)
        {
            return _films
                .Where(f =>
                    (genre == null || f.Genre == genre) &&
                    (!anneeMin.HasValue || f.Annee >= anneeMin) &&
                    (!noteMin.HasValue || f.Note >= noteMin))
                .OrderByDescending(f => f.Note);
        }

        // Statistiques par genre
        public IEnumerable<StatistiquesGenre> ObtenirStatistiquesParGenre()
        {
            return _films
                .GroupBy(f => f.Genre)
                .Select(g => new StatistiquesGenre
                {
                    Genre = g.Key,
                    NombreFilms = g.Count(),
                    NoteMoyenne = Math.Round(g.Average(f => f.Note), 2),
                    MeilleurFilm = g
                        .OrderByDescending(f => f.Note)
                        .First().Titre
                })
                .OrderByDescending(s => s.NombreFilms);
        }

        // Top N films par genre
        public IEnumerable<Film> ObtenirTopFilmsParGenre(string genre, int nombre)
        {
            return _films
                .Where(f => f.Genre == genre)
                .OrderByDescending(f => f.Note)
                .Take(nombre);
        }

        // Réalisateurs prolifiques
        public IEnumerable<string> ObtenirRealisateursProlifiques(int nombreFilmsMin)
        {
            return _films
                .GroupBy(f => f.Realisateur)
                .Where(g => g.Count() >= nombreFilmsMin)
                .Select(g => g.Key);
        }

        // BONUS : année avec le plus de films
        public int AnneeLaPlusProlifique()
        {
            return _films
                .GroupBy(f => f.Annee)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }
    }
}
