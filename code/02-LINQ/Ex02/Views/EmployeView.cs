using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.Models;

namespace Ex02.Views
{
    internal class EmployeView
    {
        public void AfficherTableauEmployes(IEnumerable<Employe> employes, string titre)
        {
            Console.WriteLine($"\n--- {titre} ---");

            foreach (var e in employes)
            {
                Console.WriteLine(
                    $"{e.Id,2} | {e.Prenom,-8} {e.Nom,-10} | {e.Departement,-13} | " +
                    $"{e.Salaire,7} CHF | Embauché le {e.DateEmbauche:dd.MM.yyyy}");
            }
        }
    }
}
