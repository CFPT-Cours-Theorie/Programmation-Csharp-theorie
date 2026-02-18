using Solitaire.Enums;
using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public GameRound(Frm_Game vue)
        {
            board = new List<Card>();
            pick = new List<Card>();
            trash = new List<Card>();
            view = vue;

            categories = ImmutableList.Create(
               CarteCategorie.Clubs,
               CarteCategorie.Diamonds,
               CarteCategorie.Hearts,
               CarteCategorie.Spades
           );
            GenerateDeck();
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
            const int NB_COLS = 7;
            Point tmpPosition = new Point(0, 0);
            Point SPACING = new Point(50, 2);
            Size lastSize = new Size();

            // Afficher les colonnes des cartes
            tmpPosition.X = Tools.GetNbrFrmPrct(3, view.Width);
            for (int col = 0; col <= NB_COLS; col++)
            {
                tmpPosition.Y = Tools.GetNbrFrmPrct(5, view.Height);

                for (int i = 0; i < col; i++)
                {
                    Card card = pick[col + i];
                    lastSize = card.Size;
                    view.Controls.Add(card.CreatePictureBox(tmpPosition));
                    tmpPosition.Y += lastSize.Height + SPACING.Y;

                    board.Add(card);
                    pick.Remove(card);
                }
                tmpPosition.X += lastSize.Width + SPACING.X;
            }
            tmpPosition.X -= SPACING.X;

            // Afficher la pioche
            MyImage pioche = new MyImage("Deck");
            view.Controls.Add(pioche.CreatePictureBox(
                new Point(
                    Tools.GetNbrFrmPrct(80, view.Width),
                    Tools.GetNbrFrmPrct(15, view.Height)
                )
            ));

            // Update
            UpdateMovableCardState();
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
