using Ex09_GestionnaireTelechargements.Controllers;

namespace Ex09
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /**
             * MARCHE PAS COMPLETEMENT
             */
            var app = new Application();
            await app.RunAsync();
        }
    }
}
