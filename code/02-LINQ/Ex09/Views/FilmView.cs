using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex09.Models;

namespace Ex09.Views
{
    internal class FilmView
    {
        public void AfficherFilms(IEnumerable<Film> films)
        {
            Console.WriteLine("\n--- Films ---");

            foreach (var f in films)
            {
                Console.WriteLine(
                    $"{f.Titre} ({f.Annee}) | {f.Genre} | * {f.Note} | {f.Realisateur}");
            }
        }

        public void AfficherStatistiquesGenre(IEnumerable<StatistiquesGenre> stats)
        {
            Console.WriteLine("\n--- Statistiques par genre ---");

            foreach (var s in stats)
            {
                Console.WriteLine(
                    $"{s.Genre} : {s.NombreFilms} films | Moyenne * {s.NoteMoyenne} | Meilleur : {s.MeilleurFilm}");
            }
        }
    }
}
