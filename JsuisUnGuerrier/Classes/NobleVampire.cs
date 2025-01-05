using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsuisUnGuerrier.Classes
{
    internal class NobleVampire : Guerrier
    {
        private int _sanguinaire;
        public int Sanguinaire { get => _sanguinaire; set { _sanguinaire = value; } }
        public NobleVampire(string nom, double pDV, double aTQ, double heal, int sanguinaire) : base(nom, pDV, aTQ, heal)
        {
            Sanguinaire = sanguinaire;
        }
        public override string ToString()
        {
            return $"\tNoble Vampire - {Name} (PV: {PDV}, ATQ: 80)\n";
        }
        //Sur le principe le gobelin aparaitrer dans le Deuxieme Etage Et dornnerais le sorcier
        public override double Attaquer()
        {
            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 160;
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
                    ATQ = 80;
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
            Centre($" ╔═══════════════════════════╗ ");
            Centre($" ║  Soumets-toi, misérable ! ║ ");
            Centre($" ╚═══════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    Sanguinaire = 200;
                    CDS = 5;
                    monstre[0].PDV += 80;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} inflige 160 dégats avec un coup critique avec Griffe !");
                    Centre($" Heal un Allié de 80 Pv");
                    Console.ResetColor();
                    break;
                default:
                    Sanguinaire = 100;
                    CDS = 5;
                    monstre[0].PDV += 40;
                    Centre($"{Name} a fait 70 Avec sa Lancer De Roue !");
                    Centre($" Heal un Allié de 40 Pv");
                    break;
            }
            return Sanguinaire;
        }
        public override void SubirDegats(double degat)
        {
            PDV -= degat;
            Centre($"{Name} as subis {degat} degats, il lui reste {PDV} de vie");
        }
        public override void Death()
        {
            Centre($"{Name} est mort.");
            Drop();
        }
        public void Drop()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Centre("Aventurier ! Un nouveau héros a été ajouté à votre compagnie !");
            Console.ResetColor();
            Elfe elfe = new Elfe("Eleanor", 450, 75, 10, 15);
            lesGuerrier.Add(elfe);
        }
    }
}
