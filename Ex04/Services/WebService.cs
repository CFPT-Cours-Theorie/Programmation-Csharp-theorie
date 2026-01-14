using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Models;

namespace Ex04.Services
{
    internal class WebService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<ResultatTelechargement> TelechargerPageAsync(string url)
        {
            var stopwatch = Stopwatch.StartNew();
            var resultat = new ResultatTelechargement { Url = url };

            try
            {
                string contenu = await _client.GetStringAsync(url);
                stopwatch.Stop();

                resultat.TailleCaracteres = contenu.Length;
                resultat.Duree = stopwatch.Elapsed;
                resultat.Succes = true;
            }
            catch
            {
                stopwatch.Stop();
                resultat.TailleCaracteres = 0;
                resultat.Duree = stopwatch.Elapsed;
                resultat.Succes = false;
            }

            return resultat;
        }

        // 🔁 Séquentiel
        public async Task<List<ResultatTelechargement>> TelechargerSequentiellementAsync(List<string> urls)
        {
            var resultats = new List<ResultatTelechargement>();

            foreach (var url in urls)
            {
                var resultat = await TelechargerPageAsync(url);
                resultats.Add(resultat);
            }

            return resultats;
        }

        // ⚡ Parallèle
        public async Task<List<ResultatTelechargement>> TelechargerEnParalleleAsync(List<string> urls)
        {
            var tasks = urls.Select(url => TelechargerPageAsync(url));
            return (await Task.WhenAll(tasks)).ToList();
        }

        // ⭐ BONUS : affichage au fil de l’eau
        public async Task TelechargerAvecRetourProgressifAsync(
            List<string> urls,
            Action<ResultatTelechargement> onResultat)
        {
            var tasks = urls.Select(url => TelechargerPageAsync(url)).ToList();

            while (tasks.Any())
            {
                Task<ResultatTelechargement> taskFinie = await Task.WhenAny(tasks);
                tasks.Remove(taskFinie);

                onResultat(await taskFinie);
            }
        }
    }
}
