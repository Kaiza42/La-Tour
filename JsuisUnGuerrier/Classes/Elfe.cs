namespace JsuisUnGuerrier.Classes
{
    internal class Elfe : Guerrier
    {
        //l'ajout de mon attaque spécial pour Elfe 
        private double _fleche;
        public double Fleche { get => _fleche; set { _fleche = value; } }
        public Elfe(string nom, double pDV, double aTQ, double heal, double fleche) : base(nom, pDV, aTQ, heal)
        {
            Fleche = fleche;
        }
        // l'affichage 
        public override string ToString()
        {
            return $"Elfe - {Name} (PV: {PDV}, ATQ: 75)\n";
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
                    ATQ = 150;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a raté son attaque !");
                    Console.ResetColor();
                    PDV -= 15;
                    break;
                default:
                    ATQ = 75;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    PDV -= 15;
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
                Centre($" ╔═══════════════════════════════════╗ ");
                Centre($" ║   Je ne Rate Jamais ma Cible !    ║ ");
                Centre($" ╚═══════════════════════════════════╝ ");
                Console.WriteLine();
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
                switch (rollAttackSpecial)
                {
                    case 6:
                        //les degat de Fleche quand il Active l'attaque Spécial
                        Fleche = 170;
                        // le delai de récupération
                        CDS = 5;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Centre($"{Name} inflige 180 dégats avec un coup critique avec ses Double FLeche !");
                        Console.ResetColor();
                        break;
                    default:
                        Fleche = 85;
                        CDS = 5;
                        Centre($"{Name} a fait 90 Avec ses Double Fleche !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centre("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
                return Fleche;
        }
        // la methode pour créer un Elfe dans sa propre classe ? hmm..
        public static void ChoiceElfe()
        {
            Console.Clear();
            //pourquoi un do while pour verifier une saisie ? Il doit bien faire la saisie une fois pour vérifier si il fait une erreure
            do
            {
                CentreEcrit("Veuillez saisir un nom pour votre Elfe entre 1 a 10 caractre : ");
                saisieName = Console.ReadLine();
                //Gere la saisie de name pas trop long pas trop court
                if (saisieName.Length > 16 || saisieName.Length < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre("Veuillez saisir nombre de caractere entre 1 et 10");
                    Console.ResetColor();
                    CentreEcrit("Veuillez saisir un nom Valide pour votre Elfe : ");
                    saisieName = Console.ReadLine();
                }
                // control longeur de la saisie pour le pseudo 
            } while (saisieName.Length > 16 || saisieName.Length < 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Centre($"Bienvenue {saisieName} ! \n" );
            Console.ResetColor();
            Elfe guerrier = new Elfe(saisieName, 500, 75, 75, 90);
            //j'ajoute le guerrier ou l'aventurier choisie hein.
            lesGuerrier.Add(guerrier);

        }
    }
}
