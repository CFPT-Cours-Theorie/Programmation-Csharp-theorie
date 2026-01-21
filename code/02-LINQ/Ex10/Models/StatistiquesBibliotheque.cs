using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal class StatistiquesBibliotheque
    {
        public int TotalLivres { get; set; }
        public int LivresDisponibles { get; set; }
        public int LivresEmpruntes { get; set; }
        public int EmpruntsEnRetard { get; set; }
    }
}
