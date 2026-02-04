using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_RegroupementGroupBy.Models
{
    internal class Commande
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Produit { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public DateTime DateCommande { get; set; }
    }
}
