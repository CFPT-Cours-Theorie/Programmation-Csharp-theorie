using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03_LectureEcritureFichiers.Models;

namespace Ex03_LectureEcritureFichiers.Views
{
    internal class FichierView
    {
        public void AfficherStatistiques(StatistiquesTexte stats)
        {
            Console.WriteLine("----- Statistiques -----");
            Console.WriteLine($"Nombre de lignes : {stats.NombreLignes}");
            Console.WriteLine($"Nombre de mots   : {stats.NombreMots}");
        }
    }
}
