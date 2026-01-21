using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex09_GestionnaireTelechargements.Models;

namespace Ex09_GestionnaireTelechargements.Views
{
    internal class MenuView
    {
        public int AfficherMenuPrincipal()
        {
            Console.WriteLine("\n=== Gestionnaire de téléchargements ===");
            Console.WriteLine("1. Télécharger un fichier");
            Console.WriteLine("2. Télécharger plusieurs fichiers");
            Console.WriteLine("3. Afficher l'historique");
            Console.WriteLine("0. Quitter");
            Console.Write("Choix : ");

            return int.TryParse(Console.ReadLine(), out int choix) ? choix : -1;
        }

        public void AfficherHistorique(List<Telechargement> historique)
        {
            Console.WriteLine("\n--- Historique ---");
            foreach (var t in historique)
            {
                Console.WriteLine(
                    $"{t.DateHeure:g} | {t.Url} | {t.Statut} | {t.Taille} octets");
            }
        }

        public void AfficherProgression(int pourcentage)
        {
            Console.Write($"\rProgression : {pourcentage}%   ");
            if (pourcentage == 100)
                Console.WriteLine();
        }

        public void AfficherUrlsSuggerees()
        {
            Console.WriteLine("\nURLs suggérées :");
            Console.WriteLine("https://example.com");
            Console.WriteLine("https://httpbin.org/html");
            Console.WriteLine("https://jsonplaceholder.typicode.com/posts");
            Console.WriteLine("https://www.ietf.org");
        }
    }
}
