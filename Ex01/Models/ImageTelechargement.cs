using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Models
{
    /// <summary>
    /// Représente une image à télécharger depuis Internet.
    /// Contient les informations nécessaires au suivi du téléchargement.
    /// </summary>
    internal class ImageTelechargement
    {
        /// <summary>
        /// Adresse URL de l'image à télécharger.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Nom du fichier sous lequel l'image sera enregistrée localement.
        /// </summary>
        public string NomFichier { get; set; }

        /// <summary>
        /// Statut actuel du téléchargement (ex : En attente, En cours, Terminé, Erreur).
        /// </summary>
        public string Statut { get; set; }

        /// <summary>
        /// Taille de l'image téléchargée en octets.
        /// </summary>
        public long TailleOctets { get; set; }
    }
}
