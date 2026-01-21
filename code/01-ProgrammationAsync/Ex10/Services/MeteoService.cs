using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Services
{
    internal class MeteoService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly CacheService _cache;

        public MeteoService(HttpClient client, string apiKey, CacheService cache)
        {
            _client = client;
            _apiKey = apiKey;
            _cache = cache;
        }

        public async Task<ResultatMeteo> ObtenirMeteoAsync(string ville, CancellationToken token)
        {
            try
            {
                if (_cache.TryGetMeteo(ville, out var meteoCache))
                {
                    return new ResultatMeteo { Meteo = meteoCache, Succes = true };
                }

                var (lat, lon) = await ObtenirCoordonneesAsync(ville, token);

                var url =
                    $"https://api.openweathermap.org/data/2.5/weather" +
                    $"?lat={lat}&lon={lon}&units=metric&lang=fr&appid={_apiKey}";

                using var response = await _client.GetAsync(url, token);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync(token);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var meteo = new Meteo
                {
                    Ville = ville,
                    Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
                    Humidite = root.GetProperty("main").GetProperty("humidity").GetInt32(),
                    Description = root.GetProperty("weather")[0].GetProperty("description").GetString(),
                    DateHeure = DateTime.Now
                };

                _cache.AjouterCache(ville, meteo);

                return new ResultatMeteo { Meteo = meteo, Succes = true };
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new ResultatMeteo
                {
                    Succes = false,
                    MessageErreur = ex.Message
                };
            }
        }

        public async Task<List<ResultatMeteo>> ObtenirPlusieursVillesAsync(
            List<string> villes,
            IProgress<int> progress,
            CancellationToken token)
        {
            var resultats = new List<ResultatMeteo>();
            int total = villes.Count;
            int termines = 0;

            var tasks = villes.Select(async ville =>
            {
                var resultat = await ObtenirMeteoAsync(ville, token);
                Interlocked.Increment(ref termines);
                progress?.Report((termines * 100) / total);
                return resultat;
            });

            resultats.AddRange(await Task.WhenAll(tasks));
            return resultats;
        }

        private async Task<(double lat, double lon)> ObtenirCoordonneesAsync(string ville, CancellationToken token)
        {
            var url = $"https://api.openweathermap.org/geo/1.0/direct?q={ville}&limit=1&appid={_apiKey}";

            var json = await _client.GetStringAsync(url, token);

            var resultats = JsonSerializer.Deserialize<List<GeoResult>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (resultats == null || resultats.Count == 0)
                throw new Exception($"Ville inconnue : {ville}");

            return (resultats[0].Lat, resultats[0].Lon);
        }
    }
}
