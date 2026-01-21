using Ex10.Models;
using Ex10.Services;
using Ex10.Views;

namespace Ex10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var livres = DonneesInitiales.CreerLivres();
            var emprunts = DonneesInitiales.CreerEmprunts();

            var livreService = new LivreService(livres);
            var empruntService = new EmpruntService(emprunts);
            var statsService = new StatistiquesService();
            var view = new BibliothequeView();

            bool quitter = false;

            while (!quitter)
            {
                switch (view.AfficherMenuPrincipal())
                {
                    case 1:
                        view.AfficherLivres(
                            livreService.RechercherLivres(view.DemanderRecherche()));
                        break;

                    case 2:
                        view.AfficherLivres(livreService.ObtenirLivresDisponibles());
                        break;

                    case 3:
                        Console.Write("Genre : ");
                        view.AfficherLivres(
                            livreService.FiltrerParGenre(Console.ReadLine()));
                        break;

                    case 4:
                        view.AfficherEmprunts(
                            empruntService.ObtenirEmpruntsEnCours());
                        break;

                    case 5:
                        view.AfficherEmprunts(
                            empruntService.ObtenirEmpruntsEnRetard());
                        break;

                    case 6:
                        view.AfficherStatistiques(
                            statsService.CalculerStatistiques(livres, emprunts));
                        break;

                    case 7:
                        view.AfficherRapportGenre(
                            statsService.GenererRapportParGenre(livres, emprunts));
                        break;

                    case 8:
                        foreach (var e in empruntService.ObtenirMeilleursEmprunteurs(3))
                            Console.WriteLine(e);
                        break;

                    case 9:
                        quitter = true;
                        break;
                }
            }
        }
    }
}
