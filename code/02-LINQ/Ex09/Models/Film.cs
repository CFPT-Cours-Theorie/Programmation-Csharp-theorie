using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09.Models
{
    internal class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Annee { get; set; }
        public string Genre { get; set; }
        public double Note { get; set; }
        public int Duree { get; set; } // minutes
        public string Realisateur { get; set; }
    }
}
