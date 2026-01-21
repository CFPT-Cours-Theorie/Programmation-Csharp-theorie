using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex06_GestionErreurs.Models;

namespace Ex06_GestionErreurs.Services
{
    internal class TelechargementService
    {
        private readonly HttpClient _client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(5)
        };

        public async Task<string?> TelechargerAvecRetryAsync(
            string url,
            int maxTentatives,
            List<ResultatTentative> historique)
        {
            for (int tentative = 1; tentative <= maxTentatives; tentative++)
            {
                var stopwatch = Stopwatch.StartNew();

                try
                {
                    string contenu = await _client.GetStringAsync(url);
                    stopwatch.Stop();

                    historique.Add(new ResultatTentative
                    {
                        Tentative = tentative,
                        Succes = true,
                        Message = "Téléchargement réussi",
                        Duree = stopwatch.Elapsed
                    });

                    return contenu; // succès → on sort
                }
                catch (HttpRequestException ex)
                {
                    stopwatch.Stop();
                    historique.Add(new ResultatTentative
                    {
                        Tentative = tentative,
                        Succes = false,
                        Message = $"Erreur réseau : {ex.Message}",
                        Duree = stopwatch.Elapsed
                    });
                }
                catch (TaskCanceledException ex)
                {
                    stopwatch.Stop();
                    historique.Add(new ResultatTentative
                    {
                        Tentative = tentative,
                        Succes = false,
                        Message = $"Timeout : {ex.Message}",
                        Duree = stopwatch.Elapsed
                    });
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();
                    historique.Add(new ResultatTentative
                    {
                        Tentative = tentative,
                        Succes = false,
                        Message = $"Erreur inconnue : {ex.Message}",
                        Duree = stopwatch.Elapsed
                    });
                }

                // ⭐ BONUS : délai exponentiel (2s, 4s, 8s, ...)
                if (tentative < maxTentatives)
                {
                    int delaiSecondes = (int)Math.Pow(2, tentative);
                    await Task.Delay(TimeSpan.FromSeconds(delaiSecondes));
                }
            }

            return null; // échec après toutes les tentatives
        }
    }
}
