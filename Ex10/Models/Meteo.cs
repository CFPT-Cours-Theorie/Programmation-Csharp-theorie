using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal class Meteo
    {
        public string Ville { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; }
        public int Humidite { get; set; }
        public DateTime DateHeure { get; set; }
    }
}
