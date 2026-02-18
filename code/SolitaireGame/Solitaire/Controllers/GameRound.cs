using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Controllers
{
    /// <summary>
    /// Classe qui représente une partie de jeu
    /// </summary>
    internal class GameRound
    {
        /// <summary>
        /// Le deck de carte
        /// </summary>
        private Deck deck;

        private Frm_Game view;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public GameRound(Frm_Game view)
        {
            deck = new Deck();
            this.view = view;
        }

        public void Start()
        {
            const int NB_COLS = 7;
            const int SCALE = Deck.Scale;
            Point tmpPosition = new Point(0, 0);
            Point SPACING = new Point(view.Dimensions.Width / (NB_COLS + 1), 5);
            Size lastSize = new Size();

            // Afficher toutes les cartes
            tmpPosition.X = SPACING.X / 3;
            for (int col = 0; col <= NB_COLS; col++)
            {
                tmpPosition.Y = 10;

                for (int i = 0; i < col; i++)
                {
                    // Init
                    Card card = deck.Pick[col + i];
                    Bitmap ressource = card.Ressource;
                    lastSize = new Size(ressource.Width * SCALE, ressource.Height * SCALE);

                    // Image
                    PictureBox pictureBox = new PictureBox()
                    {
                        Size = lastSize,
                        Location = tmpPosition,
                        Image = ressource,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent
                    };
                    view.Controls.Add(pictureBox);

                    tmpPosition.Y += SPACING.Y;
                }
                tmpPosition.X += lastSize.Width + SPACING.X;
            }
            tmpPosition.X -= SPACING.X;
        }
    }
}
