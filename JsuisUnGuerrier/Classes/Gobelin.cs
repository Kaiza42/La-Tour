﻿namespace JsuisUnGuerrier.Classes 
{
    internal class Gobelin : Guerrier
    {
        private int _coupDePoignard;
        public int CoupDePoignard { get => _coupDePoignard; set { _coupDePoignard = value; } }
        public Gobelin(string nom, double pDV, double aTQ, double heal, int coupDePoignard) : base(nom, pDV, aTQ, heal)
        {
            CoupDePoignard = coupDePoignard;
        }
        public override string ToString()
        {
            return $"\tGobelin - {Name} (PV: {PDV}, ATQ: 40)\n";
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
            Centre($" ╔═════════════════════════════════════════════════╗ ");
            Centre($" ║  C'est toujours plus amusant quand tu hurles !  ║ ");
            Centre($" ╚═════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    CoupDePoignard = 140;
                    CDS = 5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} inflige 140 dégats avec un coup critique avec sa Lancer de Roue !");
                    Console.ResetColor();
                    break;
                default:
                    CoupDePoignard = 70;
                    CDS = 5;
                    Centre($"{Name} a fait 70 Avec sa Lancer De Roue !");
                    break;
            }
            return CoupDePoignard;
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
