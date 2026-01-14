using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Views
{
    internal class MeteoView
    {
        public void AfficherProgression(int pourcentage, string ville)
        {
            Console.WriteLine($"[{pourcentage}%] Récupération de {ville}");
        }

        public void AfficherTableauMeteo(List<ResultatMeteo> resultats)
        {
            Console.WriteLine("\n--- Résultats météo ---");

            foreach (var r in resultats)
            {
                if (r.Succes)
                {
                    Console.WriteLine(
                        $"{r.Meteo.Ville,-10} | {r.Meteo.Temperature,5}°C | {r.Meteo.Description,-15} | Humidité {r.Meteo.Humidite}%");
                }
                else
                {
                    Console.WriteLine(r.MessageErreur);
                }
            }
        }

        public void AfficherErreur(string message)
        {
            Console.WriteLine($"Erreur : {message}");
        }
    }
}
