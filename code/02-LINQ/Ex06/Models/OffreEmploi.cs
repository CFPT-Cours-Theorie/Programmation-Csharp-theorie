using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_OperationsEnsemblistes.Models
{
    internal class OffreEmploi
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public List<Competence> CompetencesRequises { get; set; } = new();
    }
}
