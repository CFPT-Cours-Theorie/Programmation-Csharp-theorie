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
        /// Couleur de la carte
        /// </summary>
        public CarteColor CardColor { get; private set; }

        /// <summary>
        /// Dit si la carte peut-être bougé
        /// </summary>
        public bool IsMovable { get; set; }

        /// <summary>
        /// Categorie de la carte
        /// </summary>
        public CarteCategorie Categorie { get; private set; }

        /// <summary>
        /// Ressource image de la carte
        /// </summary>
        public Bitmap Ressource
        {
            get
            {
                string resourceName = $"{Categorie}_{Value}";
                var obj = Properties.Resources.ResourceManager.GetObject(resourceName);

                if (obj is Bitmap bitmap)
                    return bitmap;
                throw new Exception($"Ressource {resourceName} introuvable");
            }
        }

        /// <summary>
        /// Echelle d'affichage des cartes
        /// </summary>
        public const int Scale = 2;
        public Size Size
        {
            get
            {
                Bitmap ressource = Ressource;
                return new Size(ressource.Width * Scale, ressource.Height * Scale);
            }
        }
        public Point Position { get => picBx.Location; }
        public PictureBox picBx { get; private set; }

        /// <summary>
        /// Constructeur de la classe....
        /// </summary>
        /// <param name="value">Valeur de la carte</param>
        /// <param name="categorie">CarteCategorie de la carte</param>
        public Card(int value, CarteCategorie categorie)
        {
            Value = value;
            Categorie = categorie;
            CardColor = (Categorie == CarteCategorie.Clubs || Categorie == CarteCategorie.Spades)
                ? CarteColor.Black
                : CarteColor.Red;
            IsMovable = false;
        }

        public PictureBox CreatePictureBox(Point position)
        {
            picBx = new PictureBox()
            {
                Size = Size,
                Location = position,
                Image = Ressource,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            return picBx;
        }
    }
}
