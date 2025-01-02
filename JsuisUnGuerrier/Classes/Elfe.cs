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
                    ATQ = 150;
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
                    ATQ = 75;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégat !");
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
            Console.WriteLine($"\t ╔═══════════════════════════════════╗ ");
            Console.WriteLine($"\t ║   Je ne Rate Jamais ma Cible !    ║ ");
            Console.WriteLine($"\t ╚═══════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            
                switch (rollAttackSpecial)
                {
                    case 6:

                        //les degat de Fleche quand il Active l'attaque Spécial
                        Fleche = 180;
                        // le delai de récupération
                        CDS = 5;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Name} inflige 180 dégats avec un coup critique avec ses Double FLeche !");
                        Console.ResetColor();
                        break;
                    default:
                        Fleche = 90;
                        CDS = 5;
                        Console.WriteLine($"{Name} a fait 90 Avec ses Double Fleche !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("On abuse pas des Attaque spécial Aventurier ! ");
                Console.ResetColor();
            }
                return Fleche;
        }
        // la methode pour créer un Elfe dans sa propre classe ? hmm..
        public static void ChoiceElfe()
        {
            Console.Clear();
            //pourquoi un do while pour verifier une saisie ? Il doit bien faire la saisie une fois pourvérifier si il fait une erreure
            do
            {
                Console.Write("Veuillez saisir un nom pour votre Elfe entre 1 a 10 caractre : ");
                saisieName = Console.ReadLine();
                //Gere la saisie de name pas trop long pas trop court
                if (saisieName.Length > 10 || saisieName.Length < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Veuillez saisir nombre de caractere entre 1 et 10");
                    Console.ResetColor();
                    Console.Write("Veuillez saisir un nom Valide pour votre Elfe : ");
                    saisieName = Console.ReadLine();
                }
                // control longeur de la saisie pour le pseudo 
            } while (saisieName.Length > 16 || saisieName.Length < 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Bienvenue {saisieName} ! ");
            Console.ResetColor();
            // j'ai fait un choix de type equilibrage et surtout moins de probleme a gerer en enlevant la saisieATQ sa fonctionner mais C'etait chiant a gerer surtout
            // si on pense au fait que equilibrer les Monstre en fonction de l'attaque choisie par le joueur donc changerais forcément la vie du joueur trop long a mettre en place je n'ai pas 
            //le temp de gerer cette equilibrage.. 
            Elfe guerrier = new Elfe(saisieName, 500, 0, 75, 90);
            //j'ajoute le guerrier ou l'aventurier choisie hein.
            lesGuerrier.Add(guerrier);

        }
    }
}
