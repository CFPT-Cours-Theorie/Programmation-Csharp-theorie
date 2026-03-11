using Solitaire.Enums;
using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
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
        private List<Card> deck;
        private ImmutableList<CardCategorie> categories;
        private Frm_Game view;
        private List<MyImage> pickFoundations;
        private bool pickCanClick;
        private List<MyImage> selectedCards;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public GameRound(Frm_Game vue)
        {
            view = vue;
            deck = new List<Card>();
            selectedCards = new List<MyImage>();

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

            // Update
            UpdateMovableCardState();
        }

        /// <summary>
        /// Dessine le commencement du jeu
        /// </summary>
        private void Draw()
        {
            // Init
            const int NB_COLS = 7;
            Point start = new Point(55, 40);
            Size spacing = new Size(30, 30);
            Size unit = new Size(
                pickFoundations[0].Size.Width + spacing.Width,
                pickFoundations[0].Size.Height + spacing.Height
            );
            List<Card> pickHided = deck.Where(c => c.Layout == CardLayout.Pick_Hided).ToList();

            // Afficher la pioche/fausse
            for (int i = 0; i < pickFoundations.Count; i++)
            {
                MyImage img = pickFoundations[i];
                int colIndex = (i >= 2) ? i + 1 : i;
                view.Controls.Add(img.CreatePictureBox(new Point(
                    start.X + (colIndex * unit.Width),
                    start.Y
                )));
            }

            // La pioche
            MyImage pick = pickFoundations[0];
            MyImage trash = pickFoundations[1];
            pick.PictureBox.Click += async (s, e) => Pioche();
            trash.PictureBox.Click += (s, e) =>
            {
                MyImage trash = pickFoundations[1];
                if (trash.ResourceName == "Background_Green_Slot") return;
                ToggleAddSelection(trash);
            };

            // Afficher les colonnes des cartes
            start.X -= unit.Width;
            start.Y += unit.Height - spacing.Height;
            for (int col = NB_COLS; col > 0; col--)
            {
                for (int row = col; row > 0; row--)
                {
                    if (pickHided.Count == 0) break;
                    Card card = pickHided.Last();
                    bool isLastCardOfColumn = !(col != row);

                    PictureBox picbx = card.CreatePictureBox(new Point(
                        start.X + (col * unit.Width),
                        start.Y + (row * spacing.Height)
                    ));

                    if (row < col)
                        card.Flip();
                    else
                        card.PictureBox.Click += (s, e) => CardOnClick(card);

                    view.Controls.Add(picbx);
                    card.Layout = CardLayout.Board;
                    pickHided.Remove(card);
                }
            }
        }

        /// <summary>
        /// Gère le clique de la carte
        /// </summary>
        /// <param name="cardClicked">La carte cliqué</param>
        /// <exception cref="Exception">Erreur indiquant que la carte n'a pas été trouvé</exception>
        private void CardOnClick(Card cardClicked)
        {
            if (!cardClicked.IsMovable) return;
            ToggleAddSelection(cardClicked);
        }

        /// <summary>
        /// Met à jour l'état de chaque carte pour savoir si elle est déplaçable ou pas
        /// </summary>
        private void UpdateMovableCardState()
        {
            List<Card> pick_hide = deck.Where(c => c.Layout == CardLayout.Pick_Hided).ToList();
            foreach (Card c in pick_hide)
                c.IsMovable = false;

            List<Card> board = deck.Where(c => c.Layout == CardLayout.Board).ToList();
            foreach (Card c in board)
                c.IsMovable = !c.IsTurned;
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
                foreach (Card c in selectedCards)
                    c.Selected = false;
                selectedCards.Clear();
            };

            // Désélection
            if (selectedCards.Count >= limitSelectedCard)
                clearSelect();


            // Ajouter la carte
            if (!selectedCards.Contains(card))
            {
                selectedCards.Add(card);
                card.Selected = true;
            }

            // Si deux cartes sont séléctionnés
            if (selectedCards.Count == limitSelectedCard)
            {
                // throw new NotImplementedException();
                // MessageBox.Show("Mettre les règles ici");
            }
        }
    }
}
