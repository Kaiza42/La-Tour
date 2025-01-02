using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class MaitreDesRat : Guerrier
    {
        private int _poison;
        public int Poison { get => _poison; set { _poison = value; } }
        public MaitreDesRat(string nom, double pDV, double aTQ, double dEF, int poison) : base(nom, pDV, aTQ, dEF)
        {
            Poison = poison;
        }
        public override string ToString()
        {
            return $"MaitreDesRat - {Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        public override double Attaquer()
        {
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 100;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} a fait un Coup Critique et inflige 100 !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} a raté son attaque ! ");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 50;
                    Console.WriteLine($"{Name} a fait 50 de dégat !");
                    break;
            }
            return ATQ;
        }
        public override double AttaqueSpecial()
        {
            if (CDS <= 0)
            { 
                int rollAttackSpecial = dice.Next(1, 7);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t ╔═════════════════════════════════════════════════════╗ ");
                Console.WriteLine($"\t ║  A L'attaque Britney, Witney,Courtney , Sydney!     ║ ");
                Console.WriteLine($"\t ╚═════════════════════════════════════════════════════╝ ");

                Console.ResetColor();
                switch (rollAttackSpecial)
                {
                    case 6:
                        ATQ = 180;
                        CDS = 5;
                        //l'appeltion de ma methode DOT du coup qui dureras le temp du Delai de attaque spécial 
                        Dot(15);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Name} a fait 180 de dégat !");
                        Console.ResetColor();
                        break;
                    default:
                        ATQ = 90;
                        CDS = 5;
                        Dot(15);
                        Console.WriteLine($"{Name} a fait 90 de dégat !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
            return ATQ;
        }
        // DOT damage over time 
        public void Dot(int degatPoison)
        {
            Poison = degatPoison;
            // Si le delai est plus grand que 0 la compétence ne ce lance pas 
            if (CDS > 0)
            {
                // Degat du poison
                monstre[0].PDV -= Poison;
                // si le delai de poison atteint 0 alors il s'arrete.
                if (CDS == 0)
                {
                    Poison = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{monstre[0].Name} n'est plus empoisonné !");
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
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{monstre[0].Name} subit {Poison} dégâts de poison.");
            Console.ResetColor();
        }

    }
}
