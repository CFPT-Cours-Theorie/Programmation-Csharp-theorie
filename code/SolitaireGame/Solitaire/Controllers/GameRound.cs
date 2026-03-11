using Solitaire.Enums;
using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Solitaire.Controllers
{
    /// <summary>
    /// Classe qui représente une partie de jeu
    /// </summary>
    internal class GameRound
    {
        private List<Card> deck;
        private ImmutableList<CardCategorie> categories;
        private Frm_Game view;
        private List<MyImage> pickFoundations;
        private bool pickCanClick;
        private List<MyImage> selectedCards;
        private Point start_cards;
        private Size spacing_cards;
        private List<List<Card>> boardColumns;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public GameRound(Frm_Game vue)
        {
            view = vue;
            deck = new List<Card>();
            selectedCards = new List<MyImage>();
            boardColumns = new List<List<Card>>();

            // Pick & Foundations
            pickFoundations = new List<MyImage>()
            {
                new MyImage("Deck"),
                new MyImage("Background_Green_Slot")
            };
            for (int i = 0; i < 4; i++)
                pickFoundations.Add(new MyImage("Background_Green_Slot"));

            // autre
            categories = ImmutableList.Create(
               CardCategorie.Clubs,
               CardCategorie.Diamonds,
               CardCategorie.Hearts,
               CardCategorie.Spades
           );
        }

        /// <summary>
        /// Genère et retourne la liste des cartes
        /// </summary>
        /// <returns>Liste de <see cref="Card"/> générée</returns>
        public List<Card> GenerateDeck()
        {
            deck.Clear();

            // Générer les cartes du pick
            for (int i = 0; i < categories.Count; i++)
                for (int value = Card.MinValue; value <= Card.MaxValue; value++)
                    deck.Add(new Card(value, categories[i], CardLayout.Pick_Hided));

            // Mélanger
            deck = Tools.ListShuffle(deck);
            return deck;
        }

        /// <summary>
        /// Initialise le début de la partie
        /// </summary>
        public void Start()
        {
            // Init
            GenerateDeck();
            pickCanClick = true;
            Draw();

            // Update state
            UpdateMovableCardState();
        }

        /// <summary>
        /// Dessine le commencement du jeu
        /// </summary>
        private void Draw()
        {
            // Init
            const int NB_COLS = 7;
            start_cards = new Point(55, 40);
            spacing_cards = new Size(30, 30);
            Size unit = new Size(
                pickFoundations[0].Size.Width + spacing_cards.Width,
                pickFoundations[0].Size.Height + spacing_cards.Height
            );
            List<Card> pickHided = deck.Where(c => c.Layout == CardLayout.Pick_Hided).ToList();

            // Afficher la pioche/fausse
            for (int i = 0; i < pickFoundations.Count; i++)
            {
                MyImage img = pickFoundations[i];
                img.StateMovement.Movable = false;

                int colIndex = (i >= 2) ? i + 1 : i;
                view.Controls.Add(img.CreatePictureBox(new Point(
                    start_cards.X + (colIndex * unit.Width),
                    start_cards.Y
                )));

                img.PictureBox.Click += (s, e) => ToggleAddSelection(img);
            }

            // La pioche
            MyImage pick = pickFoundations[0];
            MyImage trash = pickFoundations[1];
            pick.PictureBox.Click += async (s, e) => Pioche();
            trash.PictureBox.Click += (s, e) =>
            {
                MyImage trash = pickFoundations[1];
                // if (trash.ResourceName == "Background_Green_Slot") return;
                ToggleAddSelection(trash);
            };

            // Afficher les colonnes des cartes
            start_cards.X -= unit.Width;
            start_cards.Y += unit.Height - spacing_cards.Height;
            for (int col = NB_COLS; col > 0; col--)
            {
                List<Card> column = new List<Card>();
                for (int row = col; row > 0; row--)
                {
                    if (pickHided.Count == 0) break;
                    Card card = pickHided.Last();
                    bool isLastCardOfColumn = !(col != row);

                    PictureBox picbx = card.CreatePictureBox(new Point(
                        start_cards.X + (col * unit.Width),
                        start_cards.Y + (row * spacing_cards.Height)
                    ));

                    if (row < col)
                        card.Flip();
                    else
                        card.PictureBox.Click += (s, e) => CardOnClick(card);

                    view.Controls.Add(picbx);
                    card.Layout = CardLayout.Board;
                    pickHided.Remove(card);
                    column.Add(card);
                }
                boardColumns.Add(column);
            }
            boardColumns.Reverse();
        }

        /// <summary>
        /// Gère le clique de la carte
        /// </summary>
        /// <param name="cardClicked">La carte cliqué</param>
        /// <exception cref="Exception">Erreur indiquant que la carte n'a pas été trouvé</exception>
        private void CardOnClick(Card cardClicked)
        {
            if (!cardClicked.StateMovement.Selectable) return;
            ToggleAddSelection(cardClicked);
        }

        /// <summary>
        /// Met à jour l'état de chaque carte pour savoir si elle est déplaçable ou pas
        /// </summary>
        private void UpdateMovableCardState()
        {
            // Pioche
            List<Card> pick_hide = deck.Where(c => c.Layout == CardLayout.Pick_Hided).ToList();
            foreach (Card c in pick_hide)
            {
                c.StateMovement.Movable = false;
                c.StateMovement.Selectable = false;
            }

            // Plateau
            // foreach (List<Card> column in boardColumns)
            // {
            //     for (int iCard = 0; iCard < column.Count; iCard++)
            //     {
            //         Card card = column[iCard];
            //         Card? next = (iCard > 0)
            //             ? column[iCard - 1]
            //             : null;

            //         Card? previous = (iCard < column.Count - 1)
            //             ? column[iCard + 1]
            //             : null;

            //         bool isLastCard = (iCard == 0);
            //         bool isFirstCard = (iCard == column.Count - 1);

            //         card.StateMovement.Selectable = (
            //             card.PictureBox != null &&
            //             !card.IsTurned &&
            //             ne
            //         );

            //         card.StateMovement.Movable = true;
            //     }
            // }

            // Global selectable
            List<Card> pick = deck.Where(c => c.Layout == CardLayout.Pick_Hided).ToList();
            foreach (Card card in deck)
            {
                bool select = (card.PictureBox != null && !card.IsTurned);
                card.StateMovement.Selectable = select;
                card.StateMovement.Movable = select;
            }

            // Prendre en compte la pioche
            MyImage trash = pickFoundations[1];
            List<Card> showPicked = deck.Where(c => c.Layout == CardLayout.Pick_Showed).ToList();
            trash.StateMovement.Selectable = (showPicked.Count > 0);

            // DEBUG : afficher les cartes sélectionnées
            List<MyImage> canBeSelectedCard = deck.Where(c => c.StateMovement.Selectable).ToList<MyImage>();
            canBeSelectedCard.Add(trash);
            // foreach (var item in canBeSelectedCard)
            //     item.Selected = item.StateMovement.Selectable;
            // MessageBox.Show("updated");
        }

        /// <summary>
        /// Pioche une carte de la pile
        /// </summary>
        private async void Pioche()
        {
            if (!pickCanClick) return;

            // Init
            pickCanClick = false;
            MyImage pick = pickFoundations[0];
            MyImage trash = pickFoundations[1];
            List<Card> cardsHided = deck.Where(c => c.Layout == CardLayout.Pick_Hided).ToList();
            List<Card> cardsShowed = deck.Where(c => c.Layout == CardLayout.Pick_Showed).ToList();

            // Traitement
            if (cardsHided.Count > 0)
            {
                // On tire une carte
                Card newCard = cardsHided.Last();
                newCard.Layout = CardLayout.Pick_Showed;
                newCard.CreatePictureBox(new Point(int.MinValue, int.MinValue));
                trash.ReplacePictureBoxImage(newCard.ResourceName);

                if (cardsHided.Count == 1)
                    pick.ReplacePictureBoxImage("Card_Back");
            }
            else
            {
                // Remélanger
                pick.ReplacePictureBoxImage("Background_Green_Slot");
                List<Card> cardsToPick = deck.Where(c => c.Layout == CardLayout.Pick_Showed).ToList();
                cardsToPick.Reverse();

                if (cardsToPick.Count > 1)
                {
                    // Redéfinir l'état des cartes de la pile
                    await Task.Delay((int)(0.75 * 1000.0));
                    foreach (Card card in cardsToPick)
                        card.Layout = CardLayout.Pick_Hided;

                    pick.ReplacePictureBoxImage("Deck");
                }
                else
                    pickCanClick = true; // technique pour bloquer

                // Sortie
                trash.ReplacePictureBoxImage("Background_Green_Slot");
            }

            // Sortie
            UpdateMovableCardState();
            pickCanClick = !pickCanClick; // ça bloquera ici
        }

        /// <summary>
        /// Gère la séléction des cartes
        /// </summary>
        /// <param name="card">Carte séléctionnée</param>
        private void ToggleAddSelection(MyImage card)
        {
            int limitSelectedCard = 2;
            var clearSelect = () =>
            {
                foreach (MyImage c in selectedCards)
                    c.Selected = false;
                selectedCards.Clear();
            };

            // Désélection
            if (selectedCards.Count >= limitSelectedCard)
                clearSelect();

            // Ajouter la carte
            if (
                selectedCards.Contains(card) &&
                (
                    card.ResourceName == "Background_Green_Slot" ||
                    card.ResourceName == "Deck"
                )
            ) return;

            selectedCards.Add(card);
            card.Selected = true;

            // Si deux cartes sont séléctionnés
            if (selectedCards.Count == limitSelectedCard)
            {
                MyImage card1 = selectedCards[0];
                MyImage card2 = selectedCards[1];

                if (card1 is Card && card2 is Card)
                {
                    Card selectedCard1 = (Card)card1;
                    Card selectedCard2 = (Card)card2;

                    bool isValidMove =
                        selectedCard1.Value == selectedCard2.Value - 1 &&
                        selectedCard1.CardColor != selectedCard2.CardColor;

                    if (selectedCard1.Value < selectedCard2.Value)
                    {
                        // Bouger la carte
                        selectedCard2.AppendChild(selectedCard1, spacing_cards.Height);
                        MoveCardBetweenColumns(selectedCard1, selectedCard2);

                        // Retourner la carte derrière
                        int card1Index = deck.FindIndex(c => c == card1);
                        Card previousCard = deck[card1Index - 1];
                        previousCard.Flip();
                    }
                }

                // On clear la séléction
                clearSelect();
                UpdateMovableCardState();
            }
        }

        private void MoveCardBetweenColumns(Card moving, Card target)
        {
            List<Card>? fromColumn = boardColumns
                .FirstOrDefault(col => col.Contains(moving));

            List<Card>? toColumn = boardColumns
                .FirstOrDefault(col => col.Contains(target));

            if (fromColumn == null || toColumn == null)
                return;

            fromColumn.Remove(moving);
            toColumn.Add(moving);
        }
    }
}
