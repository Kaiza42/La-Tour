namespace JsuisUnGuerrier.Classes
{
    internal class Dragon : Guerrier
    {
        private int _crachat;
        private int _lanceFlamme;
        public int Crachat { get => _crachat; set { _crachat = value; } }
        public int LanceFlamme { get => _lanceFlamme; set { _lanceFlamme = value; } }
        public Dragon(string nom, double pDV, double aTQ, double Heal) : base(nom, pDV, aTQ, Heal)
        {

        }
        public override string ToString()
        {
            return $"\tDragon - {Name} (PV: {PDV}, ATQ: 100)\n";
        }
        public override double Attaquer()
        {
            // a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 200;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre($"{Name} a fait un Coup Critique et inflige 200");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 100;
                    Centre($"{Name} a fait 100 de dégat !");
                    break;
            }
            return ATQ;
        }
        // attaque spécial de l'ogres
        public override double AttaqueSpecial()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Bon la phrases du gobelin a ne pas sortir de son contexte stp..
            Centre($"\t ╔═════════════════════════════════════════════════════════════════════════╗ ");
            Centre($"\t ║ Tu penses être spécial, mais tu n’es rien. Je suis le seul maître ici.  ║ ");
            Centre($"\t ╚═════════════════════════════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            int rollAttackSpecial = dice.Next(1, 7);
            switch (rollAttackSpecial)
            {
                case 6:
                    Crachat = 250;
                    Dot(10);
                    CDS = 4;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} inflige 250 dégats avec un coup critique avec sont crachat !");
                    Console.ResetColor();
                    break;
                case 5:
                    Crachat = 175;
                    Dot(5);
                    CDS = 4;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"{Name} inflige 175 dégats avec son Crachat !");
                    Console.ResetColor();
                    break;
                default:
                    Crachat = 125;
                    Dot(2);
                    CDS = 4;
                    Console.WriteLine($"{Name} a fait 125 Avec son Crachat !");
                    break;
            }
            return Crachat;
        }
        public void Drop()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Centre("Aventurier ! Un nouveau héros a été ajouté à votre compagnie !");
            Console.ResetColor();
            Sorcier mage = new Sorcier("Megumi", 400, 30, 10, 15);
            lesGuerrier.Add(mage);

        }
        public override void SubirDegats(double degat)
        {
            PDV -= degat;
            Centre($"{Name} as subis {degat} degats, il lui reste {PDV} de vie");
        }
        public override void Death()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Centre($" Le Dragon {Name} est mort.");
            Console.ResetColor();
            Drop();
        }
        public override void Dot(int degatFlamme)
        {
            LanceFlamme = degatFlamme;
            // Si le delai est plus grand que 0 la compétence ne ce lance pas 
            if (CDS > 0)
            {
                // Si le cooldown est encore actif (CDS > 0), rien ne se passe
                return;
            }
            // Degat du Feu
            lesGuerrier[0].PDV -= LanceFlamme;
        }
        public override void ReductionCooldownSpecial()
        {
            //Si monstre a au moins 1 membre dans la liste alors il le fait sinon.. bah il fait rien logique 
            if (lesGuerrier.Count > 0)
            {
                //Si CD et plus grand que 0 
                if (CDS > 0)
                {
                    // Va réduir le compteur de CD 
                    CDS--;
                }
                Dot(5);
                Console.ForegroundColor = ConsoleColor.Red;
                Centre($"{lesGuerrier[0].Name} subit {LanceFlamme} dégâts de Feu");
                Console.ResetColor();
            }
            if (CDS == 0)
            {
                LanceFlamme = 0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Centre($"{lesGuerrier[0].Name} n'est plus En feu !");
                Console.ResetColor();
            }
        }
    }

}
