using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Nain : Guerrier
    {
        private bool _armureLourde;
        private double _feu;

        public bool ArmureLourde { get => _armureLourde; set { _armureLourde = value; } }
        public double Feu { get => _feu; set { _feu = value; } }
        public Nain(string nom, double pDV, double aTQ, double dEF, bool armureLourde, double feu) : base(nom, pDV, aTQ, dEF)
        {
            ArmureLourde = armureLourde;
            Feu = feu;
        }
        // l'affichage quand on affiche la Compagnie
        public override string ToString()
        {
            return $"Nain - {Name} (PV: {PDV}, ATQ: 50)\n";
        }
        //Le subir degat du nain 
        public override void SubirDegats(double degat)
        {
            if (ArmureLourde == true)
            {
                degat /= 2;
            }
            PDV = PDV - degat;
            Centre($" {Name} a subi {degat}");
        }
        // le choix quand on selectionne le nain 
        public static void ChoiceNain()
        {
            Console.Clear();
            do
            {
                CentreEcrit("Veuillez saisir un nom pour votre Nain entre 1 a 10 caractre : ");
                saisieName = Console.ReadLine();
                if (saisieName.Length > 10 || saisieName.Length < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centre("Veuillez saisir nombre de caractere entre 1 et 10");
                    Console.ResetColor();
                    CentreEcrit("Veuillez saisir un nom Valide pour votre Nain : ");
                    saisieName = Console.ReadLine();
                }
            } while (saisieName.Length > 10 || saisieName.Length < 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Centre($"Bienvenue {saisieName} ! ");
            Console.ResetColor();
            Nain guerrier = new Nain(saisieName, 600, 50, 0, true, 0);
            lesGuerrier.Add(guerrier);
        }
        //Attaque spé du Nain 
        public override double AttaqueSpecial()
        {
            // condition pour les abuser d'attaque spécial
            if (CDS <= 0)
            {
                int rollAttackSpecial = dice.Next(1, 7);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Centre($"╔═══════════════════════════════════════════════════╗ ");
                Centre($"║  Brûle dans le brasier de la forge ancestrale !   ║ ");
                Centre($"╚═══════════════════════════════════════════════════╝ ");
                Console.ResetColor();
                switch (rollAttackSpecial)
                {
                    case 6:
                        ATQ = 150;
                        CDS = 6;
                        //l'appelation de ma methode DOT du coup qui dureras le temp du Delai de attaque spécial 
                        Dot(30);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Centre($"{Name} a fait 150 de dégat !");
                        Console.ResetColor();
                        break;
                    default:
                        ATQ = 75;
                        CDS = 6;
                        Dot(25);
                        Centre($"{Name} a fait 75 de dégat !");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centre("On abuse pas des Attaque Spécial Aventurier ! ");
                Console.ResetColor();
            }
            return ATQ;
        }
        // DOT damage over time 
        public override void Dot(int degatFeu)
        {
            Feu = degatFeu;
            // Si le delai est plus grand que 0 la compétence ne ce lance pas 
            if (CDS > 0)
            {
                // Si le cooldown est encore actif (CDS > 0), rien ne se passe
                return; // Retourne et arrête l'exécution de la méthode ici
            }
            // Degat du Feu
            monstre[0].PDV -= Feu;
        }
        public override void ReductionCooldownSpecial()
        {
            //Si monstre a au moins 1 membre dans la liste alors il le fait sinon.. bah il fait rien logique 
            if (monstre.Count > 0)
            {
                //Si CD et plus grand que 0 
                if (CDS > 0)
                {
                    // Va réduir le compteur de CD 
                    CDS--;
                }
                Dot(15);
                Console.ForegroundColor = ConsoleColor.Red;
                Centre($"{monstre[0].Name} subit {Feu} dégâts de Feu");
                Console.ResetColor();
            }
            if (CDS == 0)
            {
                Feu = 0;
            }
        }
    }
}
