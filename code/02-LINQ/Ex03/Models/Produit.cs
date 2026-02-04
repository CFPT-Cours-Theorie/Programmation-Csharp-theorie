using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ProjectionSelect.Models
{
    internal class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal PrixHT { get; set; }
        public double TauxTVA { get; set; }
        public string Categorie { get; set; }
        public int Stock { get; set; }
    }
}
