using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07.Models
{
    internal class EtatTelechargement
    {
        public int Progression { get; set; }    // 0 → 100
        public string Statut { get; set; }      // En cours / Annulé / Terminé
        public string Message { get; set; }
    }
}
