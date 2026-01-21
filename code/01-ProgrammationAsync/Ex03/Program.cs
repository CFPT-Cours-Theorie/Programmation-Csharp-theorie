using Ex03_LectureEcritureFichiers.Models;
using Ex03_LectureEcritureFichiers.Services;
using Ex03_LectureEcritureFichiers.Views;

namespace Ex03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var service = new FichierService();
            var view = new FichierView();

            /**
             * Le fichier input.txt DOIT ÊTRE présent
             * et se trouve dans ./Ex03/bin/Debug/net8.0/input.txt
             */
            string inputPath = "input.txt";
            string outputPath = "output.txt";

            // Lecture
            string texte = await service.LireFichierAsync(inputPath);

            // Traitement
            StatistiquesTexte stats = await service.TraiterTexteAsync(texte);

            // Écriture
            await service.EcrireFichierAsync(outputPath, stats.TexteTraite);

            // Affichage
            view.AfficherStatistiques(stats);

            Console.WriteLine("Traitement terminé.");
        }
    }
}
