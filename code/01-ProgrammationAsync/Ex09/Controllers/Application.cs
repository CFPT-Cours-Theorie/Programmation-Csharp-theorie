using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex09_GestionnaireTelechargements.Services;
using Ex09_GestionnaireTelechargements.Views;

namespace Ex09_GestionnaireTelechargements.Controllers
{
    internal class Application
    {
        private readonly TelechargementService _service;
        private readonly MenuView _view;
        private const string HistoriquePath = "historique.json";

        public Application()
        {
            _service = new TelechargementService();
            _view = new MenuView();
        }

        public async Task RunAsync()
        {
            bool quitter = false;

            while (!quitter)
            {
                int choix = _view.AfficherMenuPrincipal();

                switch (choix)
                {
                    case 1:
                        _view.AfficherUrlsSuggerees();
                        Console.Write("URL : ");
                        string url = Console.ReadLine()!;

                        using (var cts = new CancellationTokenSource())
                        {
                            var progress = new Progress<int>(_view.AfficherProgression);

                            Console.WriteLine("Appuyez sur une touche pour annuler...");
                            Task.Run(() =>
                            {
                                Console.ReadKey();
                                cts.Cancel();
                            });

                            try
                            {
                                await _service.TelechargerFichierAsync(
                                    url,
                                    "download.txt",
                                    progress,
                                    cts.Token);
                            }
                            catch (OperationCanceledException)
                            {
                                Console.WriteLine("\nTéléchargement annulé.");
                            }
                        }
                        break;

                    case 2:
                        var urls = new List<string>
                        {
                            "https://example.com",
                            "https://httpbin.org/html",
                            "https://www.ietf.org"
                        };

                        using (var cts = new CancellationTokenSource())
                        {
                            var progress = new Progress<int>(_view.AfficherProgression);
                            await _service.TelechargerPlusieursAsync(urls, progress, cts.Token);
                        }
                        break;

                    case 3:
                        var historique = await _service.ChargerHistoriqueAsync(HistoriquePath);
                        _view.AfficherHistorique(historique);
                        break;

                    case 0:
                        await _service.SauvegarderHistoriqueAsync(HistoriquePath);
                        quitter = true;
                        break;
                }
            }
        }
    }
}
