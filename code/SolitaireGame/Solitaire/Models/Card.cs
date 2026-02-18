using Solitaire.Enums;
using Solitaire.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Models
{
    /// <summary>
    /// Classe représentant les cartes de jeu
    /// </summary>
    internal class Card : MyImage
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
        /// Couleur de la carte
        /// </summary>
        public CarteColor CardColor { get; private set; }

        /// <summary>
        /// Categorie de la carte
        /// </summary>
        public CarteCategorie Categorie { get; private set; }

        /// <summary>
        /// Constructeur de la classe....
        /// </summary>
        /// <param name="value">Valeur de la carte</param>
        /// <param name="categorie">CarteCategorie de la carte</param>
        public Card(int value, CarteCategorie categorie) : base("")
        {
            Value = value;
            Categorie = categorie;
            CardColor = (Categorie == CarteCategorie.Clubs || Categorie == CarteCategorie.Spades)
                ? CarteColor.Black
                : CarteColor.Red;
            IsMovable = false;
            ResourceName = $"{Categorie}_{Value}";
        }
    }
}
