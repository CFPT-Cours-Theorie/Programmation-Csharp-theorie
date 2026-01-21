using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03_LectureEcritureFichiers.Models;

namespace Ex03_LectureEcritureFichiers.Services
{
    internal class FichierService
    {
        public async Task<string> LireFichierAsync(string chemin)
        {
            return await File.ReadAllTextAsync(chemin);
        }

        public async Task<StatistiquesTexte> TraiterTexteAsync(string texte)
        {
            return await Task.Run(() =>
            {
                var stats = new StatistiquesTexte();

                // BONUS : remplacer espaces par underscores
                stats.TexteTraite = texte.Replace(" ", "_");

                // Nombre de lignes
                stats.NombreLignes = texte
                    .Split(Environment.NewLine, StringSplitOptions.None)
                    .Length;

                // Nombre de mots
                stats.NombreMots = texte
                    .Split(new[] { ' ', '\n', '\r', '\t' },
                           StringSplitOptions.RemoveEmptyEntries)
                    .Length;

                return stats;
            });
        }

        public async Task EcrireFichierAsync(string chemin, string contenu)
        {
            await File.WriteAllTextAsync(chemin, contenu);
        }
    }
}
