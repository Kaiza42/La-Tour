using JsuisUnGuerrier.Etage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Affichage
{
    internal class AffichageEtage : Affichage
    {
        public static void EntreEtage()
        {
            Console.Clear();
            Centre("******************************************************");
            Centre($"*   Bienvenue Aventurier dans l'Etage {Etage1.compteurEtage} De la tour ! *");
            Centre($"******************************************************");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
