using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_GestionErreurs.Models
{
    internal class ResultatTentative
    {
        public int Tentative { get; set; }
        public bool Succes { get; set; }
        public string Message { get; set; }
        public TimeSpan Duree { get; set; }
    }
}
