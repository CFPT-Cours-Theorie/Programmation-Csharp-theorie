using Ex07_TakeSkipPagination.Models;
using Ex07_TakeSkipPagination.Services;
using Ex07_TakeSkipPagination.Views;

namespace Ex07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Génération de 25 articles
            var articles = new List<Article>();
            var random = new Random();

            for (int i = 1; i <= 25; i++)
            {
                articles.Add(new Article
                {
                    Id = i,
                    Titre = $"Article {i}",
                    Contenu = "Lorem ipsum...",
                    Auteur = $"Auteur {(i % 5) + 1}",
                    DatePublication = DateTime.Now.AddDays(-i),
                    NombreVues = random.Next(50, 2000)
                });
            }

            var service = new ArticleService(articles);
            var view = new ArticleView();

            // Top 5 articles
            view.AfficherArticles(
                service.ObtenirTopArticles(5),
                "Top 5 articles les plus vus");

            // 10 articles récents
            view.AfficherArticles(
                service.ObtenirArticlesRecents(10),
                "10 articles les plus récents");

            // Pagination – page 2
            var page2 = service.ObtenirPage(2, 5);
            view.AfficherPage(page2);

            // ⭐ Bonus : navigation interactive
            int pageCourante = 1;
            int taillePage = 5;
            ConsoleKey key;

            do
            {
                Console.Clear();
                var page = service.ObtenirPage(pageCourante, taillePage);
                view.AfficherPage(page);

                Console.WriteLine("\n< Précédent | > Suivant | Q Quitter");
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.RightArrow && pageCourante < page.TotalPages)
                    pageCourante++;

                if (key == ConsoleKey.LeftArrow && pageCourante > 1)
                    pageCourante--;

            } while (key != ConsoleKey.Q);
        }
    }
}
