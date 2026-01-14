using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Models;

namespace Ex04.Views
{
    internal class PerformanceView
    {
        public void AfficherComparaison(
            List<ResultatTelechargement> sequentiel,
            List<ResultatTelechargement> parallele)
        {
            Console.WriteLine("===== COMPARAISON =====");

            Console.WriteLine("\n--- Séquentiel ---");
            AfficherListe(sequentiel);

            Console.WriteLine("\n--- Parallèle ---");
            AfficherListe(parallele);

            Console.WriteLine("\nTemps total séquentiel : " +
                sequentiel.Sum(r => r.Duree.TotalMilliseconds) + " ms");

            Console.WriteLine("Temps total parallèle  : " +
                parallele.Max(r => r.Duree.TotalMilliseconds) + " ms");
        }

        private void AfficherListe(List<ResultatTelechargement> resultats)
        {
            foreach (var r in resultats)
            {
                Console.WriteLine(
                    $"{r.Url} | {(r.Succes ? "OK" : "KO")} | " +
                    $"{r.TailleCaracteres} chars | {r.Duree.TotalMilliseconds} ms");
            }
        }
    }
}
