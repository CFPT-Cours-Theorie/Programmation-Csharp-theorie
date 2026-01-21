using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.Models;

namespace Ex02.Views
{
    internal class UtilisateurView
    {
        public void AfficherUtilisateur(Utilisateur utilisateur)
        {
            Console.WriteLine("----- Utilisateur -----");
            Console.WriteLine($"ID    : {utilisateur.Id}");
            Console.WriteLine($"Nom   : {utilisateur.Name}");
            Console.WriteLine($"Email : {utilisateur.Email}");
            Console.WriteLine($"Phone : {utilisateur.Phone}");
        }

        public void AfficherListeUtilisateurs(List<Utilisateur> utilisateurs)
        {
            Console.WriteLine("----- Liste des utilisateurs -----");
            foreach (Utilisateur u in utilisateurs)
            {
                Console.WriteLine($"{u.Id} - {u.Name} ({u.Email})");
            }
        }
    }
}
