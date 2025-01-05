using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsuisUnGuerrier.Classes
{

    internal class HobGobelin : Guerrier
    {
        private int _coupDeMassue;
        public int CoupDeMassue { get => _coupDeMassue; set { _coupDeMassue = value; } }
        public HobGobelin(string nom, double pDV, double aTQ, double heal) : base(nom, pDV, aTQ, heal)
        {

        }
        public override string ToString()
        {
            return $"\tHobGobelin - {Name} (PV: {PDV}, ATQ: 60)\n";
        }
        //Sur le principe le gobelin aparaitrer dans le Deuxieme Etage Et dornnerais le sorcier
        public override double Attaquer()
        {

            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 120;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a fait un Coup Critique et inflige {ATQ}");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} Rate son attaque Mais inflige Tout de meme {ATQ} ");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 60;
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
            Centre($" ╔═════════════════════════════════════════════════════════════════════════════════╗ ");
            Centre($" ║  Regarde bien cette masse... elle a brisé des crânes plus solides que le tien.  ║ ");
            Centre($" ╚═════════════════════════════════════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    CoupDeMassue = 180;
                    CDS = 6;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} inflige 180 dégats avec un coup critique avec son Coup De Masse !");
                    Console.ResetColor();
                    break;
                default:
                    CoupDeMassue = 90;
                    CDS = 6;
                    Centre($"{Name} a fait 90 Avec son Coup de Masse !");
                    break;
            }
            return CoupDeMassue;
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
