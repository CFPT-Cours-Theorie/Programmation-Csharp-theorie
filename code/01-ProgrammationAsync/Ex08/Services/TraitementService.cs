using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex08_ProgressionIProgress.Models;

namespace Ex08_ProgressionIProgress.Services
{
    internal class TraitementService
    {
        public async Task TraiterDonneesAvecProgressionAsync(
            int nombreEtapes,
            IProgress<InfoProgression> progression)
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 1; i <= nombreEtapes; i++)
            {
                // Simulation d’une étape
                await Task.Delay(500);

                int pourcentage = (int)(i / (double)nombreEtapes * 100);
                TimeSpan tempsEcoule = stopwatch.Elapsed;

                // ⭐ BONUS : estimation du temps restant
                TimeSpan tempsRestant = TimeSpan.Zero;
                if (i > 0)
                {
                    double ratio = i / (double)nombreEtapes;
                    tempsRestant = TimeSpan.FromMilliseconds(
                        tempsEcoule.TotalMilliseconds * (1 - ratio) / ratio);
                }

                progression.Report(new InfoProgression
                {
                    Pourcentage = pourcentage,
                    EtapeCourante = i,
                    EtapesTotal = nombreEtapes,
                    TempsEcoule = tempsEcoule,
                    TempsRestantEstime = tempsRestant
                });
            }

            stopwatch.Stop();
        }
    }
}
