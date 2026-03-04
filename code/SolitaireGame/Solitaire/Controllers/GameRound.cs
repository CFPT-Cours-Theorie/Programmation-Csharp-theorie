using Solitaire.Enums;
using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Controllers
{
    /// <summary>
    /// Classe qui représente une partie de jeu
    /// </summary>
    internal class GameRound
    {
        private List<Card> board;
        private List<Card> pick;
        private List<Card> trash;
        private List<Card> Deck { get => board.Concat(pick).Concat(trash).ToList(); }
        private ImmutableList<CarteCategorie> categories;
        private Frm_Game view;
        private ImageClick pioche;
        private List<MyImage> foundations;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public GameRound(Frm_Game vue)
        {
            view = vue;

            // Clear
            board = new List<Card>();
            pick = new List<Card>();
            trash = new List<Card>();

            foundations = new List<MyImage>();
            for (int i = 0; i < 4; i++)
                foundations.Add(new MyImage("Background_Green_Slot"));

            // autre
            pioche = new ImageClick("Deck", new Action(() =>
            {
                throw new NotImplementedException();
            }));
            categories = ImmutableList.Create(
               CarteCategorie.Clubs,
               CarteCategorie.Diamonds,
               CarteCategorie.Hearts,
               CarteCategorie.Spades
           );
        }

        /// <summary>
        /// Genère et retourne la liste des cartes
        /// </summary>
        /// <returns>Liste de <see cref="Card"/> générée</returns>
        public List<Card> GenerateDeck()
        {
            board.Clear();
            pick.Clear();
            trash.Clear();

            // Générer les cartes du deck
            for (int i = 0; i < categories.Count; i++)
                for (int value = Card.MinValue; value <= Card.MaxValue; value++)
                    pick.Add(new Card(value, categories[i]));

            // Mélanger
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(pick));
            return pick;
        }

        public void Start()
        {
            // Init
            GenerateDeck();
            Draw();

            // Update
            UpdateMovableCardState();
        }

        private void Draw()
        {
            // Init
            const int NB_COLS = 7;
            Point start = new Point(10, 50);
            Point spacing = new Point(100, 30);

            // Afficher les colonnes des cartes
            for (int col = NB_COLS; col > 0; col--)
            {
                for (int row = col; row > 0; row--)
                {
                    Card card = pick[col + row];

                    if (col != row)
                        card.Flip();

                    view.Controls.Add(card.CreatePictureBox(new Point(
                        start.X + col * spacing.X,
                        start.Y + row * spacing.Y
                    )));

                    board.Add(card);
                    pick.Remove(card);
                }
            }

            // Afficher la pioche
            view.Controls.Add(
                pioche.CreatePictureBox(
                    new Point(
                        Tools.GetNbrFrmPrct(80, view.Width),
                        Tools.GetNbrFrmPrct(15, view.Height)
                    )
                )
            );

            // Afficher la fausse
            for (int i = 0; i < foundations.Count; i++)
            {
                view.Controls.Add(
                    foundations[i].CreatePictureBox(
                        new Point(
                            Tools.GetNbrFrmPrct(80, view.Width),
                            i * spacing.Y + i * foundations[i].Size.Height + Tools.GetNbrFrmPrct(30, view.Height)
                        )
                    )
                );
            }
        }

        private void UpdateMovableCardState()
        {
            foreach (var c in Deck)
                c.IsMovable = false;

            var cardsByColumn = board
                .GroupBy(c => c.Position.X)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var column in cardsByColumn.Values)
            {
                if (column.Count == 0)
                    continue;

                Card lowerCard = column.OrderBy(c => c.Position.Y).First();
                lowerCard.IsMovable = true;
            }
        }
    }
}
