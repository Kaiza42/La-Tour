using JsuisUnGuerrier.Classes;
using JsuisUnGuerrier.Affichage;
namespace JsuisUnGuerrier.Affichage
{
    internal class MenuCombat : Guerrier
    {
        public MenuCombat(string nom, double pDV, double aTQ, double dEF) : base(nom, pDV, aTQ, dEF)
        {
        }
        public static void Choice()
        {
            Console.Clear();
            Guerrier.AfficherParticipant();
            //Cette boucle me sert a faire que mes joueur attaque chacun leur tour sans que le monstre tape entre deux
            // le fonctionnement est asser simple elle parcourt l'index de ma liste ou sont ranger mes personnage 
            for (int i = 0; i < lesGuerrier.Count; i++)
            {
                Centre($"Tour de {lesGuerrier[i].Name} : ");
                Centre($"Choix 1: Attaquez");
                // sa verifie le Delai de la compétence Heal Propre a chaque personnage
                if (lesGuerrier[i].CD <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Centre($"Choix 2: Heal");
                    Console.ResetColor();
                }
                else
                {
                    // et fait un affichage adapter en fonction du delai de la compétence
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Centre($"Choix 2: Heal (en cooldown, {lesGuerrier[i].CD} tour restants)");
                    Console.ResetColor();
                }
                // la meme choses mais pour Attaque spécial 
                if (lesGuerrier[i].CDS <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Centre("Choix 3: Attaque Spéciale");
                    Console.ResetColor();
                }
                else
                {
                    // et fait un affichage adapter en fonction du delai de la compétence
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Centre($"Choix 3: Attaque Spéciale (en cooldown, {lesGuerrier[i].CDS} tour restants)");
                    Console.ResetColor();
                }
                Centre($"Choix 4: Quitter le jeu\n");
                CentreEcrit("Quel seras Votre Statégie Aventurier :  ");
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
                            Centre($"La compétence Heal est en cooldown, il reste {lesGuerrier[i].CD} tour.");
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
                        Affichage.Fermeture();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Veuillez saisir une option valide !");
                        Console.ResetColor();
                        break;
                }
                // Réduction du cooldown après chaque tour
                lesGuerrier[i].ReductionCooldown();
                
            }
        }
    }
}
