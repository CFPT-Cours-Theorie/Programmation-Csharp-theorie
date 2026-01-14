using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ex02.Models;

namespace Ex02.Services
{
    internal class UtilisateurService
    {
        private readonly HttpClient _client;

        public UtilisateurService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };
        }

        public async Task<Utilisateur> ObtenirUtilisateurAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"users/{id}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Utilisateur>(json, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<Utilisateur>> ObtenirTousUtilisateursAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("users");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Utilisateur>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // ⭐ BONUS
        public async Task<Utilisateur?> RechercherParNomAsync(string nom)
        {
            var utilisateurs = await ObtenirTousUtilisateursAsync();

            return utilisateurs
                .FirstOrDefault(u => u.Name.Contains(nom, StringComparison.OrdinalIgnoreCase));
        }
    }
}
