using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex06_GestionErreurs.Models;

namespace Ex06_GestionErreurs.Views
{
    internal class TelechargementView
    {
        public void AfficherTentative(ResultatTentative tentative)
        {
            Console.WriteLine(
                $"Tentative {tentative.Tentative} | " +
                $"{(tentative.Succes ? "SUCCÈS" : "ÉCHEC")} | " +
                $"{tentative.Duree.TotalMilliseconds} ms | " +
                $"{tentative.Message}");
        }

        public void AfficherResultatFinal(bool succes, List<ResultatTentative> historique)
        {
            Console.WriteLine("\n===== RÉSULTAT FINAL =====");
            Console.WriteLine(succes ? "Téléchargement réussi" : "Téléchargement échoué");
            Console.WriteLine($"Nombre de tentatives : {historique.Count}");
        }
    }
}
