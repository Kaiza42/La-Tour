using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsuisUnGuerrier.Classes
{
    internal class Epeiste : Guerrier 
    {
        //l'ajout de mon attaque spécial pour Epeiste
        private double _slash;
        public double Slash { get => _slash; set { _slash = value; } }
        public Epeiste(string nom, double pDV, double aTQ, double heal, double slash) : base(nom, pDV, aTQ, heal)
        {
            Slash = slash;
        }
        // l'affichage 
        public override string ToString()
        {
            return $"Epeiste - Lucas (PV: {PDV}, ATQ: 70)\n";
        }
        //Attaque basic 
        public override double Attaquer()
        {
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 140;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a raté son attaque !");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 70;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        // attaque spé
        public override double AttaqueSpecial()
        {
            if (CDS <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Centre($" ╔════════════════════════════════════════════════════════════╗ ");
                Centre($" ║   Ta résistance ne sera qu'une tache de plus sur ma lame.  ║ ");
                Centre($" ╚════════════════════════════════════════════════════════════╝ ");
                Console.ResetColor();
                int rollAttackSpecial = dice.Next(1, 7);
                switch (rollAttackSpecial)
                {
                    case 6:
                        //les degat de Slash quand il Active l'attaque Spécial
                        Slash = 180;
                        // le delai de récupération
                        CDS = 4;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Centre($"{Name} inflige 200 dégats avec un coup critique avec ses Slash !");
                        Console.ResetColor();
                        break;
                    default:
                        Slash = 90;
                        CDS = 4;
                        Centre($"{Name} a fait 100 Avec son Slash !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centre("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
            return Slash;
        }
        public override void ReductionCooldownSpecial()
        {
            //Si CD et plus grand que 0 
            if (CDS > 0)
            {
                // Va réduir le compteur de CD 
                CDS--;
            }
        }

    }
}

