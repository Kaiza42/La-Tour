namespace JsuisUnGuerrier.Classes
{
    internal class Guerrier
    {
        // pourquoi name et pas nom ? c'est un jeu videos.
        private string _name;
        // pourquoi pas "point de vie" ? trop long..
        private double _pDV;
        // pourquoi pas Attque ? trop long.
        private double _aTQ;
        // heal est pas soin ? on n'est dans un jeu videos...
        private double _heal;
        public string Name { get => _name; set { _name = value; } }
        public double PDV { get => _pDV; set { _pDV = value; } }
        public double ATQ { get => _aTQ; set { _aTQ = value; } }
        public double Heal { get => _heal; set { _heal = value; } }
        // CD sert a dire coolDown en gros delai de compétence c'est un compteur va me servir a que les compétence ne sois pas spam 
        public int CD = 0;
        public int CDS = 0;
        // un dé d'attaque ? de defense ? de heal ? bientot pour l'attaque spé ? 
        public Random dice = new Random();
        // a quoi me sert ma liste ici ? Peut etre a pas surcharger mon programme je pense..
        public static List<Guerrier> monstre = new List<Guerrier>();
        public static List<Guerrier> lesGuerrier = new List<Guerrier>();
        public static string saisieName;


        public string saisie;
        public Guerrier(string nom, double pDV, double aTQ, double heal)
        {
            // nom de héros
            Name = nom;
            // point de vie 
            PDV = pDV;
            // attaque
            ATQ = aTQ;
            // anciennement DEF devenue heal par facilité flemme de créer de l'armure 
            Heal = heal;
        }
        // pour l'affichage avec la liste 
        public override string ToString()
        {
            return $"{Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        // des attaque unique random ? attend il peut echouer ? Jeu de ses mort...
        public virtual double Attaquer()
        {
            int atq = dice.Next(1, 7);
            switch (atq)
            {
                case 6:
                    ATQ = 100;
                    Console.WriteLine($"{Name} a fait un Coup Critique ! et inflige {ATQ} ");
                    break;
                case 1:
                    ATQ = 1;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégâts !");
                    break;
                default:
                    ATQ = 50;
                    break;
            }

            return ATQ;
        }
        //tout le monde peut se heal ? Ouep. j'aime pas les classe de healer point de vue : a quoi bon quand tu peut taper ? 
        public virtual double Defense(double degatMonstre)
        {
            Heal = dice.Next(1, 101);
            if (CD > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Le Heal est en cooldown. Il reste {CD} a votre compétence de Heal");
                Console.ResetColor();
                return 0;
            }
            if (Heal > 80 && Heal < 95)
            {
                //le cooldown
                CD = 6;
                //les point de vie ajouter 
                PDV += 100;
                Console.WriteLine($"C'est un Heal parfaite. Vous vous ete heal de 100hp vos Point de vie sont : {PDV}.");
            }
            else if (Heal < 79)
            {
                CD = 5;
                PDV += 50;
                Console.WriteLine($"c'est Moyen Vous vous ete Heal de 50hp vos Point de vie sont : {PDV}.");
            }
            else
            {
                CD = 1;
                Console.WriteLine("Il ne c'est rien passer.");
            }
            return degatMonstre;
        }
        //Cooldown => delai de récupération
        public virtual void ReductionCooldown()
        {
            //Si CD et plus grand que 0 
            if (CD > 0)
            {
                // Va réduir le compteur de CD 
                CD--;
            }
        }
        public virtual void ReductionCooldownSpecial()
        {
            //Si CDS et plus grand que 0 
            if (CDS > 0)
            {
                // Va réduir le compteur de CDS
                CDS--;
            }
        }
        // le subir degat par default..
        public virtual void SubirDegats(double degat)
        {
            PDV -= degat;
            Console.WriteLine($" {Name} as subis {degat} degats, il lui reste {PDV} de vie");
            if (PDV <= 0)
            {

                Console.WriteLine($"Tu a perdue {Name}");
                PDV = 0;

            }
        }
        public void Drop()
        {
            if (PDV <= 0)
            {
                Console.WriteLine("bravo vous avez drop Une maitre des Rat qui s'appel Julie ! ");
                MaitreDesRat Julie = new MaitreDesRat("julie", 500, 40, 10, 15);
                lesGuerrier.Add(Julie);
                //if (dice.Next(1, 101) < 1 && dice.Next(1, 101) > 6) 
                //{
                //    MaitreDesRat 
                //}
            }
        }
        public virtual void Death()
        {
            Console.WriteLine($"{Name} est mort.");
            Drop();
        }

        public static void AfficherParticipant()
        {
            foreach (Guerrier lesG in lesGuerrier)
            {
                Console.WriteLine(lesG);
            }
        }
        // le tour par tour 
        public static void Choice()
        {
            //Cette boucle me sert a faire que mes joueur attaque chacun leur tour sans que le monstre tape entre deux
            // le fonctionnement est asser simple elle parcourt l'index de ma liste ou sont ranger mes personnage 
            for (int i = 0; i < lesGuerrier.Count; i++)
            {
                Console.WriteLine($"Tour de {lesGuerrier[i].Name} :");
                Console.WriteLine($"Choix 1: Attaquez");
                // sa verifie le Delai de la compétence Heal Propre a chaque personnage
                if (lesGuerrier[i].CD <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Choix 2: Heal");
                    Console.ResetColor();
                }
                else
                {
                    // et fait un affichage adapter en fonction du delai de la compétence
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Choix 2: Heal (en cooldown, {lesGuerrier[i].CD} tour restants)");
                    Console.ResetColor();
                }
                // la meme choses mais pour Attaque spécial 
                if (lesGuerrier[i].CDS <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Choix 3: Attaque Spéciale");
                    Console.ResetColor();
                }
                else
                {
                    // et fait un affichage adapter en fonction du delai de la compétence
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Choix 3: Attaque Spéciale (en cooldown, {lesGuerrier[i].CDS} tour restants)");
                    Console.ResetColor();
                }
                Console.WriteLine($"Choix 4: Quitter le jeu\n");
                Console.Write("Quel seras Votre Statégie Aventurier :  ");
                string saisie = Console.ReadLine();
                switch (saisie)
                {
                    case "1":
                        // Attaque classique
                        double degats = lesGuerrier[i].Attaquer();
                        monstre[0].SubirDegats(degats);
                        break;
                    case "2":
                        // Défense/Heal
                        if (lesGuerrier[i].CD > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"La compétence Heal est en cooldown, il reste {lesGuerrier[i].CD} tour.");
                            Console.ResetColor();
                            break;
                        }
                        lesGuerrier[i].Defense(monstre[0].Attaquer());
                        break;
                    case "3":
                        monstre[0].SubirDegats(lesGuerrier[i].AttaqueSpecial());
                        break;
                    case "4":
                        // Quitter le jeu
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n\n\n");
                        Console.WriteLine($"\t\t ╔═════════════════════════╗ ");
                        Console.WriteLine($"\t\t ║  A bientôt Aventurier ! ║ ");
                        Console.WriteLine($"\t\t ╚═════════════════════════╝ \n\n\n");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Veuillez saisir une option valide !");
                        Console.ResetColor();
                        break;
                }
                // Réduction du cooldown après chaque tour
                lesGuerrier[i].ReductionCooldown();
            }
        }
        //En vérité j'aurais du faire une classe default pour les Monstre mais Je l'ai remarquer un peu tard..
        public static void ChoiceMonstre()
        {
           // vue que les choix peuvent attaquer chacun leur tour pourquoi pas les monstre ? 
            for (int i = 0; i < monstre.Count; i++)
            {
                Console.WriteLine($"Tour de {monstre[i]} :");
                int aleatoireMob = monstre[i].ActionMob();
                switch (aleatoireMob)
                {
                    case 1:
                        // Attaque classique
                        double degats = monstre[i].Attaquer();
                        monstre[0].SubirDegats(degats);
                        break;
                    case 2:
                        //Attaque spécial des monstre !
                        lesGuerrier[0].SubirDegats(monstre[i].AttaqueSpecial());
                        break;
                }
                // Réduction du cooldown après chaque tour
                monstre[i].ReductionCooldown();
            }
        }
        //methode pour initier le dé des mob 
        public int ActionMob()
        {
            Random diceMob = new Random();
            //Encor une liste encor une..
            List<int> listActionMob = new List<int>();
            //La premiere Action est toujours utilisable 
            listActionMob.Add(1);
            // Si CD n'est pas a 0 alors la compétence n'est pas Utilisable 
            if (this.CD == 0)// sa verifie le cooldown de la competence du monstre 
            {
                // puis l'ajoute a liste de choix 
                listActionMob.Add(2);
            }
            int mobAction = listActionMob[diceMob.Next(0, listActionMob.Count)];
            return mobAction;
            
        }
        public static void Mob()
        {
            Wolf wolf = new Wolf("wolfy", 200, 30, 0, true);
            Ogres Ogres = new Ogres("Alexandre", 300, 40, 0, 0);
            Guerrier.monstre.Add(wolf);
            Guerrier.monstre.Add(Ogres);
        }
        public virtual double AttaqueSpecial()
        {
            return ATQ;
        }
        public virtual void Dot(int degatPoison)
        {

        }
    }
}

