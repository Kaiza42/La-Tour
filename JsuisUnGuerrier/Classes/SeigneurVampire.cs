using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsuisUnGuerrier.Classes
{
    internal class SeigneurVampire : Guerrier
    {
        private int _nuitSanguinaire;
        public int NuitSanguinaire { get => _nuitSanguinaire; set { _nuitSanguinaire = value; } }
        public SeigneurVampire(string nom, double pDV, double aTQ, double heal, int nuitSanguinaire) : base(nom, pDV, aTQ, heal)
        {
            NuitSanguinaire = nuitSanguinaire;
        }
        public override string ToString()
        {
            return $"\tVampire - {Name} (PV: {PDV}, ATQ: 40)\n";
        }
        //Sur le principe le gobelin aparaitrer dans le Deuxieme Etage Et dornnerais le sorcier
        public override double Attaquer()
        {
            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 240;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a fait un Coup Critique et inflige {ATQ}");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 120;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        // attaque spécial de l'ogres
        public override double AttaqueSpecial()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Centre($" ╔══════════════════════════════════════════════════════════════════╗ ");
            Centre($" ║  Je n'ai pas de maîtres, je suis l'ancêtre de la nuit elle-même. ║ ");
            Centre($" ╚══════════════════════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    NuitSanguinaire = 300;
                    CDS = 4;
                    monstre[0].PDV += 200;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} inflige 300 dégats avec un coup critique avec Griffe !");
                    Centre($" Heal 60 PV {monstre[0]}");
                    Console.ResetColor();
                    break;
                default:
                    NuitSanguinaire = 70;
                    CDS = 4;
                    monstre[0].PDV += 100;
                    Centre($"{Name} a fait 150 Avec sa Lancer De Roue !");
                    Centre($"Recupère 100 Pv");
                    break;
            }
            return NuitSanguinaire;
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
            Epeiste epeiste = new Epeiste("Lucas", 450, 75, 10, 15);
            lesGuerrier.Add(epeiste);
        }
    }
}
