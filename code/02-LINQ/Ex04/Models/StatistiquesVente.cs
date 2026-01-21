using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Models
{
    internal class StatistiquesVente
    {
        public int NombreVentes { get; set; }
        public decimal MontantTotal { get; set; }
        public decimal MontantMoyen { get; set; }
        public decimal MontantMin { get; set; }
        public decimal MontantMax { get; set; }
    }
}
