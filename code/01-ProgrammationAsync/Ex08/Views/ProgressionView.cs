using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex08_ProgressionIProgress.Models;

namespace Ex08_ProgressionIProgress.Views
{
    internal class ProgressionView
    {
        public void AfficherBarreProgression(InfoProgression info)
        {
            const int largeurBarre = 20;
            int remplissage = info.Pourcentage * largeurBarre / 100;

            string barre =
                "[" +
                new string('=', remplissage) +
                ">" +
                new string(' ', largeurBarre - remplissage) +
                "]";

            Console.Write(
                $"\r{barre} {info.Pourcentage}% " +
                $"({info.EtapeCourante}/{info.EtapesTotal}) " +
                $"{info.TempsEcoule:mm\\:ss} " +
                $"~{info.TempsRestantEstime:mm\\:ss}");

            // FIN PROPRE DE LIGNE
            if (info.Pourcentage == 100)
            {
                Console.WriteLine();
            }
        }

        public void AfficherCompletion(TimeSpan duree)
        {
            Console.WriteLine($"Traitement terminé en {duree:mm\\:ss}");
        }
    }
}
