using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01.Models;

namespace Ex01.Services
{
    /// <summary>
    /// Service responsable du téléchargement des images depuis Internet.
    /// </summary>
    internal class ImageService
    {
        /// <summary>
        /// Instance partagée de HttpClient utilisée pour effectuer les requêtes HTTP.
        /// L'utilisation d'une instance statique évite les problèmes de surcharge réseau.
        /// </summary>
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Télécharge une image de manière asynchrone depuis une URL donnée
        /// et l'enregistre sur le disque local.
        /// </summary>
        /// <param name="url">URL de l'image à télécharger</param>
        /// <param name="nomFichier">Nom du fichier de destination</param>
        /// <returns>
        /// Un objet <see cref="ImageTelechargement"/> contenant les informations
        /// et le résultat du téléchargement.
        /// </returns>
        public async Task<ImageTelechargement> TelechargerImageAsync(string url, string nomFichier)
        {
            // Création de l'objet modèle représentant l'image à télécharger
            var image = new ImageTelechargement
            {
                Url = url,
                NomFichier = nomFichier
            };

            try
            {
                // Téléchargement asynchrone des données de l'image
                byte[] data = await _httpClient.GetByteArrayAsync(url);

                // Écriture asynchrone des données dans un fichier local
                await File.WriteAllBytesAsync(nomFichier, data);

                // Mise à jour des informations de succès
                image.TailleOctets = data.Length;
                image.Statut = "Succès";
            }
            catch (Exception ex)
            {
                // Gestion des erreurs (connexion, URL invalide, écriture disque, etc.)
                image.Statut = $"Erreur : {ex.Message}";
                image.TailleOctets = 0;
            }

            // Retourne le résultat du téléchargement
            return image;
        }
    }
}

