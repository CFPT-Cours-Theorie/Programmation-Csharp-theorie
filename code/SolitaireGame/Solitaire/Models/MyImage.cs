using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

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
        /// L'état de déplacement
        /// </summary>
        public MovementState StateMovement { get; set; }

        /// <summary>
        /// Position de l'élement
        /// </summary>
        public Point Position { get => PictureBox.Location; }

        /// <summary>
        /// Picture Box de l'élement
        /// </summary>
        public PictureBox PictureBox { get; protected set; }

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

        private bool _selected;
        /// <summary>
        /// Indique si la carte est sélectionné
        /// </summary>
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                PictureBox?.Invalidate();
            }
        }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="resourceName">Nom de l'image</param>
        public MyImage(string resourceName)
        {
            ResourceName = resourceName;
            StateMovement = new MovementState();
            Selected = false;
        }

        /// <summary>
        /// Créer la picture box
        /// </summary>
        /// <param name="position">La position de la pic box</param>
        /// <returns>La picture box</returns>
        public virtual PictureBox CreatePictureBox(Point position)
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
            PictureBox.Paint += OnPaint;
            return PictureBox;
        }

        /// <summary>
        /// Gère la méthode d'affichage du picture box de la carte
        /// en fonction de si la carte est séléctionnée
        /// </summary>
        /// <param name="sender">L'initiateur</param>
        /// <param name="e">L'evenement</param>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (!Selected) return;
            int borderWidth = 4;
            Color borderColor = Color.Red;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    borderWidth / 2,
                    borderWidth / 2,
                    PictureBox.Width - borderWidth,
                    PictureBox.Height - borderWidth
                );
            }
        }

        /// <summary>
        /// Remplace l'image de la picture box
        /// </summary>
        /// <param name="newResourceName">Le nom de la nouvelle image de la picture box va remplacer</param>
        public void ReplacePictureBoxImage(string newResourceName)
        {
            ResourceName = newResourceName;
            PictureBox.Image = Resource;
        }

        public override string ToString()
        {
            return ResourceName;
        }
    }
}
