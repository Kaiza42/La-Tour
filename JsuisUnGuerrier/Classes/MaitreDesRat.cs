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
            return $"MaitreDesRat - {Name} (PV: {PDV}, ATQ: 45)\n";
        }
        public override double Attaquer()
        {
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 100;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} a fait un Coup Critique et inflige 100 !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a raté son attaque ! ");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 45;
                    Centre($"{Name} a fait 50 de dégat !");
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
                Centre($" ╔═════════════════════════════════════════════════════╗ ");
                Centre($" ║  A L'attaque Britney, Witney,Courtney , Sydney!     ║ ");
                Centre($" ╚═════════════════════════════════════════════════════╝ ");
                Console.WriteLine();
                Console.ResetColor();
                switch (rollAttackSpecial)
                {
                    case 6:
                        ATQ = 180;
                        CDS = 5;
                        //l'appeltion de ma methode DOT du coup qui dureras le temp du Delai de attaque spécial 
                        Dot(15);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Centre($"{Name} a fait 180 de dégat !");
                        Console.ResetColor();
                        break;
                    default:
                        ATQ = 90;
                        CDS = 5;
                        Dot(15);
                        Centre($"{Name} a fait 90 de dégat !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centre("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
            return ATQ;
        }
        // DOT damage over time 
        public override void Dot(int degatFeu)
        {
            Poison = degatFeu;
            // Si le delai est plus grand que 0 la compétence ne ce lance pas 
            if (CDS > 0)
            {
                // Si le cooldown est encore actif (CDS > 0), rien ne se passe
                return; // Retourne et arrête l'exécution de la méthode ici
            }
            // Degat du Feu
            monstre[0].PDV -= Poison;
        }
        public override void ReductionCooldownSpecial()
        {
            //Si monstre a au moins 1 membre dans la liste alors il le fait sinon.. bah il fait rien logique 
            if (monstre.Count > 0)
            {
                //Si CD et plus grand que 0 
                if (CDS > 0)
                {
                    // Va réduir le compteur de CD 
                    CDS--;
                }
                Dot(15);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Centre($"{monstre[0].Name} subit {Poison} dégâts de Poison");
                Console.ResetColor();
            }
        }
    }
}
