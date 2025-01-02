namespace JsuisUnGuerrier.Classes
{
    internal class Sorcier : Guerrier
    {
        private double _explosion;
        public double Explosion { get => _explosion; set { _explosion = value; } }

        public Sorcier(string nom, double pDV, double aTQ, double heal,double explosion ) : base(nom, pDV, aTQ, heal)
        {
            Explosion = explosion;
        }
        //affichage sorcier
        public override string ToString()
        {
            // le principe voudrais quelle sappel Megumi mais on verra 
            return $"Elfe - {Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        //Attaque basic 
        public override double Attaquer()
        {
            //Pourquoi stocker dice ? hum.. a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            //récap de son utilité le joueur lance un dé et ne sais pas sur quoi il va tomber il peut louper comme faire un critique comme faire une attaque Normal
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 100;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégat !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} a raté son attaque !");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 50;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        //Attaque spécial Sorcier celle la on peut dire que c'est une spécial..
        public override double AttaqueSpecial()
        {
            if (CDS <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t ╔════════════════╗ ");
                Console.WriteLine($"\t ║   EXPLOSION !! ║ ");
                Console.WriteLine($"\t ╚════════════════╝ ");
                Console.ResetColor();
                int rollAttackSpecial = dice.Next(1, 7);

                switch (rollAttackSpecial)
                {
                    case 6:

                        //les degat de Fleche quand il Active l'attaque Spécial
                        Explosion = 6000000000000;
                        // le delai de récupération
                        CDS = 9999;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Name} inflige 6000000000000 dégats avec un coup critique avec son EXPLOSION !");
                        Console.ResetColor();
                        break;
                    default:
                        Explosion = 1500;
                        CDS = 9999;
                        Console.WriteLine($"{Name} a fait 1500 Avec EXPLOSION !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
            return Explosion;
        }
    }
}
