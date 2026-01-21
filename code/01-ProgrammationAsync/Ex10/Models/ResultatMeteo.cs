using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal class ResultatMeteo
    {
        public Meteo Meteo { get; set; }
        public bool Succes { get; set; }
        public string MessageErreur { get; set; }
    }
}
