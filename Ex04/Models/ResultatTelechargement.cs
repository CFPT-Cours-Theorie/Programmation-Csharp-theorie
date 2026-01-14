using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Models
{
    internal class ResultatTelechargement
    {
        public string Url { get; set; }
        public int TailleCaracteres { get; set; }
        public TimeSpan Duree { get; set; }
        public bool Succes { get; set; }
    }
}
