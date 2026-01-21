using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Models;

namespace Ex04.Views
{
    internal class StatistiquesView
    {
        public void AfficherStatistiques(StatistiquesVente stats, string titre)
        {
            Console.WriteLine($"\n--- {titre} ---");

            Console.WriteLine($"Nombre de ventes : {stats.NombreVentes}");
            Console.WriteLine($"Montant total     : {stats.MontantTotal} CHF");
            Console.WriteLine($"Montant moyen     : {stats.MontantMoyen:F2} CHF");
            Console.WriteLine($"Montant min       : {stats.MontantMin} CHF");
            Console.WriteLine($"Montant max       : {stats.MontantMax} CHF");
        }
    }
}
