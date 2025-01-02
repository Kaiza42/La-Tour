namespace JsuisUnGuerrier.Classes
{
    internal class Ogres : Guerrier
    {
        private int _lancerDeRoue;
        public int LancerDeRoue { get => _lancerDeRoue; set { _lancerDeRoue = value; } }
        List<Guerrier> lesGuerrier = new List<Guerrier>();
        List<Guerrier> monstre = new List<Guerrier>();
        public Ogres(string nom, double pDV, double aTQ, double dEF, int lancerDeRoue) : base(nom, pDV, aTQ, dEF)
        {
            LancerDeRoue = lancerDeRoue;
        }
        public override double Attaquer()
        {
            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 140;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} a fait un Coup Critique et inflige {ATQ}");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} Rate son attaque Et inflige Tout de meme {ATQ} ");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 60;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        // attaque spécial de l'ogres
        public override double AttaqueSpecial()
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t ╔═════════════════════════════════╗ ");
            Console.WriteLine($"\t ║   Aléatoirement Ce Sera TOI !   ║ ");
            Console.WriteLine($"\t ╚═════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    //les degat de Fleche quand il Active l'attaque Spécial
                    LancerDeRoue = 180;
                    // le delai de récupération
                    CDS = 5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} inflige 180 dégats avec un coup critique avec sa Lancer de Roue !");
                    Console.ResetColor();
                    break;
                default:
                    LancerDeRoue = 90;
                    CDS = 5;
                    Console.WriteLine($"{Name} a fait 90 Avec sa Lancer De Roue !");
                    break;
            }
            return LancerDeRoue;
        }
        public void Drop()
        {
            if (PDV < 0)
            {

                MaitreDesRat Julie = new MaitreDesRat("julie", 500, 40, 10, 15);
                lesGuerrier.Add(Julie);
                // ce code mis en comentaire seras utiliser UNIQUEMENT si je met les item Epée ect 
                //if (dice.Next(1, 101) < 1 && dice.Next(1, 101) > 6) 
                //{
                //    MaitreDesRat 
                //}
            }
        }
        public override void SubirDegats(double degat)
        {
            PDV -= degat;
            Console.WriteLine($"{Name} as subis {degat} degats, il lui reste {PDV} de vie");
            //Verifie les point de vie pour l'enlever de la liste car bon le faire combattre jusuqu'a -5000 c'est chiant
        }
        public override void Death()
        {
            Console.WriteLine($"{Name} est mort.");
            Drop();
        }
    }
}
