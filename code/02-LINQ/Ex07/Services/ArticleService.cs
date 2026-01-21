using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex07_TakeSkipPagination.Models;

namespace Ex07_TakeSkipPagination.Services
{
    internal class ArticleService
    {
        private readonly List<Article> _articles;

        public ArticleService(List<Article> articles)
        {
            _articles = articles;
        }

        // Top articles par vues
        public IEnumerable<Article> ObtenirTopArticles(int nombre)
        {
            return _articles
                .OrderByDescending(a => a.NombreVues)
                .Take(nombre);
        }

        // Articles les plus récents
        public IEnumerable<Article> ObtenirArticlesRecents(int nombre)
        {
            return _articles
                .OrderByDescending(a => a.DatePublication)
                .Take(nombre);
        }

        // Pagination
        public PageResultat<Article> ObtenirPage(int numeroPage, int taillePage)
        {
            int totalElements = _articles.Count;
            int totalPages = (int)Math.Ceiling(totalElements / (double)taillePage);

            var elements = _articles
                .OrderByDescending(a => a.DatePublication)
                .Skip((numeroPage - 1) * taillePage)
                .Take(taillePage)
                .ToList();

            return new PageResultat<Article>
            {
                Elements = elements,
                PageActuelle = numeroPage,
                TotalPages = totalPages,
                TotalElements = totalElements
            };
        }

        // Skip simple
        public IEnumerable<Article> IgnorerPremiers(int nombre)
        {
            return _articles.Skip(nombre);
        }
    }
}
