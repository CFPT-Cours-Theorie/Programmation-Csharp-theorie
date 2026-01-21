using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01.Models;

namespace Ex01.Views
{
    internal class EtudiantView
    {
        public void AfficherListeEtudiants(List<Etudiant> etudiants, string titre)
        {
            Console.WriteLine($"\n--- {titre} ---");

            if (!etudiants.Any())
            {
                Console.WriteLine("Aucun étudiant trouvé.");
                return;
            }

            foreach (var e in etudiants)
            {
                Console.WriteLine(
                    $"{e.Id,2} | {e.Prenom,-8} {e.Nom,-10} | {e.Age,2} ans | Moyenne : {e.Moyenne}");
            }
        }
    }
}
