using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string ISBN { get; set; }
        public int Annee { get; set; }
        public string Genre { get; set; }
        public int NombrePages { get; set; }
        public bool EstDisponible { get; set; }
    }
}
