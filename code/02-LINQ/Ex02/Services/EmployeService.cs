using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.Models;

namespace Ex02.Services
{
    internal class EmployeService
    {
        private List<Employe> _employes;

        public EmployeService(List<Employe> employes)
        {
            _employes = employes;
        }

        // Salaire croissant
        public IOrderedEnumerable<Employe> TrierParSalaireCroissant()
        {
            return _employes
                .OrderBy(e => e.Salaire);
        }

        // Salaire décroissant
        public IOrderedEnumerable<Employe> TrierParSalaireDecroissant()
        {
            return _employes
                .OrderByDescending(e => e.Salaire);
        }

        // Département puis Nom
        public IOrderedEnumerable<Employe> TrierParDepartementPuisNom()
        {
            return _employes
                .OrderBy(e => e.Departement)
                .ThenBy(e => e.Nom);
        }

        // Ancienneté (plus ancien en premier)
        public IOrderedEnumerable<Employe> TrierParAnciennete()
        {
            return _employes
                .OrderBy(e => e.DateEmbauche);
        }

        // BONUS : Département (A-Z), puis Salaire (desc)
        public IOrderedEnumerable<Employe> TrierParDepartementPuisSalaireDecroissant()
        {
            return _employes
                .OrderBy(e => e.Departement)
                .ThenByDescending(e => e.Salaire);
        }
    }
}
