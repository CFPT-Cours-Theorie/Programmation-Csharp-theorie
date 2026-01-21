using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex07.Models;

namespace Ex07.Services
{
    internal class FichierService
    {
        public async Task<bool> TelechargerGrosFichierAsync(
            string url,
            CancellationToken token,
            IProgress<EtatTelechargement> progress)
        {
            const int etapes = 10;

            for (int i = 1; i <= etapes; i++)
            {
                token.ThrowIfCancellationRequested();

                // Simulation d’une étape longue
                await Task.Delay(1000, token);

                int progression = i * 10;

                progress.Report(new EtatTelechargement
                {
                    Progression = progression,
                    Statut = "En cours",
                    Message = $"Téléchargement... {progression}%"
                });
            }

            return true;
        }
    }
}
