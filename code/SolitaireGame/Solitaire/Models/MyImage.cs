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
                Bitmap ressource = Resource;
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
        public PictureBox PictureBox { get; set; } // protected set; }

        /// <summary>
        /// Resource image de la carte
        /// </summary>
        public Bitmap Resource
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
        /// <param resourceName="resourceName">Nom de l'image</param>
        public MyImage(string resourceName)
        {
            ResourceName = resourceName;
        }

        /// <summary>
        /// Créer la picture box
        /// </summary>
        /// <param resourceName="position"></param>
        /// <returns>La picture box</returns>
        public PictureBox CreatePictureBox(Point position)
        {
            if (PictureBox != null)
                return PictureBox;

            PictureBox = new PictureBox()
            {
                Size = Size,
                Location = position,
                Image = Resource,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            return PictureBox;
        }

        /// <summary>
        /// Remplace l'image de la picture box
        /// </summary>
        /// <param name="image">La nouvelle image de la picture box qui va remplacer</param>
        public void ReplacePictureBoxImage(Bitmap image)
        {
            PictureBox.Image = image;
        }

        public override string ToString()
        {
            return ResourceName;
        }
    }
}
