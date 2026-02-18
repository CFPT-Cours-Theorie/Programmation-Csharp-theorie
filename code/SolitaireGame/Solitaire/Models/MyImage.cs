using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Models
{
    /// <summary>
    /// Classe qui représente une image
    /// </summary>
    internal class MyImage
    {
        /// <summary>
        /// Nom de la resource associée à l'image
        /// </summary>
        public string ResourceName { get; protected set; }

        /// <summary>
        /// Echelle d'affichage des cartes
        /// </summary>
        public const int Scale = 2;

        /// <summary>
        /// Taille de la carte
        /// </summary>
        public Size Size
        {
            get
            {
                Bitmap ressource = Ressource;
                return new Size(ressource.Width * Scale, ressource.Height * Scale);
            }
        }

        /// <summary>
        /// Dit si la carte peut-être bougé
        /// </summary>
        public bool IsMovable { get; set; }

        /// <summary>
        /// Position de l'élement
        /// </summary>
        public Point Position { get => PictureBox.Location; }

        /// <summary>
        /// Picture Box de l'élement
        /// </summary>
        public PictureBox PictureBox { get; protected set; }

        /// <summary>
        /// Ressource image de la carte
        /// </summary>
        public Bitmap Ressource
        {
            get
            {
                var obj = Properties.Resources.ResourceManager.GetObject(ResourceName);

                if (obj is Bitmap bitmap)
                    return bitmap;
                throw new Exception($"Ressource {ResourceName} introuvable");
            }
        }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="name">Nom de l'image</param>
        public MyImage(string name)
        {
            ResourceName = name;
        }

        /// <summary>
        /// Créer la picture box
        /// </summary>
        /// <param name="position"></param>
        /// <returns>La picture box</returns>
        public PictureBox CreatePictureBox(Point position)
        {
            PictureBox = new PictureBox()
            {
                Size = Size,
                Location = position,
                Image = Ressource,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            return PictureBox;
        }
    }
}
