using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex06_OperationsEnsemblistes.Models;

namespace Ex06_OperationsEnsemblistes.Services
{
    internal class RecrutementService
    {
        // Toutes les compétences uniques de tous les candidats
        public IEnumerable<string> ObtenirCompetencesUniques(List<Candidat> candidats)
        {
            return candidats
                .SelectMany(c => c.Competences)
                .Select(comp => comp.Nom)
                .Distinct();
        }

        // Compétences communes entre deux candidats
        public IEnumerable<string> ObtenirCompetencesCommunes(Candidat candidat1, Candidat candidat2)
        {
            return candidat1.Competences
                .Select(c => c.Nom)
                .Intersect(candidat2.Competences.Select(c => c.Nom));
        }

        // Compétences manquantes pour une offre
        public IEnumerable<string> ObtenirCompetencesManquantes(Candidat candidat, OffreEmploi offre)
        {
            return offre.CompetencesRequises
                .Select(c => c.Nom)
                .Except(candidat.Competences.Select(c => c.Nom));
        }

        // Toutes les compétences combinées de deux candidats
        public IEnumerable<string> ObtenirToutesCompetences(Candidat candidat1, Candidat candidat2)
        {
            return candidat1.Competences
                .Select(c => c.Nom)
                .Union(candidat2.Competences.Select(c => c.Nom));
        }

        // ⭐ Bonus : meilleur candidat pour une offre
        public Candidat TrouverMeilleurCandidatPourOffre(
            List<Candidat> candidats,
            OffreEmploi offre)
        {
            return candidats
                .OrderByDescending(c =>
                    c.Competences
                     .Select(comp => comp.Nom)
                     .Intersect(offre.CompetencesRequises.Select(o => o.Nom))
                     .Count())
                .First();
        }
    }
}
