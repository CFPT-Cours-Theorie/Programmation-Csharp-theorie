using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Views
{
    internal class BibliothequeView
    {
        public int AfficherMenuPrincipal()
        {
            Console.WriteLine("\n=== Gestionnaire de Bibliothèque ===");
            Console.WriteLine("1. Rechercher un livre");
            Console.WriteLine("2. Voir les livres disponibles");
            Console.WriteLine("3. Voir les livres par genre");
            Console.WriteLine("4. Voir les emprunts en cours");
            Console.WriteLine("5. Voir les emprunts en retard");
            Console.WriteLine("6. Afficher les statistiques");
            Console.WriteLine("7. Générer rapport par genre");
            Console.WriteLine("8. Top emprunteurs");
            Console.WriteLine("9. Quitter");

            return int.Parse(Console.ReadLine());
        }

        public void AfficherLivres(IEnumerable<Livre> livres)
        {
            foreach (var l in livres)
                Console.WriteLine($"{l.Titre} | {l.Auteur} | {l.Genre} | {(l.EstDisponible ? "Disponible" : "Emprunté")}");
        }

        public void AfficherEmprunts(IEnumerable<Emprunt> emprunts)
        {
            foreach (var e in emprunts)
                Console.WriteLine($"{e.NomEmprunteur} | Livre #{e.LivreId} | Retour prévu : {e.DateRetourPrevue:d}");
        }

        public void AfficherStatistiques(StatistiquesBibliotheque stats)
        {
            Console.WriteLine($"""
            Total livres : {stats.TotalLivres}
            Disponibles : {stats.LivresDisponibles}
            Empruntés : {stats.LivresEmpruntes}
            En retard : {stats.EmpruntsEnRetard}
            """);
        }

        public void AfficherRapportGenre(IEnumerable<RapportGenre> rapport)
        {
            foreach (var r in rapport)
                Console.WriteLine($"{r.Genre} | Livres: {r.NombreLivres} | Emprunts: {r.NombreEmprunts} | Top: {r.LivreLePlusEmprunte}");
        }

        public string DemanderRecherche()
        {
            Console.Write("Mot-clé : ");
            return Console.ReadLine();
        }
    }
}
