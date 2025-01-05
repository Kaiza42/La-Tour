using JsuisUnGuerrier.Affichage;
using System;
using System.IO;
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
            Heal = heal;
        }
        // pour l'affichage avec la liste 
        public override string ToString()
        {
            return $" Default {Name} (PV: {PDV}, ATQ: 50)";
        }
        // des attaque unique random ? attend il peut echouer ? Jeu de ses mort...
        public virtual double Attaquer()
        {
            int atq = dice.Next(1, 7);
            switch (atq)
            {
                case 6:
                    ATQ = 100;
                    Centre($"{Name} a fait un Coup Critique ! et inflige {ATQ} ");
                    break;
                case 1:
                    ATQ = 1;
                    Centre($"{Name} a fait {ATQ} de dégâts !");
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
                Centre($"Le Heal est en cooldown. Il reste {CD} a votre compétence de Heal");
                Console.ResetColor();
                return 0;
            }
            if (Heal > 80 && Heal < 95)
            {
                //le cooldown
                CD = 6;
                //les point de vie ajouter 
                PDV += 100;
                Centre($"C'est un Heal parfaite. Vous vous ete heal de 100hp vos Point de vie sont : {PDV}.");
            }
            else if (Heal < 79)
            {
                CD = 5;
                PDV += 50;
                Centre($"c'est Moyen Vous vous ete Heal de 50hp vos Point de vie sont : {PDV}.");
            }
            else
            {
                CD = 1;
                Centre("Il ne c'est rien passer.");
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
            //Si CD et plus grand que 0 
            if (CDS > 0)
            {
                // Va réduir le compteur de CD 
                CDS--;
            }
        }

        // le subir degat par default..
        public virtual void SubirDegats(double degat)
        {
            PDV -= degat;
        }

        public virtual void Death()
        {
            Centre($"{Name} est mort.");
        }
        public static void AfficherParticipant()
        {
            foreach (Guerrier lesG in lesGuerrier)
            {
                Console.WriteLine(lesG);
            }
        }
        public static string AfficherParticipantMonstre()
        {
            string mesMonstre = "";
            for(int i = 0; i < monstre.Count -1; i++)
            {
                mesMonstre =  $"{monstre[i]} \n";
            }

            return mesMonstre;
        }

        public virtual double AttaqueSpecial()
        {
            return ATQ;
        }
        public virtual void Dot(int degatPoison)
        {
        }
        public int ActionMob()
        {
            Random diceMob = new Random();
            //Encor une liste encor une..
            List<int> listActionMob = new List<int>();
            //La premiere Action est toujours utilisable 
            listActionMob.Add(1);
            // Si CD n'est pas a 0 alors la compétence n'est pas Utilisable 
            if (this.CD == 0)
            {
                // puis l'ajoute a liste de choix 
                listActionMob.Add(2);
            }
            int mobAction = listActionMob[diceMob.Next(0, listActionMob.Count)];
            return mobAction;
        }
        //Lui c'est pour aligner le texte au centre 
        public static void Centre(string texte)
        {
            int windowWidth = Console.WindowWidth;
            int espace = (windowWidth - texte.Length) / 2;
            Console.WriteLine(new string(' ', espace) + texte);
        }
        //lui c'est pour les saisie sois sur la meme ligne et non retour a ligne
        // avis perso : J'aurais pas du m'y prendre a la derniere minute pour gerer de l'affichage..
        public static void CentreEcrit(string texte)
        {
            int windowWidth = Console.WindowWidth;
            int espace = (windowWidth - texte.Length) / 2;
            Console.Write(new string(' ', espace) + texte);
        }
    }
}