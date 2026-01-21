using System.Diagnostics;
using Ex01.Models;
using Ex01.Services;
using Ex01.Views;

namespace Ex01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var imageService = new ImageService();
            var view = new ConsoleView();

            var urls = new List<string>
            {
                "https://randomuser.me/api/portraits/men/1.jpg",
                "https://randomuser.me/api/portraits/men/2.jpg",
                "https://randomuser.me/api/portraits/men/3.jpg"
            };

            var stopwatch = Stopwatch.StartNew();
            var tasks = new List<Task<ImageTelechargement>>();

            for (int i = 0; i < urls.Count; i++)
            {
                string nomFichier = $"image_{i + 1}.jpg";
                tasks.Add(imageService.TelechargerImageAsync(urls[i], nomFichier));
            }

            ImageTelechargement[] resultats = await Task.WhenAll(tasks);

            stopwatch.Stop();

            foreach (var image in resultats)
            {
                view.AfficherResultat(image);
            }

            Console.WriteLine("===============");
            Console.WriteLine($"Temps total : {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
