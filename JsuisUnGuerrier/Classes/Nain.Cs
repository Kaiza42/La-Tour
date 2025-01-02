using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Nain : Guerrier
    {
        private bool _armureLourde;
        private double _feu;

        public bool ArmureLourde { get => _armureLourde; set { _armureLourde = value; } }
        public double Feu { get => _feu; set { _feu = value; } }


        public Nain(string nom, double pDV, double aTQ, double dEF, bool armureLourde, double feu) : base(nom, pDV, aTQ, dEF)
        {

            ArmureLourde = armureLourde;
            Feu = feu;
        }
        // l'affichage quand on affiche la Compagnie
        public override string ToString()
        {
            return $"Nain - {Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        //Le subir degat du nain 
        public override void SubirDegats(double degat)
        {
            if (ArmureLourde == true)
            {
                degat /= 2;
            }
            PDV = PDV - degat;
            Console.WriteLine($" {Name} a subi {degat}, il te reste {PDV}");
        }
        // le choix quand on selectionne le nain 
        public static void ChoiceNain()
        {
            Console.Clear();
            do
            {
                Console.Write("Veuillez saisir un nom pour votre Nain entre 1 a 10 caractre : ");
                saisieName = Console.ReadLine();
                if (saisieName.Length > 10 || saisieName.Length < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Veuillez saisir nombre de caractere entre 1 et 10");
                    Console.ResetColor();
                    Console.Write("Veuillez saisir un nom Valide pour votre Nain : ");
                    saisieName = Console.ReadLine();
                }
            } while (saisieName.Length > 10 || saisieName.Length < 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bienvenue {saisieName} ! ");
            Console.ResetColor();
            Nain guerrier = new Nain(saisieName, 600, 50, 0, true, 0);
            lesGuerrier.Add(guerrier);
        }
        //Attaque spé du Nain 
        public override double AttaqueSpecial()
        {
            
            if (CDS <= 0)
            {
                int rollAttackSpecial = dice.Next(1, 7);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t ╔═══════════════════════════════════════════════════╗ ");
            Console.WriteLine($"\t ║  Brûle dans le brasier de la forge ancestrale !   ║ ");
            Console.WriteLine($"\t ╚═══════════════════════════════════════════════════╝ ");
            Console.ResetColor();
                switch (rollAttackSpecial)
                {
                    case 6:
                        ATQ = 150;
                        CDS = 6;
                        //l'appeltion de ma methode DOT du coup qui dureras le temp du Delai de attaque spécial 
                        DotNain(30);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Name} a fait 150 de dégat !");
                        Console.ResetColor();
                        break;
                    default:
                        ATQ = 75;
                        CDS = 6;
                        DotNain(25);
                        Console.WriteLine($"{Name} a fait 75 de dégat !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("On abuse pas des Attaque Spécial Aventurier ! ");
                Console.ResetColor();
            }
            return ATQ;
        }
        // DOT damage over time 
        public void DotNain(int degatFeu)
        {
            Feu = degatFeu;
            // Si le delai est plus grand que 0 la compétence ne ce lance pas 
            if (CDS > 0)
            {
                // Degat du poison
                monstre[0].PDV -= Feu;
                // si le delai de poison atteint 0 alors il s'arrete.
                if (CDS == 0)
                {
                    Feu = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{monstre[0].Name} n'est plus En feu !");
                    Console.ResetColor();
                }
            }
        }

        public override void ReductionCooldownSpecial()
        {
            //Si CD et plus grand que 0 
            if (CDS > 0)
            {
                // Va réduir le compteur de CD 
                CDS--;
            }
            Dot(15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monstre[0].Name} subit {Feu} dégâts de Feu");
            Console.ResetColor();
        }


    }
}
