using JsuisUnGuerrier.Etage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Affichage
{
    internal class Affichage
    {
        public static void Centre(string dessin)
        {
            int windowWidth = Console.WindowWidth;
            int espace = (windowWidth - dessin.Length) / 2;
            Console.WriteLine(new string(' ', espace) + dessin);
        }
        public static void CentreEcrit(string dessin)
        {
            int windowWidth = Console.WindowWidth;
            int espace = (windowWidth - dessin.Length) / 2;
            Console.WriteLine(new string(' ', espace) + dessin);
        }

        public static void Acceuil()
        {
            Centre("*****************************************************");
            Centre("*   Arriveras Tu au Sommet de la tour Aventurier ?  *");
            Centre($"*****************************************************\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centre("            /\\            ");
            Centre("           /  \\           ");
            Centre("          /    \\          ");
            Centre("         /      \\         ");
            Centre("        /        \\        ");
            Centre("       //\\      /\\\\       ");
            Centre("      //  \\____/  \\\\      ");
            Centre("     //    |  |    \\\\     ");
            Centre("    //     |  |     \\\\    ");
            Centre("   //______|  |______\\\\   ");
            Centre("   |_______    _______|   ");
            Centre("   |       |  |       |   ");
            Centre("   |  []   |  |   []  |   ");
            Centre("   |       |  |       |   ");
            Centre("   |  ____/    \\____  |   ");
            Centre("   | /   \\______/   \\ |   ");
            Centre("  /|/     |    |     \\|\\  ");
            Centre(" /_|______|    |______|_\\ ");
            Centre("  ||||||||||||||||||||||  ");
            Centre("  ||||||||||||||||||||||  ");
            Centre(" /||||||||||||||||||||||\\ ");
            Centre("/________________________\\");
            Console.ResetColor();
            //pourquoi ne pas les mettre audessus ou endessous car sa créer un décalage que ce soit avec le dessin ou la phrases
            Console.WriteLine($"\n\n");
            Centre("Appuyez sur une touche pour rentrer dans les donjon Aventurier !");
            // permet de passer a la suite donc a la page du menu
           
            Console.Clear();
        }
        public static void Fermeture()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Centre($"╔═════════════════════════╗");
            Centre($"║  A bientôt Aventurier ! ║");
            Centre($"╚═════════════════════════╝");
            Console.ResetColor();
        }
        public static void FinDuJeu()
        {
            Console.Clear();
            Centre($"\n");
            Centre($"╔═══════════════════════════════════╗");
            Centre($"║  Merci D'etre arriver a la fin !  ║");
            Centre($"╚═══════════════════════════════════╝");
            Centre($"\n");
            Centre($"C'était la première fois que je tentais un jeu en console de commande, c'était bien sympa.");
            Centre($" Je pense y retoucher un jour ou l'utiliser pour un jeu plus poussé.");
            Centre($"Ce jeu m'a énormément appris, j'ai adoré le faire. C'était vraiment un très grand plaisir !"); 
            Console.ReadKey(true);
            Environment.Exit(0);
        }






    }
}
