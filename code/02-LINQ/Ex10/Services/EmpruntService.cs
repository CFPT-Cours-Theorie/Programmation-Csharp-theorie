using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Services
{
    internal class EmpruntService
    {
        private readonly List<Emprunt> _emprunts;

        public EmpruntService(List<Emprunt> emprunts)
        {
            _emprunts = emprunts;
        }

        public IEnumerable<Emprunt> ObtenirEmpruntsEnCours()
            => _emprunts.Where(e => e.DateRetourEffective == null);

        public IEnumerable<Emprunt> ObtenirEmpruntsEnRetard()
            => _emprunts.Where(e =>
                e.DateRetourEffective == null &&
                e.DateRetourPrevue < DateTime.Now);

        public IEnumerable<string> ObtenirMeilleursEmprunteurs(int top)
            => _emprunts
                .GroupBy(e => e.NomEmprunteur)
                .OrderByDescending(g => g.Count())
                .Take(top)
                .Select(g => $"{g.Key} ({g.Count()} emprunts)");
    }
}
