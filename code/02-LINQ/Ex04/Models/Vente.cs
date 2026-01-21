using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Models
{
    internal class Vente
    {
        public int Id { get; set; }
        public DateTime DateVente { get; set; }
        public decimal Montant { get; set; }
        public string Vendeur { get; set; }
        public string Region { get; set; }
    }
}
