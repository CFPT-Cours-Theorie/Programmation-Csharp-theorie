using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex07_TakeSkipPagination.Models;

namespace Ex07_TakeSkipPagination.Views
{
    internal class ArticleView
    {
        public void AfficherArticles(IEnumerable<Article> articles, string titre)
        {
            Console.WriteLine($"\n--- {titre} ---");

            foreach (var a in articles)
            {
                Console.WriteLine(
                    $"{a.Titre} | {a.Auteur} | {a.DatePublication:dd/MM/yyyy} | 👁 {a.NombreVues}");
            }
        }

        public void AfficherPage(PageResultat<Article> page)
        {
            Console.WriteLine($"\n=== Page {page.PageActuelle}/{page.TotalPages} ===");

            foreach (var a in page.Elements)
            {
                Console.WriteLine(
                    $"{a.Titre} ({a.DatePublication:dd/MM/yyyy}) - {a.NombreVues} vues");
            }
        }
    }
}
