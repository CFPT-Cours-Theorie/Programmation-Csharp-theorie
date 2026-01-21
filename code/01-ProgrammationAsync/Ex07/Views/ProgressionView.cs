using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex07.Models;

namespace Ex07.Views
{
    internal class ProgressionView
    {
        public void AfficherProgression(EtatTelechargement etat)
        {
            Console.WriteLine($"[{etat.Progression}%] {etat.Statut} - {etat.Message}");
        }

        public void AfficherAnnulation()
        {
            Console.WriteLine("Téléchargement annulé.");
        }

        public void AfficherCompletion()
        {
            Console.WriteLine("Téléchargement terminé avec succès.");
        }
    }
}
