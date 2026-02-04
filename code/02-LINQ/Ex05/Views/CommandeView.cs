using Ex05_RegroupementGroupBy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_RegroupementGroupBy.Views
{
    internal class CommandeView
    {
        public void AfficherGroupesParClient(IEnumerable<IGrouping<string, Commande>> groupes)
        {
            Console.WriteLine("\n--- Commandes par client ---");

            foreach (var groupe in groupes)
            {
                Console.WriteLine($"\nClient : {groupe.Key}");

                foreach (var c in groupe)
                {
                    Console.WriteLine(
                        $"- {c.Produit} | Qté: {c.Quantite} | CHF {c.PrixUnitaire}");
                }
            }
        }

        public void AfficherResumes(IEnumerable<ResumeParClient> resumes)
        {
            Console.WriteLine("\n--- Résumé par client ---");

            foreach (var r in resumes)
            {
                Console.WriteLine(
                    $"{r.NomClient} : {r.NombreCommandes} commandes | Total CHF {r.MontantTotal:0.00}");
            }
        }
    }
}
