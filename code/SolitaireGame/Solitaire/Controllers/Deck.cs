using Solitaire.Enums;
using Solitaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
        /// Paquet de carte du jeu
        /// </summary>
        public List<Card> Cards { get; private set; }

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
            for (int i = 0; i < categories.Count; i++)
                for (int j = Card.MinValue; j <= Card.MaxValue; j++)
                    Cards.Add(new Card(j, categories[i]));
            return Cards;
        }
    }
}
