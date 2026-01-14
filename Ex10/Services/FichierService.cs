using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Services
{
    internal class FichierService
    {
        public async Task SauvegarderCsvAsync(List<Meteo> donnees, string chemin)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Ville;Temperature;Description;Humidite;DateHeure");

            foreach (var m in donnees)
            {
                sb.AppendLine(
                    $"{m.Ville};{m.Temperature};{m.Description};{m.Humidite};{m.DateHeure:g}");
            }

            await File.WriteAllTextAsync(chemin, sb.ToString());
        }
    }
}
