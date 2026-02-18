using Solitaire.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Models
{
    /// <summary>
    /// Classe représentant les cartes de jeu
    /// </summary>
    internal class Card
    {
        private int _value;

        /// <summary>
        /// Valeur de la carte
        /// </summary>
        public int Value { get => _value; private set => _value = Math.Clamp(value, MinValue, MaxValue); }

        /// <summary>
        /// Valeur minimale possible
        /// </summary>
        public const int MinValue = 1;

        /// <summary>
        /// Valeur maximale possible
        /// </summary>
        public const int MaxValue = 13;

        /// <summary>
        /// CarteCategorie de la carte
        /// </summary>
        public CarteCategorie Categorie { get; private set; }

        /// <summary>
        /// Constructeur de la classe....
        /// </summary>
        /// <param name="value">Valeur de la carte</param>
        /// <param name="categorie">CarteCategorie de la carte</param>
        public Card(int value, CarteCategorie categorie)
        {
            Value = value;
            Categorie = categorie;
        }

        /// <summary>
        /// Retourne le chemin de l'image de la carte
        /// </summary>
        /// <returns>Le nom du fichier image</returns>
        public string GetFilePath()
        {
            return $"{Tools.GetRessourcePath()}{Categorie.ToString()}_{Value}.png"; ;
        }
    }
}
