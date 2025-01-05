namespace JsuisUnGuerrier.Classes
{
    internal class Humain : Guerrier
    {
        private double _rage;
        public double Rage { get => _rage; set { _rage = value; } }
        public Humain(string nom, double pDV, double aTQ, double heal, double rage) : base(nom, pDV, aTQ, heal)
        {
            Rage = rage;
        }
        // l'affichage 
        public override string ToString()
        {
            return $"Humain - {Name} (PV: {PDV}, ATQ: 65)\n";
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
                    ATQ = 130;
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
                    ATQ = 65;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        //Une attaque spécial pour pas que sa soit redondant a faire 1 ou 2 il fallait un autre choix
        // cette methode est une attaque spécial qui lance un dé a voir si il fait un crit a 6 et une attaque default au autre chiffre tomber.
        public override double AttaqueSpecial()
        {
            if (CDS <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Centre($" ╔═══════════════════════════════════════════════════════════════════════╗ ");
                Centre($" ║   Je ne cherche ni gloire, ni honneur... Seulement ta destruction !   ║ ");
                Centre($" ╚═══════════════════════════════════════════════════════════════════════╝ ");
                Console.ResetColor();
                int rollAttackSpecial = dice.Next(1, 7);
                switch (rollAttackSpecial)
                {
                    case 6:
                        //les degat de Fleche quand il Active l'attaque Spécial
                        Rage = 200;
                        // le delai de récupération
                        CDS = 5;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Centre($"{Name} inflige 180 dégats avec un coup critique avec Rage du Berserker !");
                        Console.ResetColor();
                        break;
                    default:
                        Rage = 100;
                        CDS = 5;
                        Centre($"{Name} a fait 90 Avec Rage du Berserker !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centre("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
            return Rage;
        }
        // la methode pour créer un Elfe dans sa propre classe ? hmm..

    }
}

