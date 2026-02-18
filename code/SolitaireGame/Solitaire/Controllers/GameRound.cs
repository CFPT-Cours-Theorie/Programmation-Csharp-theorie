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

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public GameRound()
        {
            deck = new Deck();
        }

        public void Start()
        {

        }
    }
}
