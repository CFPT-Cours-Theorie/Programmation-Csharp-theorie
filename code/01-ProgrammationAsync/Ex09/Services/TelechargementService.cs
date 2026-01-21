using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ex09_GestionnaireTelechargements.Models;

namespace Ex09_GestionnaireTelechargements.Services
{
    internal class TelechargementService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly List<Telechargement> _historique = new();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(3); // ⭐ BONUS

        public async Task<bool> TelechargerFichierAsync(
            string url,
            string nomFichier,
            IProgress<int> progress,
            CancellationToken token)
        {
            await _semaphore.WaitAsync(token);

            var telechargement = new Telechargement
            {
                Url = url,
                NomFichier = nomFichier,
                DateHeure = DateTime.Now,
                Statut = "En cours"
            };

            try
            {
                using var response = await _client.GetAsync(
                    url,
                    HttpCompletionOption.ResponseHeadersRead,
                    token);

                response.EnsureSuccessStatusCode();

                var total = response.Content.Headers.ContentLength ?? -1L;
                var buffer = new byte[8192];
                long lu = 0;

                using var stream = await response.Content.ReadAsStreamAsync(token);
                using var file = File.Create(nomFichier);

                int read;
                while ((read = await stream.ReadAsync(buffer, token)) > 0)
                {
                    await file.WriteAsync(buffer.AsMemory(0, read), token);
                    lu += read;

                    if (total > 0)
                    {
                        int pourcentage = (int)((lu * 100) / total);
                        progress.Report(pourcentage);
                    }
                }

                telechargement.Taille = lu;
                telechargement.Statut = "Succès";
                _historique.Add(telechargement);
                return true;
            }
            catch (OperationCanceledException)
            {
                telechargement.Statut = "Annulé";
                _historique.Add(telechargement);
                throw;
            }
            catch (Exception ex)
            {
                telechargement.Statut = $"Erreur : {ex.Message}";
                _historique.Add(telechargement);
                return false;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task TelechargerPlusieursAsync(
            List<string> urls,
            IProgress<int> progress,
            CancellationToken token)
        {
            int total = urls.Count;
            int termines = 0;

            var tasks = urls.Select((url, index) =>
                TelechargerFichierAsync(
                    url,
                    $"file_{index + 1}.txt",
                    new Progress<int>(_ =>
                    {
                        progress.Report((termines * 100) / total);
                    }),
                    token)
                .ContinueWith(_ => Interlocked.Increment(ref termines))
            );

            await Task.WhenAll(tasks);
            progress.Report(100);
        }

        public async Task SauvegarderHistoriqueAsync(string chemin)
        {
            var json = JsonSerializer.Serialize(_historique, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(chemin, json);
        }

        public async Task<List<Telechargement>> ChargerHistoriqueAsync(string chemin)
        {
            if (!File.Exists(chemin))
                return new List<Telechargement>();

            var json = await File.ReadAllTextAsync(chemin);
            return JsonSerializer.Deserialize<List<Telechargement>>(json)
                   ?? new List<Telechargement>();
        }
    }
}
