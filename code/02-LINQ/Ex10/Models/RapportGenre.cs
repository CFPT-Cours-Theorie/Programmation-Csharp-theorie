using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal class RapportGenre
    {
        public string Genre { get; set; }
        public int NombreLivres { get; set; }
        public int NombreEmprunts { get; set; }
        public string LivreLePlusEmprunte { get; set; }
    }
}
