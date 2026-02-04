using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_RegroupementGroupBy.Models
{
    internal class ResumeParClient
    {
        public string NomClient { get; set; }
        public int NombreCommandes { get; set; }
        public decimal MontantTotal { get; set; }
    }
}
