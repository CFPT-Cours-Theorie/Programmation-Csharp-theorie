using Ex02.Services;
using Ex02.Views;

namespace Ex02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var service = new UtilisateurService();
            var view = new UtilisateurView();

            // Utilisateur ID = 1
            var utilisateur = await service.ObtenirUtilisateurAsync(1);
            view.AfficherUtilisateur(utilisateur);
            Console.WriteLine();

            // Liste complète (limite 5)
            var utilisateurs = await service.ObtenirTousUtilisateursAsync();
            view.AfficherListeUtilisateurs(utilisateurs.Take(5).ToList());

            Console.WriteLine();

            // ⭐ BONUS : Recherche par nom
            var recherche = await service.RechercherParNomAsync("Leanne");
            if (recherche != null)
            {
                Console.WriteLine("Utilisateur trouvé par recherche :");
                view.AfficherUtilisateur(recherche);
            }
        }
    }
}
