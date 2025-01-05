using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class ServantVampire : Guerrier
    {
        private int _etreinteSanguine;
        public int EtreinteSanguine { get => _etreinteSanguine; set { _etreinteSanguine = value; } }
        public ServantVampire(string nom, double pDV, double aTQ, double heal, int etreinteSanguine) : base(nom, pDV, aTQ, heal)
        {
            EtreinteSanguine = etreinteSanguine;
        }
        public override string ToString()
        {
            return $"\tVampire - {Name} (PV: {PDV}, ATQ: 50)\n";
        }
        //Sur le principe le gobelin aparaitrer dans le Deuxieme Etage Et dornnerais le sorcier
        public override double Attaquer()
        {
            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 100;
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
                    ATQ = 50;
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
            Centre($" ╔════════════════════════════════════════════╗ ");
            Centre($" ║ Tu goûteras à la morsure de l'obéissance ! ║ ");
            Centre($" ╚════════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    EtreinteSanguine = 140;
                    CDS = 5;
                    monstre[0].PDV += 40;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} inflige 140 dégats avec un coup critique avec Etreinte Sanguine !");
                    Centre($" Heal un Allié de 40 Pv");
                    Console.ResetColor();
                    break;
                default:
                    EtreinteSanguine = 70;
                    CDS = 5;
                    monstre[0].PDV += 20;
                    Centre($"{Name} a fait 70 Avec Etreinte Sanguine !");
                    Centre($" Heal un allié de 20 Pv");
                    break;
            }
            return EtreinteSanguine;
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
