namespace JsuisUnGuerrier.Classes
{
    internal class Wolf : Guerrier
    {
        private int _griffe;

        public int Griffe { get => _griffe; set { _griffe = value; } }
        public Wolf(string nom, double pDV, double aTQ, double dEF, int griffe) : base(nom, pDV, aTQ, dEF)
        {
            Griffe = griffe;
        }
        public override string ToString()
        {
            return $" le Loup {Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        public override double Attaquer()
        {
            //Pourquoi stocker dice ? hum.. a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int result = dice.Next(1, 7);
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 90;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 10;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a raté son attaque !");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 45;
                    Centre($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        public override double AttaqueSpecial()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Bon la phrases du gobelin a ne pas sortir de son contexte stp..
            Centre($" ╔══════════╗ ");
            Centre($" ║  Wof !   ║ ");
            Centre($" ╚══════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    Griffe = 80;
                    CDS = 3;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} inflige 140 dégats avec un coup critique avec Griffe !");
                    Console.ResetColor();
                    break;
                default:
                    Griffe = 40;
                    CDS = 3;
                    Centre($"{Name} a fait 70 Avec sa Lancer De Roue !");
                    break;
            }
            return Griffe;
        }
        public void Drop()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Centre("Aventurier ! Un nouveau héros a été ajouté à votre compagnie !");
            MaitreDesRat Julie = new MaitreDesRat("julie", 500, 40, 10, 0);
            lesGuerrier.Add(Julie);
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

    }
}
