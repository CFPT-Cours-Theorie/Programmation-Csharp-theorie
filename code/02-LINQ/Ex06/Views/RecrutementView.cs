using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_OperationsEnsemblistes.Views
{
    internal class RecrutementView
    {
        public void AfficherCompetences(IEnumerable<string> competences, string titre)
        {
            Console.WriteLine($"\n--- {titre} ---");

            foreach (var c in competences)
            {
                Console.WriteLine($"- {c}");
            }
        }
    }
}
