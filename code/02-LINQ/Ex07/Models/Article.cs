using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_TakeSkipPagination.Models
{
    internal class Article
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public DateTime DatePublication { get; set; }
        public string Auteur { get; set; }
        public int NombreVues { get; set; }
    }
}
