using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Ghoul : Guerrier
    {
        private int _griffe;
        public int Griffe { get => _griffe; set { _griffe = value; }}
        public Ghoul(string nom, double pDV, double aTQ, double heal, int griffe) : base(nom, pDV, aTQ, heal)
        {
            Griffe = griffe;
        }
        public override string ToString()
        {
            return $"\tGhoul - {Name} (PV: {PDV}, ATQ: 40)\n";
        }
        //Sur le principe le gobelin aparaitrer dans le Deuxieme Etage Et dornnerais le sorcier
        public override double Attaquer()
        {

            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 110;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a fait un Coup Critique et inflige {ATQ}");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} Rate son attaque Et inflige Tout de meme {ATQ} ");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 40;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        // attaque spécial de l'ogres
        public override double AttaqueSpecial()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Bon la phrases du gobelin a ne pas sortir de son contexte stp..
            Centre($" ╔════════════════════════════════════════╗ ");
            Centre($" ║  Tes os craqueront sous mes griffes !  ║ ");
            Centre($" ╚════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    Griffe = 140;
                    CDS = 3;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} inflige 140 dégats avec un coup critique avec Griffe !");
                    Console.ResetColor();
                    break;
                default:
                    Griffe = 70;
                    CDS = 3;
                    Centre($"{Name} a fait 70 Avec sa Lancer De Roue !");
                    break;
            }
            return Griffe;
        }

        public override void SubirDegats(double degat)
        {
            PDV -= degat;
            Centre($"{Name} as subis {degat} degats, il lui reste {PDV} de vie");

        }
        public override void Death()
        {
            Centre($"{Name} est mort.");

        }
    }
}
