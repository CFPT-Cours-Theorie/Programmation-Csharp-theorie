using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_SimulBDD.Models
{
    internal class Produit
    {
        public int Id { get; init; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }

        public Produit(int id, string nom, decimal prix, int stock)
        {
            Id = id;
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
            Prix = prix;
            Stock = stock;
        }
    }
}
