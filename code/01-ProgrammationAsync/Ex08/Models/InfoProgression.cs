using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_ProgressionIProgress.Models
{
    internal class InfoProgression
    {
        public int Pourcentage { get; set; }
        public int EtapeCourante { get; set; }
        public int EtapesTotal { get; set; }
        public TimeSpan TempsEcoule { get; set; }

        // ⭐ BONUS
        public TimeSpan TempsRestantEstime { get; set; }
    }
}
