namespace JsuisUnGuerrier.Classes
{
    internal class Vampire : Guerrier 
    {
        private int _baiserDuVampire;
        public int BaiserDuVampire { get => _baiserDuVampire; set { _baiserDuVampire = value; } }
        public Vampire(string nom, double pDV, double aTQ, double heal, int baiserDuVampire) : base(nom, pDV, aTQ, heal)
        {
            BaiserDuVampire = baiserDuVampire;
        }
        public override string ToString()
        {
            return $"\tVampire - {Name} (PV: {PDV}, ATQ: 60)\n";
        }
        //Sur le principe le gobelin aparaitrer dans le Deuxieme Etage Et dornnerais le sorcier
        public override double Attaquer()
        {
            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 120;
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
                    ATQ = 60;
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
            Centre($" ╔════════════════════════════════════════════════════════╗ ");
            Centre($" ║  Ton sang me nourrira, Le temps de ta vie est compté ! ║ ");
            Centre($" ╚════════════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    BaiserDuVampire = 160;
                    CDS = 3;
                    monstre[0].PDV += 60;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} inflige 160 dégats avec un coup critique avec Baiser Du Vampire !");
                    Centre($" Heal un Allié de 60 Pv");
                    Console.ResetColor();
                    break;
                default:
                    BaiserDuVampire = 70;
                    CDS = 3;
                    monstre[0].PDV += 30;
                    Centre($"{Name} a fait 70 Avec Baiser Du Vampire !");
                    Centre($" Heal un Allié de 30 Pv");
                    break;
            }
            return BaiserDuVampire;
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
            Pretre pretre = new Pretre("Elunor", 450, 30, 10, 15,0);
            lesGuerrier.Add(pretre);
        }
    }
}
