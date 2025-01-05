
namespace JsuisUnGuerrier.Classes
{
    internal class Pretre : Guerrier
    {
        //l'ajout de mon attaque spécial pour Elfe 
        private double _protection;
        private double _colereDivine;
        public double ColereDivine { get => _colereDivine; set { _colereDivine = value; } }
        public double Protection { get => _protection; set { _protection = value; } }
        public Pretre(string nom, double pDV, double aTQ, double heal, double protection, double colereDivine) : base(nom, pDV, aTQ, heal)
        {
            ColereDivine = colereDivine;
            Protection = protection;
        }
        // l'affichage 
        public override string ToString()
        {
            return $"Prêtre - {Name} (PV: {PDV}, ATQ: 35)\n";
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
                    ATQ = 70;
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
                    ATQ = 35;
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
                Centre($" ╔════════════════════════════════════════════════════════════════════════════════════════╗ ");
                Centre($" ║ La miséricorde divine m'accorde ce répit, mais tu n'as plus de place sous ses cieux !  ║ ");
                Centre($" ╚════════════════════════════════════════════════════════════════════════════════════════╝ ");
                Console.ResetColor();
                int rollAttackSpecial = dice.Next(1, 7);

                switch (rollAttackSpecial)
                {
                    case 6:
                        //les degat de ColereDivine quand il Active l'attaque Spécial
                        ColereDivine = 170;
                        // le delai de récupération
                        CDS = 5;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Centre($"{Name} inflige 230 dégats avec un coup critique avec la Colere Divine !");
                        Console.ResetColor();
                        break;
                    default:
                        ColereDivine = 85;
                        CDS = 5;
                        Centre($"{Name} a fait 210 Avec la Colere Divine !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centre("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
            return ColereDivine;
        }
        public override double Defense(double degatMonstre)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Centre($" ╔════════════════════════════════════════════════════════════════════════════════════════════════╗ ");
            Centre($" ║ Le bouclier des cieux me garde, et même toi, misérable, ne pourras briser la volonté divine !  ║ ");
            Centre($" ╚════════════════════════════════════════════════════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            Protection = dice.Next(1, 7);
            switch (Protection)
            {
                case 6: 
                    CD = 6;
                    lesGuerrier[0].PDV += 200;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} Heal {lesGuerrier[0]} de 200 Pv");
                    break;
                case 1:
                    lesGuerrier[0].PDV += 120;
                    CD = 6;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} Heal {lesGuerrier[0]} de 120 Pv");
                    Console.ResetColor();
                    break;
                default:
                    lesGuerrier[0].PDV += 100; 
                    CD = 4;
                    Centre($"{Name} Heal {lesGuerrier[0]} de 100 Pv");
                    break;
            }
            return degatMonstre;
        }
    }
}
