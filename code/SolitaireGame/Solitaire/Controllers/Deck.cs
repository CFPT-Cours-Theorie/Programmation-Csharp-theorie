using Solitaire.Enums;
using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Controllers
{
    /// <summary>
    /// Classe qui représente le deck de carte dans mon jeu
    /// </summary>
    internal class Deck
    {
        /// <summary>
        /// Pioche de carte du jeu
        /// </summary>
        public List<Card> Pick { get; private set; }

        /// <summary>
        /// Corbeille de carte du jeu
        /// </summary>
        public List<Card> Trash { get; private set; }

        /// <summary>
        /// Echelle d'affichage des cartes
        /// </summary>
        public const int Scale = 2;

        /// <summary>
        /// Liste des catégories de cartes
        /// </summary>
        private ImmutableList<CarteCategorie> categories;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public Deck()
        {
            // Init
            Pick = new List<Card>();
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
            // Générer les cartes du deck
            Pick.Clear();
            for (int i = 0; i < categories.Count; i++)
                for (int value = Card.MinValue; value <= Card.MaxValue; value++)
                    Pick.Add(new Card(value, categories[i]));

            // Mélanger
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(Pick));

            return Pick;
        }
    }
}
