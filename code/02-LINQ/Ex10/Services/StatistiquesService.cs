using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Services
{
    internal class StatistiquesService
    {
        public StatistiquesBibliotheque CalculerStatistiques(List<Livre> livres, List<Emprunt> emprunts)
        {
            return new StatistiquesBibliotheque
            {
                TotalLivres = livres.Count,
                LivresDisponibles = livres.Count(l => l.EstDisponible),
                LivresEmpruntes = livres.Count(l => !l.EstDisponible),
                EmpruntsEnRetard = emprunts.Count(e =>
                    e.DateRetourEffective == null &&
                    e.DateRetourPrevue < DateTime.Now)
            };
        }

        public IEnumerable<RapportGenre> GenererRapportParGenre(List<Livre> livres, List<Emprunt> emprunts)
        {
            return livres
                .GroupBy(l => l.Genre)
                .Select(g =>
                {
                    var livresGenre = g.ToList();
                    var empruntsGenre = emprunts
                        .Where(e => livresGenre.Any(l => l.Id == e.LivreId))
                        .ToList();

                    var livreLePlusEmprunte = empruntsGenre
                        .GroupBy(e => e.LivreId)
                        .OrderByDescending(gr => gr.Count())
                        .Select(gr =>
                            livres.First(l => l.Id == gr.Key).Titre)
                        .FirstOrDefault();

                    return new RapportGenre
                    {
                        Genre = g.Key,
                        NombreLivres = livresGenre.Count,
                        NombreEmprunts = empruntsGenre.Count,
                        LivreLePlusEmprunte = livreLePlusEmprunte ?? "Aucun"
                    };
                });
        }
    }
}
