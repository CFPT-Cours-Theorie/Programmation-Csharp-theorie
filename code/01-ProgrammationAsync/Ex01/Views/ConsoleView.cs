using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01.Models;

namespace Ex01.Views
{
    /// <summary>
    /// Vue console responsable de l'affichage des résultats
    /// du téléchargement des images.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Affiche dans la console les informations liées
        /// au résultat du téléchargement d'une image.
        /// </summary>
        /// <param name="image">
        /// Objet <see cref="ImageTelechargement"/> contenant
        /// les données à afficher.
        /// </param>
        public void AfficherResultat(ImageTelechargement image)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"URL        : {image.Url}");
            Console.WriteLine($"Fichier    : {image.NomFichier}");
            Console.WriteLine($"Statut     : {image.Statut}");
            Console.WriteLine($"Taille     : {image.TailleOctets} octets");
        }
    }
}
