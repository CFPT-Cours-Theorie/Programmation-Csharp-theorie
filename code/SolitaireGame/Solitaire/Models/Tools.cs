using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Models
{
    static class Tools
    {
        /// <summary>
        /// Fonction qui retourne un nombre aléatoire entre deux nombres compris
        /// </summary>
        /// <param name="min">Minimum de l'interval compris</param>
        /// <param name="max">Maximum de l'interval compris</param>
        /// <returns>Un nombre entier aléatoire</returns>
        public static int GetRandomInt(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }

        /// <summary>
        /// Retourne la couleur entre vert et rouge d'un pourcentage
        /// </summary>
        /// <param name="healthPercentage">Le pourcentage</param>
        /// <returns>La couleur représentant le pourcentage</returns>
        public static Color GetHealthColor(float healthPercentage)
        {
            return Color.FromArgb(
                255,                                 // Opacité max
                (int)(255 * (1 - healthPercentage)), // Plus la vie baisse, plus le rouge augmente
                (int)(255 * healthPercentage),       // Plus la vie baisse, plus le vert diminue
                0                                    // Pas de bleu
            );
        }

        /// <summary>
        /// Récupère le chemin jusqu'au dossier de ressources
        /// </summary>
        /// <returns>Le chemin de ressources</returns>
        public static string GetRessourcePath()
        {
            return $"{Tools.RepeatString("../", 2)}Resources/";
        }

        /// <summary>
        /// Répète un certain nombre de fois un string
        /// </summary>
        /// <param name="text">Le texte à répéter</param>
        /// <param name="n">Le nombre de fois qu'on doit le répéter</param>
        /// <returns>Le string répété</returns>
        public static string RepeatString(string text, int n)
        {
            return string.Concat(Enumerable.Repeat(text, (int)n));
        }
    }
}
