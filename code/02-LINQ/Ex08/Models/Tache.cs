using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_VerificationsAnyAllContains.Models
{
    internal class Tache
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public bool EstTerminee { get; set; }
        public int Priorite { get; set; } // 1 à 5
        public DateTime DateEcheance { get; set; }
    }
}
