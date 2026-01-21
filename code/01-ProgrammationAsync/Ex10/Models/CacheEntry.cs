using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Models
{
    internal class CacheEntry
    {
        public string Ville { get; set; }
        public Meteo Meteo { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
