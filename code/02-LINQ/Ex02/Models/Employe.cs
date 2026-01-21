using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02.Models
{
    internal class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Departement { get; set; }
        public decimal Salaire { get; set; }
        public DateTime DateEmbauche { get; set; }
    }
}
