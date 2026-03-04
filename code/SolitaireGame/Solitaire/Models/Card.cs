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
        private int _index;

        /// <summary>
        /// Représente le nom de la resource d'une carte tournée (face cachée)
        /// </summary>
        private const string TURNED_CARD = "Card_Back";

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
        public CardColor CardColor { get; private set; }

        /// <summary>
        /// Categorie de la carte
        /// </summary>
        public CardCategorie Categorie { get; private set; }

        /// <summary>
        /// Indique si la carte est tournée (face cachée)
        /// </summary>
        public bool IsTurned => ResourceName == TURNED_CARD;

        /// <summary>
        /// Le layout de la carte
        /// </summary>
        public CardLayout Layout { get; set; }

        /// <summary>
        /// index de la colonne dans laquelle se trouve la carte
        /// (0-6 pour les colonnes du tableau, 7 pour la pioche, 8-11 pour les fondations)
        /// </summary>
        public int IndexColumn {
            get => _index;
            set
            {
                switch (Layout)
                {
                    case CardLayout.Board:
                        _value = Math.Clamp(value, 0, 6);
                        break;

                    case CardLayout.Pick_Hided:
                        _value = 7;
                        break;

                    case CardLayout.Pick_Showed:
                        _value = 8;
                        break;

                    case CardLayout.Foundations:
                        _value = Math.Clamp(value, 9, 12);
                        break;

                    default:
                        throw new Exception($"Le layout n'est pas défini");
                }
            }
        }

        /// <summary>
        /// Constructeur de la classe....
        /// </summary>
        /// <param name="value">Valeur de la carte</param>
        /// <param name="categorie">CardCategorie de la carte</param>
        public Card(int value, CardCategorie categorie, CardLayout layout) : base("")
        {
            Value = value;
            Categorie = categorie;
            Layout = layout;
            CardColor = (Categorie == CardCategorie.Clubs || Categorie == CardCategorie.Spades)
                ? CardColor.Black
                : CardColor.Red;
            IsMovable = false;
            Flip();
            Flip();
        }

        /// <summary>
        /// Retourne la carte (face cachée -> face visible) (face visible -> face cachée)
        /// </summary>
        public void Flip()
        {
            // Change resource name
            ResourceName = ResourceName switch
            {
                TURNED_CARD => $"{Categorie}_{Value}",
                _ => TURNED_CARD
            };

            // Update UI - re-render
            if (PictureBox != null)
                PictureBox.Image = Resource;
        }

        /// <summary>
        /// Fonction appelée lors du click sur la carte
        /// </summary>
        public void OnClick()
        {
            Flip();
        }
    }
}
