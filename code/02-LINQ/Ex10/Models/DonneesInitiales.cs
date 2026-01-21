using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal static class DonneesInitiales
    {
        public static List<Livre> CreerLivres()
        {
            return new List<Livre>
            {
                new Livre { Id = 1, Titre = "1984", Auteur = "George Orwell", ISBN = "9780451524935", Annee = 1949, Genre = "Drame", NombrePages = 328, EstDisponible = false },
                new Livre { Id = 2, Titre = "Le Seigneur des Anneaux", Auteur = "J.R.R. Tolkien", ISBN = "9780261103573", Annee = 1954, Genre = "Fantasy", NombrePages = 1216, EstDisponible = true },
                new Livre { Id = 3, Titre = "Fondation", Auteur = "Isaac Asimov", ISBN = "9780553293357", Annee = 1951, Genre = "Science-Fiction", NombrePages = 255, EstDisponible = true },
                new Livre { Id = 4, Titre = "Dune", Auteur = "Frank Herbert", ISBN = "9780441013593", Annee = 1965, Genre = "Science-Fiction", NombrePages = 412, EstDisponible = false },
                new Livre { Id = 5, Titre = "Le Petit Prince", Auteur = "Antoine de Saint-Exupéry", ISBN = "9780156013987", Annee = 1943, Genre = "Jeunesse", NombrePages = 96, EstDisponible = true },

                new Livre { Id = 6, Titre = "Harry Potter 1", Auteur = "J.K. Rowling", ISBN = "9780747532699", Annee = 1997, Genre = "Fantasy", NombrePages = 223, EstDisponible = false },
                new Livre { Id = 7, Titre = "Harry Potter 2", Auteur = "J.K. Rowling", ISBN = "9780747538493", Annee = 1998, Genre = "Fantasy", NombrePages = 251, EstDisponible = true },
                new Livre { Id = 8, Titre = "Clean Code", Auteur = "Robert C. Martin", ISBN = "9780132350884", Annee = 2008, Genre = "Informatique", NombrePages = 464, EstDisponible = true },
                new Livre { Id = 9, Titre = "The Pragmatic Programmer", Auteur = "Andrew Hunt", ISBN = "9780201616224", Annee = 1999, Genre = "Informatique", NombrePages = 352, EstDisponible = false },
                new Livre { Id = 10, Titre = "L'Étranger", Auteur = "Albert Camus", ISBN = "9782070360024", Annee = 1942, Genre = "Drame", NombrePages = 184, EstDisponible = true },

                new Livre { Id = 11, Titre = "It", Auteur = "Stephen King", ISBN = "9781501142970", Annee = 1986, Genre = "Horreur", NombrePages = 1138, EstDisponible = true },
                new Livre { Id = 12, Titre = "Shining", Auteur = "Stephen King", ISBN = "9780307743657", Annee = 1977, Genre = "Horreur", NombrePages = 447, EstDisponible = false },
                new Livre { Id = 13, Titre = "Le Nom de la Rose", Auteur = "Umberto Eco", ISBN = "9782253033135", Annee = 1980, Genre = "Policier", NombrePages = 512, EstDisponible = true },
                new Livre { Id = 14, Titre = "Da Vinci Code", Auteur = "Dan Brown", ISBN = "9780307474278", Annee = 2003, Genre = "Thriller", NombrePages = 689, EstDisponible = true },
                new Livre { Id = 15, Titre = "Inferno", Auteur = "Dan Brown", ISBN = "9781400079155", Annee = 2013, Genre = "Thriller", NombrePages = 480, EstDisponible = false }
            };
        }

        public static List<Emprunt> CreerEmprunts()
        {
            return new List<Emprunt>
            {
                new Emprunt
                {
                    Id = 1,
                    LivreId = 1,
                    NomEmprunteur = "Alice",
                    DateEmprunt = DateTime.Now.AddDays(-20),
                    DateRetourPrevue = DateTime.Now.AddDays(-5),
                    DateRetourEffective = null // en retard
                },
                new Emprunt
                {
                    Id = 2,
                    LivreId = 4,
                    NomEmprunteur = "Bob",
                    DateEmprunt = DateTime.Now.AddDays(-10),
                    DateRetourPrevue = DateTime.Now.AddDays(5),
                    DateRetourEffective = null // en cours
                },
                new Emprunt
                {
                    Id = 3,
                    LivreId = 6,
                    NomEmprunteur = "Alice",
                    DateEmprunt = DateTime.Now.AddDays(-30),
                    DateRetourPrevue = DateTime.Now.AddDays(-10),
                    DateRetourEffective = DateTime.Now.AddDays(-8) // rendu
                },
                new Emprunt
                {
                    Id = 4,
                    LivreId = 9,
                    NomEmprunteur = "Charlie",
                    DateEmprunt = DateTime.Now.AddDays(-15),
                    DateRetourPrevue = DateTime.Now.AddDays(-1),
                    DateRetourEffective = null // en retard
                },
                new Emprunt
                {
                    Id = 5,
                    LivreId = 12,
                    NomEmprunteur = "David",
                    DateEmprunt = DateTime.Now.AddDays(-7),
                    DateRetourPrevue = DateTime.Now.AddDays(7),
                    DateRetourEffective = null
                },
                new Emprunt
                {
                    Id = 6,
                    LivreId = 15,
                    NomEmprunteur = "Alice",
                    DateEmprunt = DateTime.Now.AddDays(-3),
                    DateRetourPrevue = DateTime.Now.AddDays(10),
                    DateRetourEffective = null
                },
                new Emprunt
                {
                    Id = 7,
                    LivreId = 3,
                    NomEmprunteur = "Bob",
                    DateEmprunt = DateTime.Now.AddDays(-40),
                    DateRetourPrevue = DateTime.Now.AddDays(-25),
                    DateRetourEffective = DateTime.Now.AddDays(-20)
                },
                new Emprunt
                {
                    Id = 8,
                    LivreId = 8,
                    NomEmprunteur = "Charlie",
                    DateEmprunt = DateTime.Now.AddDays(-5),
                    DateRetourPrevue = DateTime.Now.AddDays(5),
                    DateRetourEffective = null
                },
                new Emprunt
                {
                    Id = 9,
                    LivreId = 10,
                    NomEmprunteur = "Eve",
                    DateEmprunt = DateTime.Now.AddDays(-12),
                    DateRetourPrevue = DateTime.Now.AddDays(-2),
                    DateRetourEffective = null // en retard
                },
                new Emprunt
                {
                    Id = 10,
                    LivreId = 14,
                    NomEmprunteur = "Bob",
                    DateEmprunt = DateTime.Now.AddDays(-1),
                    DateRetourPrevue = DateTime.Now.AddDays(14),
                    DateRetourEffective = null
                }
            };
        }
    }
}
