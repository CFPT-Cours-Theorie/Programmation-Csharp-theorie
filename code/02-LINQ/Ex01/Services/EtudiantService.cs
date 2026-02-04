using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01.Models;

namespace Ex01.Services
{
    internal class EtudiantService
    {
        private List<Etudiant> _etudiants;

        public EtudiantService(List<Etudiant> etudiants)
        {
            _etudiants = etudiants;
        }

        // Étudiants majeurs (18+)
        public List<Etudiant> ObtenirEtudiantsMajeurs()
        {
            return _etudiants
                .Where(e => e.Age >= 18)
                .ToList();
        }

        // Étudiants avec moyenne > seuil
        public List<Etudiant> ObtenirEtudiantsAvecMoyenneSuperieure(double seuilMoyenne)
        {
            return _etudiants
                .Where(e => e.Moyenne > seuilMoyenne)
                .ToList();
        }

        // Étudiants dans une tranche d’âge
        public List<Etudiant> ObtenirEtudiantsParTrancheAge(int ageMin, int ageMax)
        {
            return _etudiants
                .Where(e => e.Age >= ageMin && e.Age <= ageMax)
                .ToList();
        }

        // BONUS : nom commence par une lettre
        public List<Etudiant> ObtenirEtudiantsDontNomCommencePar(char lettre)
        {
            return _etudiants
                .Where(e => e.Nom.StartsWith(lettre.ToString(),
                         StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
