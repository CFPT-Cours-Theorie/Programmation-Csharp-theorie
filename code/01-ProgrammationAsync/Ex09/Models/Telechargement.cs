using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_GestionnaireTelechargements.Models
{
    internal class Telechargement
    {
        public string Url { get; set; }
        public string NomFichier { get; set; }
        public long Taille { get; set; }
        public DateTime DateHeure { get; set; }
        public string Statut { get; set; }
    }
}
