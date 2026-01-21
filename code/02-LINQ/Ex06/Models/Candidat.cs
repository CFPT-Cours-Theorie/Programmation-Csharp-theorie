using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_OperationsEnsemblistes.Models
{
    internal class Candidat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Competence> Competences { get; set; } = new();
    }
}
