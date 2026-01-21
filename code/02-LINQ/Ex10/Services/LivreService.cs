using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Services
{
    internal class LivreService
    {
        private readonly List<Livre> _livres;

        public LivreService(List<Livre> livres)
        {
            _livres = livres;
        }

        public IEnumerable<Livre> RechercherLivres(string motCle)
        {
            motCle = motCle.ToLower();

            return _livres.Where(l =>
                l.Titre.ToLower().Contains(motCle) ||
                l.Auteur.ToLower().Contains(motCle) ||
                l.ISBN.Contains(motCle));
        }

        public IEnumerable<Livre> FiltrerParGenre(string genre)
            => _livres.Where(l => l.Genre == genre);

        public IEnumerable<Livre> ObtenirLivresDisponibles()
            => _livres.Where(l => l.EstDisponible);

        public IEnumerable<IGrouping<string, Livre>> GrouperParAuteur()
            => _livres.GroupBy(l => l.Auteur);
    }
}
